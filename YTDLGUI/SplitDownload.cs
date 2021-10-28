using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YTDLGUI
{
    public class SplitDownload
    {
        private string URL { get; set; }
        private string Filename { get; set; }
        private Stream FileHandler { get; set; }
        private int Split { get; set; }
        private long TotalBytes { get; set; }
        private long CurrentBytes { get; set; }
        public bool isDone { get; private set; }
        private object locker = new object();

        public SplitDownload()
        {
            ServicePointManager.DefaultConnectionLimit = 200;
        }

        public void DownloadFileAsync(string url, string filename, int split = 8)
        {
            Task.Run(() =>
            {
                URL = url;
                Filename = filename;
                Split = split;
                TotalBytes = ContentLength();
                FileHandler = File.Create(Filename);
                CreateTask();
            });
        }

        public string GetProgress()
        {
            return (Convert.ToDouble(CurrentBytes + 1) / Convert.ToDouble(TotalBytes)).ToString("P0");
        }

        private long ContentLength()
        {
            var request = WebRequest.Create(URL) as HttpWebRequest;
            request.Method = "HEAD";
            var response = request.GetResponse() as HttpWebResponse;
            var length = response.StatusCode == HttpStatusCode.OK ? response.ContentLength : 0L;
            response.Close();
            return length;
        }

        private Task[] CreateTask()
        {
            var tasks = new List<Task>();

            var range = TotalBytes / Split;

            for (int i = 0; i < Split; i++)
            {
                var start = i * range;
                var end = (i + 1) * range - 1;

                if (i == Split - 1)
                    end = TotalBytes - 1;

                var block = new Range(start, end);

                tasks.Add(Task.Run(() =>
                {
                    DownloadRange(URL, block);
                }));
            }

            return tasks.ToArray();
        }

        private void DownloadRange(string url, Range range)
        {
            var req = WebRequest.Create(url) as HttpWebRequest;
            req.AddRange(range.Start, range.End);
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0";

            var resp = req.GetResponse();

            var length = resp.ContentLength;
            var stream = resp.GetResponseStream();

            var buffer = new byte[1024];
            long index = 0;
            do
            {
                var bytes = stream.Read(buffer, 0, buffer.Length);
                lock (locker)
                {
                    FileHandler.Position = range.Start + index;
                    FileHandler.Write(buffer, 0, bytes);
                    CurrentBytes += bytes;
                }
                index += bytes;
            } while (index < length);

            if (CurrentBytes == TotalBytes)
            {
                isDone = true;
                FileHandler.Close();
            }
        }

        public class Range
        {
            public long Start { get; set; }
            public long End { get; set; }
            public Range(long start, long end)
            {
                Start = start;
                End = end;
            }
        }
    }
}
