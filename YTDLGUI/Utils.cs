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
