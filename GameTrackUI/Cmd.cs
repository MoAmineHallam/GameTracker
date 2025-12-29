using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FinalProjectUI
{
    public partial class Cmd: Form
    {
        public Cmd()
        {
            InitializeComponent();
        }

        public void AppendOutput(string text)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            try
            {
                if (cmdOutputBox.InvokeRequired)
                {
                    cmdOutputBox.Invoke(new Action(() =>
                    {
                        if (!cmdOutputBox.IsDisposed)
                            cmdOutputBox.AppendText(text + Environment.NewLine);
                    }));
                }
                else
                {
                    if (!cmdOutputBox.IsDisposed)
                        cmdOutputBox.AppendText(text + Environment.NewLine);
                }
            }
            catch (ObjectDisposedException)
            {
                // Control was already disposed; ignore
            }
            catch (InvalidOperationException)
            {
                // Possibly UI is already shutting down; ignore
            }
        }

        public void ClearOutput()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ClearOutput));
                return;
            }

            cmdOutputBox.Clear();
        }

        private void Hide_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
