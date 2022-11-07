using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YTDLGUI
{
    public enum AudioCodec : int
    {
        Best = 0,
        M4A = 1,
        MP3 = 2,
        Vorbis = 3,
        FLAC = 4,
        WAV = 5
    }

    public enum VideoFormat : int
    {
        Default = 0,
        MP4 = 1,
        Webm = 2
    }

    public class Utils
    {
        public static string gui { get; } = "https://github.com/sabpprook/YTDLGUI/releases/latest/download/YTDLGUI.exe";
        public static string aria2 { get; } = "https://github.com/aria2/aria2/releases/latest";
        public static string ytdlp { get; } = "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
        public static string ffmpeg { get; } = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip";

        public static bool CheckBinary()
        {
            return File.Exists("yt-dlp.exe") &&
                File.Exists("ffmpeg.exe") &&
                File.Exists("ffprobe.exe");
        }

        public static bool QualityAdjustable(int codec)
        {
            return codec != (int)AudioCodec.Best &&
                codec != (int)AudioCodec.FLAC &&
                codec != (int)AudioCodec.WAV;
        }

        public static (bool success, string counter) ParseListCounter(string text)
        {
            var _ = Regex.Match(text, "ownloading ?video ?(\\d+) ?of ?(\\d+)");
            return (_.Success, _.Success ? $"[{_.Groups[1].Value}/{_.Groups[2].Value}]" : string.Empty);
        }

        public static string ParseFilename(string text)
        {
            var _ = Regex.Match(text, "estination: ?(.+)");
            return _.Success ? Path.GetFileNameWithoutExtension(_.Groups[1].Value) : string.Empty;
        }

        public static int DeltaTime(DateTimeOffset time)
        {
            return DateTimeOffset.Now.Subtract(time).Milliseconds;
        }

        public static (string progress, string size, string speed, string ETA) ParseProgress(string text)
        {
            string progress = string.Empty, size = string.Empty, speed = string.Empty, ETA = string.Empty;
            // normal output
            var match = Regex.Match(text, "\\[download\\](.+)of(.+)at(.+)ETA(.+)");
            if (match.Success)
            {
                progress = match.Groups[1].Value.Replace(" ", "");
                size = match.Groups[2].Value.Replace(" ", "").Replace("iB", "B");
                speed = match.Groups[3].Value.Replace(" ", "").Replace("iB", "B");
                ETA = match.Groups[4].Value.Replace(" ", "");
                return (progress, size, speed, ETA);
            }

            // fragment output
            match = Regex.Match(text, "\\[download\\](.+)at(.+)\\((.+)\\) \\((.+)\\)");
            if (match.Success)
            {
                progress = match.Groups[4].Value;
                size = match.Groups[1].Value.Replace(" ", "").Replace("iB", "B");
                speed = match.Groups[2].Value.Replace(" ", "").Replace("iB", "B");
                return (progress, size, speed, ETA);
            }

            // aria2c output
            match = Regex.Match(text, "\\[.+\\/([^\\(]+)\\((.+)\\).+DL:(.+)ETA:(.+)\\]");
            if (match.Success)
            {
                progress = match.Groups[2].Value.Replace(" ", "");
                size = match.Groups[1].Value.Replace(" ", "").Replace("iB", "B");
                speed = match.Groups[3].Value.Replace(" ", "").Replace("iB", "B") + "/s";
                ETA = match.Groups[4].Value.Replace(" ", "");
                return (progress, size, speed, ETA);
            }
            return (progress, size, speed, ETA);
        }
    }
}
