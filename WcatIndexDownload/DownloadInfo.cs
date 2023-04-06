using System;
using System.IO;
using System.Net;

namespace WcatIndexDownload
{
    public class DownloadInfo
    {
        public bool IsDone { get; private set; } = false;
        public bool IsCancelled { get; private set; } = false;
        public string FileName { get; private set; } = "";
        public string Error { get; private set; }
        public int KBytesReceived { get; private set; } = 0;
        public int TotalKBytesToReceive { get; private set; } = 0;

        public WebClient WC = new WebClient();

        public DownloadInfo(string URL, string SavePath, Form1 form, string FileName = "")
        {
            if (FileName != "") this.FileName = FileName;
            else this.FileName = Path.GetFileName(URL);

            WC.DownloadDataCompleted += new DownloadDataCompletedEventHandler((sender, e) =>
            {
                if (!e.Cancelled)
                {
                    if (e.Error == null)
                    {
                        try
                        {
                            File.WriteAllBytes(SavePath + "Unity3D\\" + FileName, e.Result);
                            form.extFile.Add(FileName);

                            if (!form.logForm.isColse)
                            {
                                if (form.logForm.InvokeRequired) form.logForm.BeginInvoke(new Action(delegate { form.logForm.richTextBox1.AppendText(FileName + " 下載完成\r\n"); }));
                                else form.logForm.richTextBox1.AppendText(FileName + " 下載完成\r\n");
                            }
                        }
                        catch (Exception) { }
                    }
                }
                IsCancelled = e.Cancelled;
                if (!IsCancelled) Error = (e.Error != null ? e.Error.Message : "");
                IsDone = true;
                WC.Dispose();
            });

            WC.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sender, e) =>
            {
                KBytesReceived = (int)(e.BytesReceived / 1024);
                TotalKBytesToReceive = (int)(e.TotalBytesToReceive / 1024);
            });

            if (!File.Exists("Temp\\" + FileName))
                WC.DownloadDataAsync(new Uri(URL));
            else
            {
                IsDone = true;
                WC.Dispose();
            }
        }
    }
}
