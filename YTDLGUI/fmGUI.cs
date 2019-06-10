using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTDLGUI
{
    public partial class fmGUI : MaterialForm
    {
        Properties.Settings settings = Properties.Settings.Default;
        ListViewItem currentItem { get; set; }
        bool IsAbort { get; set; }
        string PlayListCount { get; set; }

        public fmGUI()
        {
            InitializeComponent();
            Icon = Properties.Resources.ICON;
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Red900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);
        }

        private void fmGUI_Load(object sender, EventArgs e)
        {
            bool isBinary = File.Exists("youtube-dl.exe") && File.Exists("ffmpeg.exe") && File.Exists("ffprobe.exe");
            if (!isBinary)
            {
                var fmBin = new fmBinary();
                var result = fmBin.ShowDialog();
                if (result != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
            if (string.IsNullOrEmpty(settings.DownloadFolder))
            {
                settings.DownloadFolder = Environment.CurrentDirectory;
            }
            textFolder.Text = settings.DownloadFolder;
            switch (settings.VidoeFormat)
            {
                case 0:
                    radioVDefault.Checked = true;
                    break;
                case 1:
                    radioVMP4.Checked = true;
                    break;
                case 2:
                    radioVWebm.Checked = true;
                    break;
                default:
                    break;
            }
            comboAFormat.SelectedIndex = settings.AudioFormat;
            comboAQuality.SelectedIndex = settings.AudioQuality;
            checkPlaylist.Checked = settings.IsPlaylist;
            checkMaxRes.Checked = settings.IsMaxResolution;
            comboMaxRes.SelectedIndex = settings.MaxResolution;
        }

        private void fmGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            settings.Save();
        }

        private void labelAuthor_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/profile.php?id=100005653172695");
        }

        private void labelFolder_Click(object sender, EventArgs e)
        {
            Process.Start(textFolder.Text);
        }

        private void textFolder_MouseClick(object sender, MouseEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    settings.DownloadFolder = fbd.SelectedPath;
                    textFolder.Text = settings.DownloadFolder;
                }
            }
        }

        private void radioVideoFormat_CheckedChanged(object sender, EventArgs e)
        {
            var obj = (MaterialRadioButton)sender;
            settings.VidoeFormat = int.Parse(obj.Tag.ToString());
        }

        private void comboAFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = comboAFormat.SelectedIndex;
            comboAQuality.Enabled = (idx != 0 && idx != 4 && idx != 5);
            settings.AudioFormat = idx;
        }

        private void comboAQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.AudioQuality = comboAQuality.SelectedIndex;
        }

        private void labelPlaylist_Click(object sender, EventArgs e)
        {
            checkPlaylist.Checked = !checkPlaylist.Checked;
            settings.IsPlaylist = checkPlaylist.Checked;
        }

        private void labelMaxRes_Click(object sender, EventArgs e)
        {
            checkMaxRes.Checked = !checkMaxRes.Checked;
        }

        private void checkMaxRes_CheckedChanged(object sender, EventArgs e)
        {
            comboMaxRes.Enabled = checkMaxRes.Checked;
            settings.IsMaxResolution = checkMaxRes.Checked;
        }

        private void comboMaxRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.MaxResolution = comboMaxRes.SelectedIndex;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            File.Delete("youtube-dl.exe");
            File.Delete("ffmpeg.exe");
            File.Delete("ffprobe.exe");
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            Environment.Exit(0);
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            IsAbort = true;
            var plist = Process.GetProcessesByName("ffmpeg");
            foreach (var p in plist) p.Kill();
            plist = Process.GetProcessesByName("ffprobe");
            foreach (var p in plist) p.Kill();
            plist = Process.GetProcessesByName("youtube-dl");
            foreach (var p in plist) p.Kill();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 2)
            {
                tabControl.SelectedIndex = 0;
                return;
            }
            var mode = tabControl.SelectedIndex;
            foreach (string url in textURL.Lines)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    var parameter = GetDownloadParameter(mode);
                    var item = new ListViewItem(new string[] { url , "--", "--", "--", "--", "準備中", url + parameter });
                    listView.Items.Add(item);
                }
            }
            buttonDownload.Enabled = false;
            foreach (ListViewItem item in listView.Items)
            {
                currentItem = item;
                var title = item.SubItems[0];
                var status = item.SubItems[5];
                var parameter = item.SubItems[6];
                if (!string.IsNullOrEmpty(parameter.Text))
                {
                    buttonAbort.Enabled = true;
                    title.Text = await Task.Run(() => GetTitle(title.Text));
                    PlayListCount = "";
                    await Task.Run(() => Download(parameter.Text));
                    status.Text = "下載完成";
                    parameter.Text = null;
                    currentItem = null;
                    buttonAbort.Enabled = false;
                    if (IsAbort)
                    {
                        status.Text = "中止下載";
                        IsAbort = false;
                        break;
                    }
                }
            }
            System.Media.SystemSounds.Asterisk.Play();
            buttonDownload.Enabled = true;
        }

        private string GetDownloadParameter(int mode)
        {
            var sb = new StringBuilder();
            sb.Append("--encoding \"UTF-8\"");
            sb.Append(checkPlaylist.Checked ? " --ignore-errors --yes-playlist" : " --no-playlist");
            sb.Append($" -o \"{settings.DownloadFolder}\\%(title)s.%(ext)s\"");
            if (mode == 0)
            {
                sb.Append(" -f bestvideo");
                if (checkMaxRes.Checked) sb.Append($"[height<={comboMaxRes.Text.Replace("p", "")}]");
                if (radioVDefault.Checked) sb.Append($"+bestaudio");
                if (radioVMP4.Checked) sb.Append($"[ext=mp4]+bestaudio[ext=m4a]");
                if (radioVWebm.Checked) sb.Append($"[ext=webm]+bestaudio[ext=webm]");
                return sb.ToString();
            }
            else if (mode == 1)
            {
                sb.Append(" --extract-audio");
                sb.Append($" --audio-format {comboAFormat.Text}");
                sb.Append($" --audio-quality {(comboAQuality.Enabled ? comboAQuality.Text : "0")}");
                sb.Append(" -f bestaudio");
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

        private string GetTitle(string url)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "youtube-dl.exe";
                p.StartInfo.Arguments = url + " --no-playlist --get-title --encoding \"UTF-8\"";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                p.WaitForExit();
                return p.StandardOutput.ReadLine();
            }
        }

        private void Download(string parameter)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "youtube-dl.exe";
                p.StartInfo.Arguments = parameter;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                p.StartInfo.RedirectStandardOutput = true;
                p.OutputDataReceived += OutputDataReceived;
                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();
            }
        }

        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var text = e.Data;
            if (!string.IsNullOrEmpty(text) && !text.ToLower().Contains("unknown"))
            {
                var title = currentItem.SubItems[0];
                var size = currentItem.SubItems[1];
                var progress = currentItem.SubItems[2];
                var speed = currentItem.SubItems[3];
                var ETA = currentItem.SubItems[4];
                var status = currentItem.SubItems[5];
                var match = Regex.Match(text, "\\[download\\] Downloading video (\\d+) of (\\d+)");
                if (match.Success)
                {
                    PlayListCount = $"[{match.Groups[1].Value}/{match.Groups[2].Value}]";
                }
                if (!string.IsNullOrEmpty(PlayListCount))
                {
                    match = Regex.Match(text, "\\[download\\] Destination: (.+)");
                    if (match.Success)
                    {
                        Invoke(new Action(() =>
                        {
                            title.Text = $"{PlayListCount} {Path.GetFileNameWithoutExtension(match.Groups[1].Value)}";
                        }));
                    }
                }
                match = Regex.Match(text, "\\[download\\](.+)of(.+)at(.+)ETA(.+)");
                if (match.Success)
                {
                    Invoke(new Action(() =>
                    {
                        status.Text = "下載中...";
                        progress.Text = match.Groups[1].Value.Replace(" ", "");
                        size.Text = match.Groups[2].Value.Replace(" ", "").Replace("iB", "B");
                        speed.Text = match.Groups[3].Value.Replace(" ", "").Replace("iB", "B");
                        ETA.Text = match.Groups[4].Value.Replace(" ", "");
                    }));
                }
                if (text.ToLower().Contains("ffmpeg"))
                {
                    Invoke(new Action(() =>
                    {
                        status.Text = "轉檔中...";
                    }));
                }
            }
        }
    }
}
