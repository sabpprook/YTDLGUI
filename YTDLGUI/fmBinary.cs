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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTDLGUI
{
    public partial class fmBinary : MaterialSkin.Controls.MaterialForm
    {
        private bool is_ytdlp = false;
        private bool is_ffmpeg = false;

        public fmBinary()
        {
            InitializeComponent();
            Icon = Properties.Resources.ICON;
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Red900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);
        }

        private async void fmBinary_Load(object sender, EventArgs e)
        {
            File.Delete("tmp_1");
            File.Delete("tmp_2");

            var sd1 = new SplitDownload();
            var sd2 = new SplitDownload();
            sd1.DownloadFileAsync(Utils.ytdlp, "tmp_1");
            sd2.DownloadFileAsync(Utils.ffmpeg, "tmp_2", 16);

            await Task.Run(() =>
            {
                while (!sd1.isDone || !sd2.isDone)
                {
                    Invoke(new Action(() => label_Prog1.Text = $"[ {sd1.GetProgress()} ]"));
                    Invoke(new Action(() => label_Prog2.Text = $"[ {sd2.GetProgress()} ]"));
                    Thread.Sleep(100);
                }
            });

            if (File.Exists("tmp_1"))
            {
                if (File.Exists("yt-dlp.exe"))
                    File.Delete("yt-dlp.exe");
                File.Move("tmp_1", "yt-dlp.exe");
                is_ytdlp = true;
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
            if (is_ffmpeg && is_ytdlp)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
