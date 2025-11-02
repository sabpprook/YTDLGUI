using System.Text.RegularExpressions;

namespace YTDLPGUI.Utils
{
    internal class Helper
    {
        public static long GetSize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var m = Regex.Match(text.Trim(), @"(\d+\.?\d+)(KiB|MiB|GiB)");
            if (!m.Success)
                return 0;

            var number = m.Groups[1].Value;

            if (!decimal.TryParse(number, out decimal value))
                return 0;

            var unit = m.Groups[2].Value.ToUpper();

            var multiplier = unit switch
            {
                "KIB" => 1024m,
                "MIB" => 1024m * 1024m,
                "GIB" => 1024m * 1024m * 1024m,
                _ => 1m,
            };

            var size = value * multiplier;

            return (long)size;
        }

        public static string FormatSize(long size)
        {
            const decimal KiB = 1024m;
            const decimal MiB = KiB * 1024m;
            const decimal GiB = MiB * 1024m;

            if (size >= GiB)
                return string.Format("{0:0.00} GiB", size / GiB);
            if (size >= MiB)
                return string.Format("{0:0.00} MiB", size / MiB);
            if (size >= KiB)
                return string.Format("{0:0.00} KiB", size / KiB);

            return $"{size} B";
        }
    }
}
