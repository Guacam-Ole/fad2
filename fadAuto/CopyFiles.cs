using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fadAuto
{
    public partial class CopyFiles : MetroForm
    {
        private bool _isConnected;
        private bool _isCopying;
        private DateTime? _lastConnection;
        private int _filesTotal;
        private int _filesCopied;
        private string _currentFile;
       

        public CopyFiles()
        {
            InitializeComponent();
            var copyState = new CopyState();
            copyState.Connected += CopyState_Connected;
            copyState.CopyFinished += CopyState_CopyFinished;
            copyState.DisConnected += CopyState_DisConnected;
            copyState.FileCopyFinished += CopyState_FileCopyFinished;
            copyState.FileCopyStarted += CopyState_FileCopyStarted;
            ShowStatus();
            copyState.StartLoop();
        }

        private void CopyState_FileCopyStarted(object sender, EventArgs e)
        {
            _isCopying = true;
            var state = (CopyState)sender;
            _filesTotal = state.TotalFiles;            
            ShowStatus();
        }

        private void CopyState_FileCopyFinished(object sender, EventArgs e)
        {
            _isCopying = false;
            var state = (CopyState)sender;
            _filesCopied = state.FilesCopied;
            ShowStatus();
        }

        private void CopyState_DisConnected(object sender, EventArgs e)
        {
            _isConnected = false;
            ShowStatus();
        }

        private void CopyState_CopyFinished(object sender, EventArgs e)
        {
            ShowStatus();
        }

        private void CopyState_Connected(object sender, EventArgs e)
        {
            _isConnected = true;
            _lastConnection = DateTime.Now;
            ShowStatus();
        }

        private void ShowStatus()
        {
            prgCopy.Visible = false;
            lblRemainingText.Text = string.Empty;
            lblCurrentText.Text = string.Empty;

            if (_isCopying)
            {
                lblStatusText.Text = "Copying files";
                prgCopy.Value = _filesCopied;
                prgCopy.Maximum = _filesTotal;
                prgCopy.Visible = true;
                lblRemainingText.Text = string.Format("{0}", _filesTotal - _filesCopied);
                lblCurrentText.Text = _currentFile;
            } else if (_isConnected)
            {
                lblStatusText.Text = "Connected";
            } else
            {
                lblStatusText.Text = "Not Connected ";
                if (_lastConnection.HasValue)
                {
                    lblStatusText.Text += string.Format("(Last connected: {0})", _lastConnection);
                } 
            }
            Application.DoEvents();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ctxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctxAbout_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = WindowState == FormWindowState.Minimized ? FormWindowState.Normal : FormWindowState.Minimized;
        }
    }
}
