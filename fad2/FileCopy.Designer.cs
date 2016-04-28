namespace fad2.UI
{
    partial class FileCopy
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProgressPanel = new MetroFramework.Controls.MetroPanel();
            this.Progress = new MetroFramework.Controls.MetroProgressBar();
            this.CurrentAction = new MetroFramework.Controls.MetroLabel();
            this.CancelCopy = new MetroFramework.Controls.MetroButton();
            this.ImageInfoPanel = new MetroFramework.Controls.MetroPanel();
            this.ImageSizeContent = new MetroFramework.Controls.MetroLabel();
            this.ImageFilenameContent = new MetroFramework.Controls.MetroLabel();
            this.ImageFolderContent = new MetroFramework.Controls.MetroLabel();
            this.ImageSizeLabel = new MetroFramework.Controls.MetroLabel();
            this.ImageFilenameLabel = new MetroFramework.Controls.MetroLabel();
            this.ImageFolderLabel = new MetroFramework.Controls.MetroLabel();
            this.SinglePreviewThumb = new MetroFramework.Controls.MetroTile();
            this.FileSplitter = new System.Windows.Forms.SplitContainer();
            this.LeftPanel = new MetroFramework.Controls.MetroPanel();
            this.RightPanel = new MetroFramework.Controls.MetroPanel();
            this.FileTooltip = new MetroFramework.Components.MetroToolTip();
            this.LocalPath = new MetroFramework.Controls.MetroTextBox();
            this.RightTiles = new MetroFramework.Controls.MetroPanel();
            this.CopyPanel = new MetroFramework.Controls.MetroPanel();
            this.CopyToFlashAir = new MetroFramework.Controls.MetroButton();
            this.CopyFromFlashAir = new MetroFramework.Controls.MetroButton();
            this.ProgressPanel.SuspendLayout();
            this.ImageInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileSplitter)).BeginInit();
            this.FileSplitter.Panel1.SuspendLayout();
            this.FileSplitter.Panel2.SuspendLayout();
            this.FileSplitter.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.CopyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.Controls.Add(this.Progress);
            this.ProgressPanel.Controls.Add(this.CurrentAction);
            this.ProgressPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressPanel.HorizontalScrollbarBarColor = true;
            this.ProgressPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ProgressPanel.HorizontalScrollbarSize = 10;
            this.ProgressPanel.Location = new System.Drawing.Point(0, 541);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Size = new System.Drawing.Size(1153, 70);
            this.ProgressPanel.TabIndex = 2;
            this.ProgressPanel.VerticalScrollbarBarColor = true;
            this.ProgressPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ProgressPanel.VerticalScrollbarSize = 10;
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(11, 36);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(1142, 23);
            this.Progress.TabIndex = 3;
            // 
            // CurrentAction
            // 
            this.CurrentAction.AutoSize = true;
            this.CurrentAction.Location = new System.Drawing.Point(4, 14);
            this.CurrentAction.Name = "CurrentAction";
            this.CurrentAction.Size = new System.Drawing.Size(66, 19);
            this.CurrentAction.TabIndex = 2;
            this.CurrentAction.Text = "Initializing";
            // 
            // CancelCopy
            // 
            this.CancelCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCopy.Location = new System.Drawing.Point(793, 79);
            this.CancelCopy.Name = "CancelCopy";
            this.CancelCopy.Size = new System.Drawing.Size(357, 23);
            this.CancelCopy.TabIndex = 4;
            this.CancelCopy.Text = "Start copying files...";
            this.CancelCopy.UseSelectable = true;
            this.CancelCopy.Visible = false;
            this.CancelCopy.Click += new System.EventHandler(this.StartCopy_Click);
            // 
            // ImageInfoPanel
            // 
            this.ImageInfoPanel.Controls.Add(this.CancelCopy);
            this.ImageInfoPanel.Controls.Add(this.ImageSizeContent);
            this.ImageInfoPanel.Controls.Add(this.ImageFilenameContent);
            this.ImageInfoPanel.Controls.Add(this.ImageFolderContent);
            this.ImageInfoPanel.Controls.Add(this.ImageSizeLabel);
            this.ImageInfoPanel.Controls.Add(this.ImageFilenameLabel);
            this.ImageInfoPanel.Controls.Add(this.ImageFolderLabel);
            this.ImageInfoPanel.Controls.Add(this.SinglePreviewThumb);
            this.ImageInfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ImageInfoPanel.HorizontalScrollbarBarColor = true;
            this.ImageInfoPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ImageInfoPanel.HorizontalScrollbarSize = 10;
            this.ImageInfoPanel.Location = new System.Drawing.Point(0, 433);
            this.ImageInfoPanel.Name = "ImageInfoPanel";
            this.ImageInfoPanel.Size = new System.Drawing.Size(1153, 108);
            this.ImageInfoPanel.TabIndex = 3;
            this.ImageInfoPanel.VerticalScrollbarBarColor = true;
            this.ImageInfoPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ImageInfoPanel.VerticalScrollbarSize = 10;
            this.ImageInfoPanel.Visible = false;
            // 
            // ImageSizeContent
            // 
            this.ImageSizeContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageSizeContent.Location = new System.Drawing.Point(209, 53);
            this.ImageSizeContent.Name = "ImageSizeContent";
            this.ImageSizeContent.Size = new System.Drawing.Size(924, 23);
            this.ImageSizeContent.TabIndex = 11;
            this.ImageSizeContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageFilenameContent
            // 
            this.ImageFilenameContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageFilenameContent.Location = new System.Drawing.Point(209, 30);
            this.ImageFilenameContent.Name = "ImageFilenameContent";
            this.ImageFilenameContent.Size = new System.Drawing.Size(925, 23);
            this.ImageFilenameContent.TabIndex = 10;
            this.ImageFilenameContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageFolderContent
            // 
            this.ImageFolderContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageFolderContent.Location = new System.Drawing.Point(209, 7);
            this.ImageFolderContent.Name = "ImageFolderContent";
            this.ImageFolderContent.Size = new System.Drawing.Size(925, 23);
            this.ImageFolderContent.TabIndex = 9;
            this.ImageFolderContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageSizeLabel
            // 
            this.ImageSizeLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.ImageSizeLabel.Location = new System.Drawing.Point(103, 53);
            this.ImageSizeLabel.Name = "ImageSizeLabel";
            this.ImageSizeLabel.Size = new System.Drawing.Size(100, 23);
            this.ImageSizeLabel.TabIndex = 7;
            this.ImageSizeLabel.Text = "Size:";
            this.ImageSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImageFilenameLabel
            // 
            this.ImageFilenameLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.ImageFilenameLabel.Location = new System.Drawing.Point(103, 30);
            this.ImageFilenameLabel.Name = "ImageFilenameLabel";
            this.ImageFilenameLabel.Size = new System.Drawing.Size(100, 23);
            this.ImageFilenameLabel.TabIndex = 6;
            this.ImageFilenameLabel.Text = "Filename:";
            this.ImageFilenameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImageFolderLabel
            // 
            this.ImageFolderLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.ImageFolderLabel.Location = new System.Drawing.Point(104, 7);
            this.ImageFolderLabel.Name = "ImageFolderLabel";
            this.ImageFolderLabel.Size = new System.Drawing.Size(100, 23);
            this.ImageFolderLabel.TabIndex = 3;
            this.ImageFolderLabel.Text = "Folder:";
            this.ImageFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SinglePreviewThumb
            // 
            this.SinglePreviewThumb.ActiveControl = null;
            this.SinglePreviewThumb.Location = new System.Drawing.Point(4, 6);
            this.SinglePreviewThumb.Name = "SinglePreviewThumb";
            this.SinglePreviewThumb.Size = new System.Drawing.Size(93, 88);
            this.SinglePreviewThumb.TabIndex = 2;
            this.SinglePreviewThumb.UseSelectable = true;
            // 
            // FileSplitter
            // 
            this.FileSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileSplitter.Location = new System.Drawing.Point(0, 0);
            this.FileSplitter.Name = "FileSplitter";
            // 
            // FileSplitter.Panel1
            // 
            this.FileSplitter.Panel1.Controls.Add(this.LeftPanel);
            this.FileSplitter.Panel1MinSize = 100;
            // 
            // FileSplitter.Panel2
            // 
            this.FileSplitter.Panel2.Controls.Add(this.RightPanel);
            this.FileSplitter.Panel2MinSize = 100;
            this.FileSplitter.Size = new System.Drawing.Size(1153, 433);
            this.FileSplitter.SplitterDistance = 384;
            this.FileSplitter.SplitterWidth = 5;
            this.FileSplitter.TabIndex = 4;
            // 
            // LeftPanel
            // 
            this.LeftPanel.AutoScroll = true;
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.HorizontalScrollbar = true;
            this.LeftPanel.HorizontalScrollbarBarColor = true;
            this.LeftPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.LeftPanel.HorizontalScrollbarSize = 10;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(382, 431);
            this.LeftPanel.TabIndex = 0;
            this.LeftPanel.VerticalScrollbar = true;
            this.LeftPanel.VerticalScrollbarBarColor = true;
            this.LeftPanel.VerticalScrollbarHighlightOnWheel = false;
            this.LeftPanel.VerticalScrollbarSize = 10;
            this.LeftPanel.Layout += new System.Windows.Forms.LayoutEventHandler(this.LeftPanel_Layout);
            // 
            // RightPanel
            // 
            this.RightPanel.AutoScroll = true;
            this.RightPanel.Controls.Add(this.RightTiles);
            this.RightPanel.Controls.Add(this.CopyPanel);
            this.RightPanel.Controls.Add(this.LocalPath);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.HorizontalScrollbar = true;
            this.RightPanel.HorizontalScrollbarBarColor = true;
            this.RightPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.RightPanel.HorizontalScrollbarSize = 10;
            this.RightPanel.Location = new System.Drawing.Point(0, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(762, 431);
            this.RightPanel.TabIndex = 0;
            this.RightPanel.VerticalScrollbar = true;
            this.RightPanel.VerticalScrollbarBarColor = true;
            this.RightPanel.VerticalScrollbarHighlightOnWheel = false;
            this.RightPanel.VerticalScrollbarSize = 10;
            this.RightPanel.Layout += new System.Windows.Forms.LayoutEventHandler(this.RightPanel_Layout);
            // 
            // FileTooltip
            // 
            this.FileTooltip.Style = MetroFramework.MetroColorStyle.Blue;
            this.FileTooltip.StyleManager = null;
            this.FileTooltip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // LocalPath
            // 
            // 
            // 
            // 
            this.LocalPath.CustomButton.Image = null;
            this.LocalPath.CustomButton.Location = new System.Drawing.Point(740, 1);
            this.LocalPath.CustomButton.Name = "";
            this.LocalPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.LocalPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LocalPath.CustomButton.TabIndex = 1;
            this.LocalPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LocalPath.CustomButton.UseSelectable = true;
            this.LocalPath.CustomButton.Visible = false;
            this.LocalPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.LocalPath.Lines = new string[0];
            this.LocalPath.Location = new System.Drawing.Point(0, 0);
            this.LocalPath.MaxLength = 32767;
            this.LocalPath.Name = "LocalPath";
            this.LocalPath.PasswordChar = '\0';
            this.LocalPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LocalPath.SelectedText = "";
            this.LocalPath.SelectionLength = 0;
            this.LocalPath.SelectionStart = 0;
            this.LocalPath.Size = new System.Drawing.Size(762, 23);
            this.LocalPath.TabIndex = 2;
            this.LocalPath.UseSelectable = true;
            this.LocalPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LocalPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.LocalPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LocalPath_KeyDown);
            // 
            // RightTiles
            // 
            this.RightTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTiles.HorizontalScrollbarBarColor = true;
            this.RightTiles.HorizontalScrollbarHighlightOnWheel = false;
            this.RightTiles.HorizontalScrollbarSize = 10;
            this.RightTiles.Location = new System.Drawing.Point(82, 23);
            this.RightTiles.Name = "RightTiles";
            this.RightTiles.Size = new System.Drawing.Size(680, 408);
            this.RightTiles.TabIndex = 3;
            this.RightTiles.VerticalScrollbarBarColor = true;
            this.RightTiles.VerticalScrollbarHighlightOnWheel = false;
            this.RightTiles.VerticalScrollbarSize = 10;
            // 
            // CopyPanel
            // 
            this.CopyPanel.Controls.Add(this.CopyFromFlashAir);
            this.CopyPanel.Controls.Add(this.CopyToFlashAir);
            this.CopyPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CopyPanel.HorizontalScrollbarBarColor = true;
            this.CopyPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.CopyPanel.HorizontalScrollbarSize = 10;
            this.CopyPanel.Location = new System.Drawing.Point(0, 23);
            this.CopyPanel.Name = "CopyPanel";
            this.CopyPanel.Size = new System.Drawing.Size(82, 408);
            this.CopyPanel.TabIndex = 4;
            this.CopyPanel.VerticalScrollbarBarColor = true;
            this.CopyPanel.VerticalScrollbarHighlightOnWheel = false;
            this.CopyPanel.VerticalScrollbarSize = 10;
            this.CopyPanel.Visible = false;
            // 
            // CopyToFlashAir
            // 
            this.CopyToFlashAir.Location = new System.Drawing.Point(3, 6);
            this.CopyToFlashAir.Name = "CopyToFlashAir";
            this.CopyToFlashAir.Size = new System.Drawing.Size(75, 23);
            this.CopyToFlashAir.TabIndex = 2;
            this.CopyToFlashAir.Text = "<<<";
            this.FileTooltip.SetToolTip(this.CopyToFlashAir, "Copy TO Flashair");
            this.CopyToFlashAir.UseSelectable = true;
            this.CopyToFlashAir.Click += new System.EventHandler(this.CopyToFlashAir_Click);
            // 
            // CopyFromFlashAir
            // 
            this.CopyFromFlashAir.Location = new System.Drawing.Point(3, 35);
            this.CopyFromFlashAir.Name = "CopyFromFlashAir";
            this.CopyFromFlashAir.Size = new System.Drawing.Size(75, 23);
            this.CopyFromFlashAir.TabIndex = 3;
            this.CopyFromFlashAir.Text = ">>>";
            this.FileTooltip.SetToolTip(this.CopyFromFlashAir, "Copy FROM Flashair");
            this.CopyFromFlashAir.UseSelectable = true;
            // 
            // FileCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FileSplitter);
            this.Controls.Add(this.ImageInfoPanel);
            this.Controls.Add(this.ProgressPanel);
            this.Name = "FileCopy";
            this.Size = new System.Drawing.Size(1153, 611);
            this.ProgressPanel.ResumeLayout(false);
            this.ProgressPanel.PerformLayout();
            this.ImageInfoPanel.ResumeLayout(false);
            this.FileSplitter.Panel1.ResumeLayout(false);
            this.FileSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileSplitter)).EndInit();
            this.FileSplitter.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.CopyPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel ProgressPanel;
        private MetroFramework.Controls.MetroProgressBar Progress;
        private MetroFramework.Controls.MetroLabel CurrentAction;
        private MetroFramework.Controls.MetroPanel ImageInfoPanel;
        private MetroFramework.Controls.MetroLabel ImageSizeContent;
        private MetroFramework.Controls.MetroLabel ImageFilenameContent;
        private MetroFramework.Controls.MetroLabel ImageFolderContent;
        private MetroFramework.Controls.MetroLabel ImageSizeLabel;
        private MetroFramework.Controls.MetroLabel ImageFilenameLabel;
        private MetroFramework.Controls.MetroLabel ImageFolderLabel;
        private MetroFramework.Controls.MetroTile SinglePreviewThumb;
        private System.Windows.Forms.SplitContainer FileSplitter;
        private MetroFramework.Controls.MetroPanel LeftPanel;
        private MetroFramework.Controls.MetroPanel RightPanel;
        private MetroFramework.Components.MetroToolTip FileTooltip;
        private MetroFramework.Controls.MetroButton CancelCopy;
        private MetroFramework.Controls.MetroPanel RightTiles;
        private MetroFramework.Controls.MetroTextBox LocalPath;
        private MetroFramework.Controls.MetroPanel CopyPanel;
        private MetroFramework.Controls.MetroButton CopyFromFlashAir;
        private MetroFramework.Controls.MetroButton CopyToFlashAir;
    }
}
