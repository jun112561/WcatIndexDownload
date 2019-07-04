using System;
using System.Net;
using System.IO;
using AssetStudio;

namespace 清單下載器
{
    public class DownloadInfo
    {
        private string URL = "", SavePath = "";
        public bool IsDone { get; private set; }
        public bool IsCancelled { get; private set; }
        public string FileName { get; private set; }
        public string Error { get; private set; }
        public int KBytesReceived { get; private set; }
        public int TotalKBytesToReceive { get; private set; }
        public WebClient WC = new WebClient();
        private Form1 form = null;

        public DownloadInfo(string URL, string SavePath, Form1 form, string FileName = "")
        {
            IsDone = false;
            IsCancelled = false;
            this.URL = URL;
            this.SavePath = SavePath;
            if (FileName != "") this.FileName = FileName;
            else this.FileName = Path.GetFileName(URL);
            this.form = form;
        }

        public void StartDownload()
        {
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
                        catch (Exception) {  }
                    }
                }
                IsCancelled = e.Cancelled;
                if (!IsCancelled) Error = (e.Error != null ? e.Error.Message : "");
                IsDone = true;
                WC.Dispose();
                WC = null;
            });
            WC.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sender, e) =>
            {
                KBytesReceived = (int)(e.BytesReceived / 1024);
                TotalKBytesToReceive = (int)(e.TotalBytesToReceive / 1024);
            });

            if (!File.Exists("Temp\\" + FileName)) WC.DownloadDataAsync(new Uri(URL));
            else { IsDone = true; IsCancelled = false; Error = ""; WC.Dispose(); }
        }
    }
}
