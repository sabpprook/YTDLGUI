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
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTDLGUI
{
    public partial class fmGUI : MaterialForm
    {
        Properties.Settings settings { get; } = Properties.Settings.Default;
        ListViewItem currentItem { get; set; }
        string listCounter { get; set; }
        DateTimeOffset updateTime { get; set; } = DateTimeOffset.Now;
        bool IsAbort { get; set; }

        public fmGUI()
        {
            InitializeComponent();
            Icon = Properties.Resources.ICON;
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Red900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);
        }

        private void fmGUI_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckBinary())
            {
                var frm = new fmBinary();
                var result = frm.ShowDialog();
                if (result != DialogResult.OK)
                    Environment.Exit(0);
            }

            if (string.IsNullOrEmpty(settings.DownloadFolder))
                settings.DownloadFolder = Environment.CurrentDirectory;

            textFolder.Text = settings.DownloadFolder;

            var vformat = settings.VidoeFormat;
            radioVDefault.Checked = vformat == (int)VideoFormat.Default;
            radioVMP4.Checked = vformat == (int)VideoFormat.MP4;
            radioVWebm.Checked = vformat == (int)VideoFormat.Webm;

            comboAFormat.SelectedIndex = settings.AudioFormat;
            comboAQuality.SelectedIndex = settings.AudioQuality;
            checkPlaylist.Checked = settings.IsPlaylist;
            checkMaxRes.Checked = settings.IsMaxResolution;
            comboMaxRes.SelectedIndex = settings.MaxResolution;
            checkLiveFromStart.Checked = settings.IsLiveFromStart;
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

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 2)
            {
                buttonDownload.Visible = false;
                buttonAbort.Visible = false;
                buttonClear.Visible = false;
            }
            else
            {
                buttonDownload.Visible = true;
                buttonAbort.Visible = true;
                buttonClear.Visible = true;
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
            comboAQuality.Enabled = Utils.QualityAdjustable(idx);
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

        private void labelLiveFromStart_Click(object sender, EventArgs e)
        {
            checkLiveFromStart.Checked = !checkLiveFromStart.Checked;
            settings.IsLiveFromStart = checkLiveFromStart.Checked;
        }

        private void labelUseAria2c_Click(object sender, EventArgs e)
        {
            checkUseAria2c.Checked = !checkUseAria2c.Checked;
        }

        private void checkUseAria2c_CheckedChanged(object sender, EventArgs e)
        {
            if (!File.Exists("aria2c.exe"))
            {
                if (!checkUseAria2c.Checked) Process.Start(Utils.aria2);
                checkUseAria2c.Checked = false;
            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            File.Delete("yt-dlp.exe");
            File.Delete("ffmpeg.exe");
            File.Delete("ffprobe.exe");
            var GUIFile = Process.GetCurrentProcess().MainModule.FileName;
            try
            {
                var http = new HttpClient();
                var bytes = await http.GetByteArrayAsync(Utils.gui);
                File.Move(GUIFile, GUIFile + ".old");
                File.WriteAllBytes(GUIFile, bytes);
            }
            catch { }
            Process.Start(GUIFile);
            Environment.Exit(0);
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            IsAbort = true;
            var target = new string[] { "ffmpeg.exe", "ffprobe.exe", "yt-dlp.exe", "aria2c.exe" };
            var plist = Process.GetProcesses().Where(p =>
            {
                try
                {
                    return p.MainModule.FileName.Contains(Environment.CurrentDirectory) &&
                    target.Contains(p.MainModule.ModuleName);
                }
                catch { return false; }
            }).ToArray();
            foreach (var p in plist) p.Kill();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            var list = listView.Items.Cast<ListViewItem>().Where(x => string.IsNullOrEmpty(x.SubItems[6].Text)).ToList();
            foreach (var item in list)
            {
                listView.Items.Remove(item);
            }
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            var mode = tabControl.SelectedIndex;
            foreach (string url in textURL.Lines)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    if (listView.Items.Cast<ListViewItem>().Where(x => x.SubItems[6].Text.Contains(url)).Count() > 0) continue;
                    var parameter = GetDownloadParameter(mode);
                    var item = new ListViewItem(new string[] { url, "--", "--", "--", "--", "準備中", $"{parameter} \"{url}\"" });
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
                    listCounter = string.Empty;
                    title.Text = await Task.Run(() => GetTitle(title.Text));
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
            sb.Append("--encoding \"UTF-8\" --no-warnings --ignore-errors");
            sb.Append($" -N {numUpDown_MT_fragment.Value} --embed-subs --compat-options no-live-chat --embed-thumbnail --embed-metadata --embed-chapters");
            sb.Append(checkPlaylist.Checked ? " --yes-playlist" : " --no-playlist");
            sb.Append(checkLiveFromStart.Checked ? " --live-from-start" : string.Empty);
            sb.Append(checkUseAria2c.Checked ? " --downloader aria2c" : string.Empty);
            sb.Append($" -o \"{settings.DownloadFolder}\\%(title)s.%(ext)s\"");
            if (mode == 0)
            {
                sb.Append(" -f \"bestvideo");
                if (checkMaxRes.Checked) sb.Append($"[height<={comboMaxRes.Text.Replace("p", "")}]");
                if (radioVDefault.Checked) sb.Append($"+bestaudio");
                if (radioVMP4.Checked) sb.Append($"[ext=mp4]+bestaudio[ext=m4a]");
                if (radioVWebm.Checked) sb.Append($"[ext=webm]+bestaudio[ext=webm]");
                sb.Append("/best\"");
                return sb.ToString();
            }
            if (mode == 1)
            {
                sb.Append(" -f \"bestaudio/best\" --extract-audio");
                sb.Append($" --audio-format {comboAFormat.Text}");
                sb.Append($" --audio-quality {(comboAQuality.Enabled ? comboAQuality.Text : "0")}");
                return sb.ToString();
            }
            return string.Empty;
        }

        private string GetTitle(string url)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "yt-dlp.exe";
                p.StartInfo.Arguments = $"--encoding \"UTF-8\" --print title \"{url}\"";
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
            Debug.WriteLine($"yt-dlp.exe {parameter}");
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "yt-dlp.exe";
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

        private async void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var text = e.Data;
            Debug.WriteLine(text);
            if (string.IsNullOrEmpty(text) || text.ToLower().Contains("unknown")) return;

            var title = currentItem.SubItems[0];
            var size = currentItem.SubItems[1];
            var progress = currentItem.SubItems[2];
            var speed = currentItem.SubItems[3];
            var ETA = currentItem.SubItems[4];
            var status = currentItem.SubItems[5];

            if (text.ToLower().Contains("extract") || text.ToLower().Contains("ffmpeg"))
            {
                Invoke(new Action(() => status.Text = "轉檔中..."));
                return;
            }

            var _ = await Task.Run(() => Utils.ParseListCounter(text));
            if (_.success) listCounter = _.counter;

            if (!string.IsNullOrEmpty(listCounter))
            {
                var filename = await Task.Run(() => Utils.ParseFilename(text));
                if (!string.IsNullOrEmpty(filename))
                {
                    Invoke(new Action(() => title.Text = $"{listCounter} {filename}"));
                    return;
                }
            }

            if (Utils.DeltaTime(updateTime) > 200)
            {
                var result = await Task.Run(() => Utils.ParseProgress(text));
                if (!string.IsNullOrEmpty(result.progress))
                {
                    Invoke(new Action(() =>
                    {
                        progress.Text = result.progress;
                        size.Text = result.size;
                        speed.Text = result.speed;
                        ETA.Text = result.ETA;
                        status.Text = "下載中...";
                    }));
                }
                updateTime = DateTimeOffset.Now;
            }
        }
    }
}
