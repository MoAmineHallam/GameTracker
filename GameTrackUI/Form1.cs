using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using System.Threading.Tasks;
using System.Management;
using System.Threading;

namespace FinalProjectUI
{
    public partial class Form1 : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        private MediaPlayer _outputMediaPlayer;
        private Image gifImage = Properties.Resources.football_transparent1;
        private bool isAnimating = false;
        private string currentVideoPath = ""; // Track the currently loaded video
        private bool Analyze_toggle = false;
        private bool Analyzing_Done = false;
        private readonly string _repoRoot;
        private readonly string _backendMainPy;
        private readonly string _outputDir;
        private string outputVideoPath;   // will be set at runtime
        private Cmd cmdOutput;
        private Process python_process;
        private volatile bool _isFormClosing = false;
        private CancellationTokenSource _cancellationTokenSource;


        public Form1()
        {
            InitializeComponent();
            _repoRoot = FindRepoRoot(AppDomain.CurrentDomain.BaseDirectory);
            _backendMainPy = Path.Combine(_repoRoot, "backend", "main.py");
            _outputDir = Path.Combine(_repoRoot, "output");
            Directory.CreateDirectory(_outputDir);

            // default output file
            outputVideoPath = Path.Combine(_outputDir, "output.avi");
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            Application.ApplicationExit += OnApplicationExit;
            football.BackColor = Color.Transparent;
            AnalizingLabel.Visible = false;

            Core.Initialize();
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            _outputMediaPlayer = new MediaPlayer(_libVLC);
            inputVideo.MediaPlayer = _mediaPlayer;
            OutputVideo.MediaPlayer = _outputMediaPlayer;
            cmdOutput = new Cmd();
            cmdOutput.Hide();

            PLayPauseBtn.Text = "▶ ";
            _cancellationTokenSource = new CancellationTokenSource(); // Initialize CancellationTokenSource
        }

        private static string FindRepoRoot(string baseDir)
        {
            // baseDir is something like: ui\FinalProjectUI\bin\Debug\net...
            // We walk upward until we find a marker that indicates repo root.
            // Use your solution file name or a folder you know exists.
            var dir = new DirectoryInfo(baseDir);

            while (dir != null)
            {
                // Prefer solution marker if it exists
                var sln = dir.GetFiles("FinalProjectUI.sln");
                if (sln.Length > 0) return dir.FullName;

                // Or any marker you will ship, e.g., backend/main.py
                if (File.Exists(Path.Combine(dir.FullName, "backend", "main.py")))
                    return dir.FullName;

                dir = dir.Parent;
            }

            // Fallback: base dir (will fail fast if structure is wrong)
            return baseDir;
        }

        private static string Quote(string s) => $"\"{s}\"";

        private static string GetPythonExe()
        {
            // 1) Allow override: set env var GAMETRACK_PYTHON to full python path
            //    Example: GAMETRACK_PYTHON=C:\Users\...\anaconda3\envs\FinalEnv\python.exe
            var env = Environment.GetEnvironmentVariable("GAMETRACK_PYTHON");
            if (!string.IsNullOrWhiteSpace(env) && File.Exists(env))
                return env;

            // 2) Default: rely on PATH
            return "python";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImageAnimator.UpdateFrames(gifImage);
            football.Image = new Bitmap(gifImage);
            football.Paint += football_Paint;
        }

        private void InputVideoBtn_Click(object sender, EventArgs e)
        {


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mkv;*.mov;*.wmv|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentVideoPath = openFileDialog.FileName; // Store the current video path
                    // Stop any current playback
                    if (_mediaPlayer.IsPlaying)
                    {
                        _mediaPlayer.Stop();
                    }

                    // Create and play the media in inputVideo
                    using (var media = new Media(_libVLC, new Uri(openFileDialog.FileName)))
                    {
                        _mediaPlayer.Play(media);
                        PLayPauseBtn.Text = "■";
                    }
                }
            }
            ImageAnimator.UpdateFrames(gifImage);
            football.Image = new Bitmap(gifImage);
            football.Paint += football_Paint;
            Analyze_toggle = false;
            AnalizingLabel.Visible = false;
            AnalyzeDoubleClick.Visible = false;
            UploadVdFst.Visible = false;


        }

        private async void AnalyzBtn_Click(object sender, EventArgs e)
        {

            if (currentVideoPath != "")
            {
                if (Analyze_toggle == false)
                {
                    Analyze_toggle = true;
                    AnalizingLabel.Visible = true;
                    football.Image = Properties.Resources.football_transparent1;
                    cmdOutput.ClearOutput();

                    // Run Python script with the current video path
                    await RunPythonScript(currentVideoPath);
                }
                else
                {
                    AnalyzeDoubleClick.Visible = true;
                    OutputVideo.MediaPlayer = null;
                    OutputVideo.BackColor = Color.Black;
                }
            }
            else
            {
                UploadVdFst.Visible = true;
            }

        }

        private void PLayPauseBtn_Click(object sender, EventArgs e)
        {
            if (currentVideoPath != "")
            {
                if (_mediaPlayer.IsPlaying)
                {
                    _mediaPlayer.Pause();
                    PLayPauseBtn.Text = "▶";
                }
                else
                {
                    _mediaPlayer.Play();
                    PLayPauseBtn.Text = "■";
                }
            }
        }
        private void FullScreenBtn_Click(object sender, EventArgs e)
        {
            if (currentVideoPath != "")
            {
                if (!string.IsNullOrEmpty(currentVideoPath))
                {
                    try
                    {
                        // Open the video in default media player
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = currentVideoPath,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening video player: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No video loaded", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void PlayPauseBtnOutput_Click(object sender, EventArgs e)
        {

            if (Analyzing_Done == true)
            {
                if (_outputMediaPlayer.IsPlaying)
                {
                    _outputMediaPlayer.Pause();
                    PlayPauseBtnOutput.Text = "▶";
                }
                else
                {
                    _outputMediaPlayer.Play();
                    PlayPauseBtnOutput.Text = "■";
                }
            }

        }

        private void FullScreenBtnOutput_Click(object sender, EventArgs e)
        {
            if (Analyzing_Done == true)
            {
                if (!string.IsNullOrEmpty(outputVideoPath))
                {
                    try
                    {
                        // Open the video in default media player
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = outputVideoPath,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening video player: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No video loaded", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            football.Invalidate(); // triggers Paint event
        }

        private void football_Paint(object sender, PaintEventArgs e)
        {
            if (isAnimating && gifImage != null)
            {
                ImageAnimator.UpdateFrames(gifImage);
                e.Graphics.DrawImage(gifImage, new Point(0, 0));
            }
        }


        private async Task RunPythonScript(string videoPath)
        {
            if (!File.Exists(_backendMainPy))
            {
                MessageBox.Show(
                    $"Backend script not found:\n{_backendMainPy}\n\n" +
                    "Fix your repo structure so backend/main.py exists.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Analyze_toggle = false;
                AnalizingLabel.Visible = false;
                return;
            }

            // Output path: put it in repo/output/
            // You can keep fixed name or make unique; unique avoids file locks.
            var stamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            outputVideoPath = Path.Combine(_outputDir, $"output_{stamp}.avi");

            try
            {
                if (File.Exists(outputVideoPath)) File.Delete(outputVideoPath);
            }
            catch { /* ignore */ }

            string pythonExe = GetPythonExe();

            // IMPORTANT: this assumes your Python main.py supports these args:
            //   --video <path> --output <path>
            // You must implement argparse in Python accordingly.
            string args =
                $"{Quote(_backendMainPy)} " +
                $"--video {Quote(videoPath)} " +
                $"--output {Quote(outputVideoPath)}";

            var startInfo = new ProcessStartInfo
            {
                FileName = pythonExe,
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(_backendMainPy) // backend/
            };

            python_process = new Process { StartInfo = startInfo, EnableRaisingEvents = true };

            python_process.OutputDataReceived += PythonOutputHandler;
            python_process.ErrorDataReceived += PythonErrorHandler;

            try
            {
                python_process.Start();
                python_process.BeginOutputReadLine();
                python_process.BeginErrorReadLine();

                // Wait for completion without arbitrary timeout
                await Task.Run(() => python_process.WaitForExit());

                // Stop handlers
                python_process.OutputDataReceived -= PythonOutputHandler;
                python_process.ErrorDataReceived -= PythonErrorHandler;

                int exitCode = python_process.ExitCode;

                this.Invoke((MethodInvoker)delegate
                {
                    if (exitCode != 0)
                    {
                        MessageBox.Show(
                            $"Python process failed (exit code {exitCode}).\n" +
                            "Check CMD output for errors.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (File.Exists(outputVideoPath))
                    {
                        _outputMediaPlayer.Stop();
                        using (var media = new Media(_libVLC, new Uri(outputVideoPath)))
                        {
                            _outputMediaPlayer.Play(media);
                        }
                        Analyzing_Done = true;
                        Download_Button.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Python finished but output file was not created.\nCheck CMD output for errors.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // UI reset
                    ImageAnimator.UpdateFrames(gifImage);
                    football.Image = new Bitmap(gifImage);
                    football.Paint += football_Paint;
                    Analyze_toggle = false;
                    AnalizingLabel.Visible = false;
                    AnalyzeDoubleClick.Visible = false;
                    UploadVdFst.Visible = false;
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Execution failed: {ex.Message}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AnalizingLabel.Visible = false;
                    Analyze_toggle = false;
                });
            }
            finally
            {
                if (python_process != null)
                {
                    try
                    {
                        python_process.CancelOutputRead();
                        python_process.CancelErrorRead();

                        python_process.OutputDataReceived -= PythonOutputHandler;
                        python_process.ErrorDataReceived -= PythonErrorHandler;

                        if (!python_process.HasExited)
                            python_process.Kill();
                    }
                    catch { }
                    finally
                    {
                        python_process.Dispose();
                        python_process = null;
                    }
                }
            }
        }

        private void PythonOutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (_isFormClosing || cmdOutput == null || cmdOutput.IsDisposed) return;
            if (!string.IsNullOrEmpty(e.Data))
            {
                try
                {
                    cmdOutput.AppendOutput(e.Data);
                }
                catch (ObjectDisposedException)
                {
                    // Ignore if cmdOutput is already disposed
                }
            }
        }

        private void PythonErrorHandler(object sender, DataReceivedEventArgs e)
        {
            if (_isFormClosing || cmdOutput == null || cmdOutput.IsDisposed) return;
            if (!string.IsNullOrEmpty(e.Data))
            {
                try
                {
                    cmdOutput.AppendOutput("ERR: " + e.Data);
                }
                catch (ObjectDisposedException)
                {
                    // Ignore if cmdOutput is already disposed
                }
            }
        }



        private void cmd_button_Click(object sender, EventArgs e)
        {
            cmdOutput.Show();
        }

        private void Download_Button_Click(object sender, EventArgs e)
        {
            if (!File.Exists(outputVideoPath))
            {
                MessageBox.Show("Output video not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "AVI Video (*.avi)|*.avi|All Files (*.*)|*.*";
                saveFileDialog.FileName = "AnalyzedVideo.avi";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(outputVideoPath, saveFileDialog.FileName, true);
                        MessageBox.Show("Video saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving video: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isFormClosing = true;

            // Stop and dispose media players
            _mediaPlayer?.Stop();
            _mediaPlayer?.Dispose();
            _outputMediaPlayer?.Stop();
            _outputMediaPlayer?.Dispose();
            _libVLC?.Dispose();

            // Safely kill and dispose the Python process
            if (python_process != null)
            {
                try
                {
                    // Cancel output/error reads to stop event handlers
                    python_process.CancelOutputRead();
                    python_process.CancelErrorRead();

                    // Unsubscribe from event handlers
                    python_process.OutputDataReceived -= PythonOutputHandler;
                    python_process.ErrorDataReceived -= PythonErrorHandler;

                    // Kill the process if it's still running
                    if (!python_process.HasExited)
                    {
                        python_process.Kill();
                    }
                }
                catch (InvalidOperationException)
                {
                    // The process was never started or is already disposed
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while closing Python process: " + ex.Message);
                }
                finally
                {
                    // Dispose the process object to release resources
                    python_process.Dispose();
                    python_process = null; // Set to null to prevent further access
                }
            }

            // Dispose the cmd output form if needed
            if (cmdOutput != null && !cmdOutput.IsDisposed)
            {
                cmdOutput.Close();
                cmdOutput.Dispose();
            }

            // Forcefully terminate the application 
            Environment.Exit(0);
        }
        private void OnProcessExit(object sender, EventArgs e)
        {
            KillPythonProcess();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            KillPythonProcess();
        }

        private void KillPythonProcess()
        {
            if (python_process != null)
            {
                try
                {
                    if (!python_process.HasExited)
                    {
                        python_process.Kill();
                    }
                    python_process.Dispose();
                }
                catch (Exception)
                {
                    // Handle or ignore cleanup errors
                }
            }
        }

    }
}