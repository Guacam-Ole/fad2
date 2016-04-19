using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using fad2.Backend;
using MetroFramework;
using MetroFramework.Controls;

namespace fad2.UI
{
    public partial class AutoMode : MetroUserControl
    {
        public AutoMode()
        {
            InitializeComponent();
            _connection = new Connection(_programSettingsFile);
        }

        private const int _maxThumbnailSize= 3145728;  // Above this images won't be loaded for local Thumbs; 3MB

        
        private readonly string _programSettingsFile =
           $"{Application.StartupPath}\\{Properties.Settings.Default.ProgramSettingsFile}";


        private Connection _connection;

        public void LoadContents(string flashairPath, string localPath)
        {
            LeftPanel.Controls.Clear();
            LoadLocalContents(localPath);
            LoadFlashairInfo(flashairPath);
            LoadFlashAirThumbs();
            CurrentAction.Text = $"Done reading File Information from Flashair. Ready to copy new files.";
            StartCopy.Visible = true;

        }

        private const int _metroSize = 100;
        private const int _metroMargin =10;


        private void LoadFlashAirThumbs()
        {
            int counter = 0;
            var tiles = LeftPanel.Controls.OfType<MetroTile>();
            Progress.Maximum = tiles.Count();
            CurrentAction.Text = "Reading Thumbnails for Images on Flashair";
            foreach (var tile in tiles)
            {
                var fileInfo = (FlashAirFileInformation) tile.Tag;
                CurrentAction.Text = $"Reading Thumbnails for Images on Flashair [{counter} of {Progress.Maximum}]";
                Progress.Value = counter;
                TryGetFlashAirThumb(tile, fileInfo);
                tile.Refresh();
                Application.DoEvents();
                counter++;
            }
        }

        private void LoadFlashairInfo(string path)
        {
            // LeftPanel.Controls.Clear();
            CurrentAction.Text = $"Reading information from files from Flashair at path '{path}'";
            Application.DoEvents();
            int imageCount = _connection.GetFileCount(path);
            CurrentAction.Text = $"Reading information from {imageCount} files from Flashair at path '{path}'";
            Application.DoEvents();
            if (imageCount > 0)
            {
                
                List<FlashAirFileInformation> allFiles = _connection.GetFiles(path);
                // start with the directories:
                var nonHiddenfiles = allFiles.Where(af => !af.Hidden && !af.SystemFile).ToList();
                Progress.Maximum = nonHiddenfiles.Count();
                int counter = 0;
                foreach (var singleFile in nonHiddenfiles.Where(nhf=>nhf.IsVolume || nhf.IsDirectory))
                {
                    // there shouldn't really be any volumes on that disc, but why not be safe here?
                    Progress.Value = counter;
                    counter++;
                    Application.DoEvents();
                   
                    if (!path.EndsWith("/"))
                    {
                        path += '/';
                    }
                    LoadFlashairInfo(path+singleFile.Filename);
                }
                foreach (var singleFile in nonHiddenfiles.Where(nhf => !nhf.IsVolume && !nhf.IsDirectory))
                {
                    MetroTile tile = new MetroTile
                    {
                        Text = singleFile.Filename,
                        Width = _metroSize,
                        Height = _metroSize,
                        Tag = singleFile
                    };
                    tile.Click += LeftTile_Click;
                    FileTooltip.SetToolTip(tile, singleFile.Filename);
                    
                    LeftPanel.Controls.Add(tile);
                    Progress.Value = counter;
                    counter++;
                    tile.Refresh();
                    Application.DoEvents();
                }
            }
            ResizeTiles(LeftPanel);
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TryGetFlashAirThumb(MetroTile tile, FlashAirFileInformation fileInformation)
        {
            try
            {
                Image thumBitmap = _connection.DownloadThumbnail(fileInformation.Directory, fileInformation.Filename);
                if (thumBitmap == null)
                {
                    return;
                }
                Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Image thumb = thumBitmap.GetThumbnailImage(_metroSize, _metroSize, myCallback, IntPtr.Zero);
                tile.TileImage = thumb;
                tile.UseTileImage = true;
            }
            catch (Exception ex)
            {
                
            }
        }


        private void LoadLocalContents(string localPath)
        {
            CurrentAction.Text = "Loading local directory";
            if (Directory.Exists(localPath))
            {  
                var currentDirectory=new DirectoryInfo(localPath);
                var files = currentDirectory.GetFiles();
                var folders = currentDirectory.GetDirectories();

                RightPanel.Controls.Clear();
                Progress.Maximum = folders.Length;
                int counter = 0;
                foreach (var folder in folders.OrderBy(fld=>fld.Name))
                {
                    MetroTile tile = new MetroTile {Text = folder.Name, Width = _metroSize, Height = _metroSize, Style = MetroColorStyle.Yellow};
                    FileTooltip.SetToolTip(tile,folder.Name);
                    RightPanel.Controls.Add(tile);
                    Progress.Value = counter;
                    counter++;
                    Application.DoEvents();

                }
                Progress.Maximum = folders.Length;
                counter = 0;
                foreach (var file in files.OrderBy(fld => fld.Name))
                {
                    MetroTile tile = new MetroTile { Text = file.Name, Width = _metroSize, Height = _metroSize };
                    FileTooltip.SetToolTip(tile, file.Name);
                    TryGetThumb(tile, file);
                    RightPanel.Controls.Add(tile);
                    Progress.Value = counter;
                    counter++;
                    Application.DoEvents();
                }
            }
            ResizeTiles(RightPanel);
        }

        private bool ThumbnailCallback()
        {
            return false;
        }

        private void TryGetThumb(MetroTile tile, FileInfo fileInfo)
        {
            try
            {
                if (fileInfo.Length <= _maxThumbnailSize)
                {
                    string[] validExtensions = {"jpg", "jpeg", "png", "ping", "gif", "tif", "tiff"};
                    string extension = fileInfo.Name.Substring(fileInfo.Name.LastIndexOf('.') + 1).ToLower();
                    if (validExtensions.Contains(extension))
                    {
                        Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        Bitmap thumBitmap = new Bitmap(fileInfo.FullName);
                        Image thumb = thumBitmap.GetThumbnailImage(_metroSize, _metroSize, myCallback, IntPtr.Zero);
                        tile.TileImage = thumb;
                        tile.UseTileImage = true;
                    }

                }
            }
            catch (Exception ex)
            {
                // No valid Image File as it seems
            }
        }


        private void ResizeTiles(Control parentControl)
        {
            try
            {
                int maxWidth = parentControl.Width;
                if (maxWidth < _metroSize + _metroMargin)
                {
                    return;
                }
                int currentX = -_metroSize - _metroMargin;
                int currentY = 0;

                foreach (var control in parentControl.Controls.OfType<MetroTile>())
                {
                    if (currentX + _metroSize*2 + _metroMargin <= maxWidth)
                    {
                        currentX += _metroSize + _metroMargin;
                    }
                    else
                    {
                        currentY += _metroSize + _metroMargin;
                        currentX = 0;
                    }
                    control.Left = currentX + _metroMargin/2;
                    control.Top = currentY + _metroMargin/2;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void RightPanel_Resize(object sender, EventArgs e)
        {
            
            
        }

        private void RightPanel_Layout(object sender, LayoutEventArgs e)
        {
           ResizeTiles(RightPanel);
            this.Refresh();
        }

        private void LeftPanel_Layout(object sender, LayoutEventArgs e)
        {
            ResizeTiles(LeftPanel);
            this.Refresh();
        }

        private void StartCopy_Click(object sender, EventArgs e)
        {
            StartCopy.Visible = false;
        }

     
        private void LeftTile_Click(object sender, EventArgs e)
        {
            var tile = (MetroTile) sender;
            var fileData = (FlashAirFileInformation) tile.Tag;
            SinglePreviewThumb.TileImage = tile.TileImage;
            SinglePreviewThumb.UseTileImage = tile.UseTileImage;
            ImageFolderContent.Text = fileData.Directory;
            ImageFilenameContent.Text = fileData.Filename;
            ImageDownloadSwitch.Checked = false;

            double kbSize = (double)fileData.Size/1024;
            double mbSize = kbSize/1024;
            double gbSize = mbSize/1024;
             
            if (gbSize > 1)
            {
                ImageSizeContent.Text = $"{gbSize:N} GByte";
            } else if (mbSize > 1)
            {
                ImageSizeContent.Text = $"{mbSize:N} MByte";
            } else if (kbSize > 1)
            {
                ImageSizeContent.Text = $"{kbSize:N} KByte";
            }
            else
            {
                ImageSizeContent.Text = $"{fileData.Size} Byte";
            }
            ImageInfoPanel.Visible = true;
            SinglePreviewThumb.Refresh();
            Application.DoEvents();
        }
    }
}
