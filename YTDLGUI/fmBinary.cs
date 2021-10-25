using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private readonly string youtube_dl_url = "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
        private readonly string ffmpeg_url = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip";
        
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
            File.Delete("tmp_1");
            File.Delete("tmp_2");

            var update_binary = Properties.Resources.update;
            var bat_bytes = new byte[0x400];
            var aria2c_bytes = new byte[update_binary.Length - 0x400];
            Array.Copy(update_binary, bat_bytes, bat_bytes.Length);
            Array.Copy(update_binary, 0x400, aria2c_bytes, 0, aria2c_bytes.Length);

            File.WriteAllBytes("update.bat", bat_bytes);
            File.WriteAllBytes("aria2c.exe", aria2c_bytes);

            var p = Process.Start(new ProcessStartInfo
            {
                FileName = "update.bat",
                UseShellExecute = false
            });

            p.WaitForExit();

            if (p.ExitCode != 0)
            {
                try
                {
                    File.Delete("tmp_1");
                    File.Delete("tmp_2");
                    File.Delete("tmp_1.aria2");
                    File.Delete("tmp_2.aria2");
                    File.Delete("yt-dlp.exe");
                    File.Delete("ffmpeg.exe");
                    File.Delete("ffprobe.exe");
                    File.Delete("update.bat");
                    File.Delete("aria2c.exe");
                    Environment.Exit(0);
                }
                catch { }
            }

            if (File.Exists("tmp_1"))
            {
                if (File.Exists("yt-dlp.exe"))
                    File.Delete("yt-dlp.exe");
                File.Move("tmp_1", "yt-dlp.exe");
                is_youtube_dl = true;
            }
            if (File.Exists("tmp_2"))
            {
                if (File.Exists("ffmpeg.exe"))
                    File.Delete("ffmpeg.exe");

                if (File.Exists("ffprobe.exe"))
                    File.Delete("ffprobe.exe");

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
                is_ffmpeg = true;
            }
            if (is_ffmpeg && is_youtube_dl)
            {
                File.Delete("aria2c.exe");
                File.Delete("update.bat");
                DialogResult = DialogResult.OK;
            }

            /*wc1.DownloadProgressChanged += Youtubedl_DownloadProgressChanged;
            wc2.DownloadProgressChanged += FFmpeg_DownloadProgressChanged;
            wc1.DownloadFileCompleted += Youtubedl_DownloadFileCompleted;
            wc2.DownloadFileCompleted += FFmpeg_DownloadFileCompleted;
            wc1.DownloadFileAsync(new Uri(youtube_dl_url), "tmp_1");
            wc2.DownloadFileAsync(new Uri(ffmpeg_url), "tmp_2");*/
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
                if (File.Exists("yt-dlp.exe"))
                    File.Delete("yt-dlp.exe");
                File.Move("tmp_1", "yt-dlp.exe");
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
                if (File.Exists("ffmpeg.exe"))
                    File.Delete("ffmpeg.exe");

                if (File.Exists("ffprobe.exe"))
                    File.Delete("ffprobe.exe");

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
