using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    }
}
