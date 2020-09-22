using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTDLGUI
{
    public partial class fmBinary : MaterialSkin.Controls.MaterialForm
    {
        private readonly string youtube_dl_url = "https://yt-dl.org/downloads/latest/youtube-dl.exe";
        private readonly string ffmpeg_url = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-git-full.zip";
        private WebClient wc1 = new WebClient();
        private WebClient wc2 = new WebClient();
        private bool is_youtube_dl = false;
        private bool is_ffmpeg = false;

        public fmBinary()
        {
            InitializeComponent();
            Icon = Properties.Resources.ICON;
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Red900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);
        }

        private void fmBinary_Load(object sender, EventArgs e)
        {
            wc1.DownloadProgressChanged += Youtubedl_DownloadProgressChanged;
            wc2.DownloadProgressChanged += FFmpeg_DownloadProgressChanged;
            wc1.DownloadFileCompleted += Youtubedl_DownloadFileCompleted;
            wc2.DownloadFileCompleted += FFmpeg_DownloadFileCompleted;
            wc1.DownloadFileAsync(new Uri(youtube_dl_url), "tmp_1");
            wc2.DownloadFileAsync(new Uri(ffmpeg_url), "tmp_2");
        }

        private void Youtubedl_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var prog = e.ProgressPercentage;
            label_Prog1.Text = $"[ {prog.ToString().PadLeft(3, ' ')} % ]";
        }

        private void FFmpeg_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var prog = e.ProgressPercentage;
            label_Prog2.Text = $"[ {prog.ToString().PadLeft(3, ' ')} % ]";
        }

        private void Youtubedl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (File.Exists("tmp_1"))
            {
                File.Move("tmp_1", "youtube-dl.exe");
            }
            is_youtube_dl = true;
            if (is_ffmpeg)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void FFmpeg_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (File.Exists("tmp_2"))
            {
                using (var zipArchive = new ZipArchive(File.OpenRead("tmp_2"), ZipArchiveMode.Read))
                {
                    foreach (var entry in zipArchive.Entries)
                    {
                        if (entry.Name.Contains("ffmpeg.exe"))
                        {
                            using (var fs = new FileStream("ffmpeg.exe", FileMode.Create, FileAccess.Write))
                            {
                                entry.Open().CopyTo(fs);
                            }
                        }
                        if (entry.Name.Contains("ffprobe.exe"))
                        {
                            using (var fs = new FileStream("ffprobe.exe", FileMode.Create, FileAccess.Write))
                            {
                                entry.Open().CopyTo(fs);
                            }
                        }
                    }
                }
                File.Delete("tmp_2");
            }
            is_ffmpeg = true;
            if (is_youtube_dl)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
