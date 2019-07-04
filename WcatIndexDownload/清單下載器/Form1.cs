using AssetStudio;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 清單下載器.Properties;

namespace 清單下載器
{
    public partial class Form1 : Form
    {
        public Log logForm = new Log();
        Stopwatch SW = new Stopwatch();
        TaskbarManager tbManager = TaskbarManager.Instance;
        AutoResetEvent evtDownload = new AutoResetEvent(false);
        public List<string> extFile;
        bool isWorking;
        int RAM = 0;
        AssetsManager assetsManager = new AssetsManager();

        #region 檔案處理
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (FBO.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SavePath = FBO.SelectedPath;
                Directory_Read(FBO.SelectedPath);
            }
        }

        private void btn_FIle_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == DialogResult.OK) File_Read(OFD.FileName);
        }

        private bool File_Read(string File_path)
        {
            if (File_path == "")
            {
                MessageBox.Show("未選擇下載清單");
                return false;
            }
            if (!File.Exists(File_path))
            {
                MessageBox.Show("路徑錯誤，無檔案");
                return false;
            }
            txt_File.Text = File_path;
            lib_File.Items.Clear();
            lib_Error.Items.Clear();
            lib_File.BeginUpdate();
            foreach (string item in File.ReadAllLines(File_path)) lib_File.Items.Add(item.Replace(".", "_").Replace("/", "_").Split(new char[] { ',' })[0]);
            lib_File.EndUpdate();
            SetLabelText("下載檔案:無", lab_Download);
            SetProgressBarValue(0, PB_TotalFile);
            SetProgressBarValue(0, PB_SingleFile);
            SetProgressBarMaxValue(lib_File.Items.Count, PB_TotalFile);
            lab_Item.Text = "檔案數: " + lib_File.Items.Count;
            lab_ErrorItem.Text = "錯誤檔案數: 0";
            lab_DownItem.Text = "已下載數: 0";
            lab_Execute.Text = "解包: 無";
            btn_Start.Enabled = true;
            btn_Save_Error.Enabled = false;
            return true;
        }

        private void Directory_Read(string Directory_path)
        {
            if (Program.noCreateDirectory) txt_Save.Text = Directory_path + "\\";
            else txt_Save.Text = Directory_path + "\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + "\\";
            txt_Save.Text = txt_Save.Text.Replace("\\\\", "\\");
            SFD.InitialDirectory = Directory_path;
        }
        #endregion
        
        #region 委派
        private delegate void SetButton(bool Enable, Button Btn);
        private delegate void SetGroup(bool Enable, GroupBox GB);
        private delegate void SetToolStripLabel(string Text, ToolStripLabel Tool);
        private delegate void SetToolStripTextBox(bool enable);
        private delegate void SetLable(string Text, Label lab);
        private delegate void SetTool(bool enable, ToolStripMenuItem TSM);
        private delegate void SetTextBox(bool enable, ToolStripTextBox TST);
        private delegate void SetCheckBox(bool enable);
        private delegate void SetListItem(string Text, ListBox List);
        private delegate void SetProgressValue(int Value, ProgressBar PB);

        private void SetCheckBoxEnable(bool enable)
        {
            if (InvokeRequired)
            {
                Invoke(new SetCheckBox(SetCheckBoxEnable), new object[] { enable });
                return;
            }
            chb_Unity3d.Enabled = enable;
        }

        private void SetToolStripTextBoxEnable(bool enable)
        {
            if (InvokeRequired)
            {
                Invoke(new SetToolStripTextBox(SetToolStripTextBoxEnable), new object[] { enable });
                return;
            }
            TSM_Exclude.Enabled = enable;
        }

        private void SetTextBoxReadOnly(bool enable, ToolStripTextBox TST)
        {
            if (InvokeRequired)
            {
                Invoke(new SetTextBox(SetTextBoxReadOnly), new object[] { enable, TST });
                return;
            }
            TST.ReadOnly = enable;
        }

        private void SetGroupBoxEnable(bool Enable, GroupBox GB)
        {
            if (InvokeRequired)
            {
                Invoke(new SetGroup(SetGroupBoxEnable), new object[] { Enable, GB });
                return;
            }
            GB.Enabled = Enable;
        }

        private void SetToolStripMenuuItemEnable(bool Enable, ToolStripMenuItem TSM)
        {
            if (InvokeRequired)
            {
                Invoke(new SetTool(SetToolStripMenuuItemEnable), new object[] { Enable, TSM });
                return;
            }
            TSM.Enabled = Enable;
        }

        private void SetButtonEnable(bool Enable, Button Btn)
        {
            if (InvokeRequired)
            {
                Invoke(new SetButton(SetButtonEnable), new object[] { Enable, Btn });
                return;
            }
            Btn.Enabled = Enable;
        }

        private void SetLabelText(string Text, Label lab)
        {
            if (InvokeRequired)
            {
                Invoke(new SetLable(SetLabelText), new object[] { Text, lab });
                return;
            }
            lab.Text = Text;
        }

        private void SetToolStripLabelText(string Text, ToolStripLabel Tool)
        {
            if (InvokeRequired)
            {
                Invoke(new SetToolStripLabel(SetToolStripLabelText), new object[] { Text, Tool });
                return;
            }
            Tool.Text = Text;
            if (Tool == lab_Execute && !logForm.isColse) logForm.richTextBox1.AppendText(Text + "\r\n");
        }

        private void AddListBoxItem(string Text, ListBox List)
        {
            if (InvokeRequired)
            {
                Invoke(new SetListItem(AddListBoxItem), new object[] { Text, List });
                return;
            }
            List.Items.Add(Text);
        }

        private void DelListBox(string Text, ListBox List)
        {
            if (InvokeRequired)
            {
                Invoke(new SetListItem(DelListBox), new object[] { Text, List });
                return;
            }
            List.Items.Remove(Text);
        }

        private void SetProgressBarValue(int Value, ProgressBar PB)
        {
            //lock (PB)
            //{
            if (Value > PB.Maximum) return;
            if (InvokeRequired)
            {
                Invoke(new SetProgressValue(SetProgressBarValue), new object[] { Value, PB });
                return;
            }
            PB.Value = Value;
            //}
        }

        private void SetProgressBarMaxValue(int Value, ProgressBar PB)
        {
            if (InvokeRequired)
            {
                Invoke(new SetProgressValue(SetProgressBarMaxValue), new object[] { Value, PB });
                return;
            }
            PB.Maximum = Value;
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
            extFile = new List<string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Program.filePath != "") File_Read(Program.filePath);
            if (Program.directoryPath != "") Directory_Read(Program.directoryPath);
            else if (Settings.Default.SavePath == "") Directory_Read(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            else Directory_Read(Settings.Default.SavePath);
            if (Program.exclude != "") TSM_Exclude.Text = Program.exclude;
            else TSM_Exclude.Text = Settings.Default.exclude;
            TST_DLLength.Text = Settings.Default.DLLength;
            txt_URL.Text = Settings.Default.URL;
            TSM_UnPrefab.Checked = Settings.Default.UnPrefab;
            TSM_Convert.Checked = Settings.Default.Convert;
            TSM_Log.Checked = Settings.Default.Log;
            switch (Program.server)
            {
                case 1:
                    rdb_ST.Checked = true;
                    break;
                case 2:
                    rdb_SJ.Checked = true;
                    break;
                case 3:
                    rdb_SK.Checked = true;
                    break;
                case 4:
                    rdb_tennis.Checked = true;
                    break;
            }
            if (Program.ver == 1) RB_A.Checked = true;
            else RB_I.Checked = true;
            if (Program.autoDownload) btn_Start.PerformClick();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isWorking)
            {
                MessageBox.Show("還在下載中，請正常暫停後再關閉");
                e.Cancel = true;
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string item in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (Directory.Exists(item)) Directory_Read(item);
                else if (item.EndsWith(".txt") && File.Exists(item)) File_Read(item);
            }
        }

        private void TSM_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            if (sender == TSM_UnPrefab)
            {
                Settings.Default.UnPrefab = ((ToolStripMenuItem)sender).Checked;
                TSM_Exclude.ReadOnly = !((ToolStripMenuItem)sender).Checked;
                return;
            }
            if (sender == TSM_Convert)
            {
                Settings.Default.Convert = ((ToolStripMenuItem)sender).Checked;
                return;
            }
            if (sender == TSM_Log)
            {
                Settings.Default.Log = ((ToolStripMenuItem)sender).Checked;
                return;
            }
            if (sender == TSM_OpenLogForm)
            {
                if (logForm.isColse) logForm.Show();
                return;
            }
        }

        private void rdb_Custom_CheckedChanged(object sender, EventArgs e)
        {
            txt_URL.ReadOnly = !rdb_Custom.Checked;
            GB_Ver.Enabled = !rdb_Custom.Checked;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (txt_Save.Text == "")
            {
                MessageBox.Show("輸出路徑不可空白");
                return;
            }
            if (txt_File.Text == "")
            {
                MessageBox.Show("未選擇清單檔案");
                return;
            }
            if (!File_Read(txt_File.Text)) return;

            if (rdb_Custom.Checked)
            {
                if (!txt_URL.Text.StartsWith("http://") && !txt_URL.Text.StartsWith("https://") && MessageBox.Show("網址非http或https開頭\r\n是否繼續?", "確認", MessageBoxButtons.YesNo) == DialogResult.No) return;
                if (!txt_URL.Text.EndsWith("/") && MessageBox.Show("網址非\"/\"結尾\r\n是否繼續?", "確認", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }

            if (TSM_Log.Checked) { logForm.richTextBox1.Text = ""; if (logForm.isColse) logForm.Show(); }
            try { ServicePointManager.DefaultConnectionLimit = Convert.ToInt32(TST_DLLength.Text); }
            catch (Exception) { ServicePointManager.DefaultConnectionLimit = 2; }
            
            Settings.Default.exclude = TSM_Exclude.Text;
            Settings.Default.URL = txt_URL.Text;
            Settings.Default.DLLength = TST_DLLength.Text;
            Settings.Default.Save();

            Work_Event(true);
            SetToolStripLabelText("下載中(0%)", lab_Status);
            timer1.Start();
            SW.Restart();
            new Thread(RunDownload).Start();
        }

        private void btn_Save_Error_Click(object sender, EventArgs e)
        {
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(SFD.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        foreach (string text in lib_Error.Items)
                            if ((text != "") && (text != "\r\n"))
                                streamWriter.WriteLine(text.ToString());
                        lab_Status.Text = "寫入完成";
                    }
                }
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            isWorking = false;
            btn_Stop.Enabled = false;
        }

        private void lib_File_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !isWorking)
            {
                richTextBox1.Clear();
                richTextBox1.Font = lib_File.Font;
                string[] List = lib_File.Items.Cast<string>().ToArray();
                foreach (string item in List) richTextBox1.Text += item + "\r\n";
                richTextBox1.Visible = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                if (richTextBox1.Text != "")
                {
                    File.WriteAllText(Application.StartupPath + "\\FileList.txt", richTextBox1.Text);
                    File_Read(Application.StartupPath + "\\FileList.txt");
                }
                richTextBox1.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lab_time.Text = string.Format("已用時間: {0}:{1}", SW.Elapsed.Minutes.ToString("D2"), SW.Elapsed.Seconds.ToString("D2"));
                        
            if (RAM >= 2048) GC.Collect();
        }

        private void RunDownload()
        {
            if (!Directory.Exists(txt_Save.Text + "Unity3D")) Directory.CreateDirectory(txt_Save.Text + "Unity3D");

            List<DownloadInfo> list = new List<DownloadInfo>();
            string Extension = (chb_Unity3d.Checked ? ".unity3d" : "");
            string[] FileList = lib_File.Items.Cast<string>().ToArray();
            string Url;

            if (rdb_ST.Checked) Url = "http://img.wcproject.so-net.tw/assets/469/";
            else if (rdb_SJ.Checked) Url = "http://i.wcat.colopl.jp/assets/2018/";
            else if (rdb_SK.Checked) Url = "http://i-wcat-colopl-kr.akamaized.net/assets/465/";
            else if (rdb_tennis.Checked) Url = "http://i-tennis-colopl-jp.akamaized.net/asset_bundle/";
            else Url = txt_URL.Text;

            if (rdb_tennis.Checked && RB_A.Checked) Url += "android/0.0.1/";
            else if (rdb_tennis.Checked && RB_I.Checked) Url += "ios/0.0.1/";
            else if (!rdb_Custom.Checked && RB_A.Checked) Url += "a/";
            else if (!rdb_Custom.Checked && RB_I.Checked) Url += "i/";

            SetProgressBarValue(0, PB_TotalFile);
            tbManager.SetProgressValue(0, FileList.Length);
            tbManager.SetProgressState(TaskbarProgressBarState.Normal);

            foreach (string fileName in FileList)
            {
                if (fileName == "" || fileName.Substring(0, 1) == "'" || !fileName.ComparisonFileName()) DelListBox(fileName.ToString(), lib_File);
                else
                {
                    string urlAddress = Url + fileName + Extension + "?r=" + DateTime.Now.ToFileTime().ToString();
                    DownloadInfo info = new DownloadInfo(urlAddress, txt_Save.Text, this, fileName + ".unity3d");
                    list.Add(info);
                    info.StartDownload();
                }
            }

            list.ForEach(delegate (DownloadInfo item)
            {
                SetToolStripLabelText("下載中 (" + (PB_TotalFile.Value * 100.0 / list.Count).ToString("0.0") + "%)", lab_Status);
                while (!item.IsDone)
                {
                    if (!isWorking) { if (item.WC != null) item.WC.CancelAsync(); break; }
                    SetLabelText("下載檔案: " + item.FileName, lab_Download);
                    SetLabelText(string.Format("{0} KB / {1} KB", item.KBytesReceived.ToString("0.0"), item.TotalKBytesToReceive.ToString("0.0")), lab_Speed);
                    SetProgressBarValue(item.KBytesReceived, PB_SingleFile);
                    SetProgressBarMaxValue(item.TotalKBytesToReceive, PB_SingleFile);
                    Thread.Sleep(500);
                }
                if (item.IsCancelled) AddListBoxItem(Path.GetFileNameWithoutExtension(item.FileName), lib_Error);
                else if (item.Error != "") AddListBoxItem(Path.GetFileNameWithoutExtension(item.FileName), lib_Error);
                SetProgressBarValue(PB_TotalFile.Value + 1, PB_TotalFile);
                SetToolStripLabelText("錯誤檔案數: " + lib_Error.Items.Count.ToString(), lab_ErrorItem);
                SetToolStripLabelText("已下載數: " + PB_TotalFile.Value, lab_DownItem);
                DelListBox(Path.GetFileNameWithoutExtension(item.FileName), lib_File);
                tbManager.SetProgressValue(PB_TotalFile.Value, FileList.Length);
            });

            list.Clear();
            SetProgressBarValue(0, PB_SingleFile);
            SetProgressBarMaxValue(0, PB_SingleFile);
            SetLabelText("0 KB / 0 KB", lab_Speed);
            if (extFile.Count != 0)
            {
                SetToolStripLabelText("檔案數: " + extFile.Count, lab_Item);
                SetProgressBarValue(0, PB_TotalFile);
                SetProgressBarMaxValue(extFile.Count, PB_TotalFile);

                SetToolStripLabelText("載入資料中", lab_Status);
                assetsManager.LoadFolder(txt_Save.Text + "Unity3D");

                SetToolStripLabelText("解包中", lab_Status);
                Parallel.ForEach(assetsManager.assetsFileList, (item) =>
                {
                    string fileName = Path.GetFileNameWithoutExtension(item.originalPath);
                    if (!extFile.Contains(fileName + ".unity3d")) return;

                    bool Export = true;
                    if (TSM_UnPrefab.Checked && TSM_Exclude.Text != "") foreach (string item2 in TSM_Exclude.Text.Split(new char[] { ',' })) if (fileName.ToLower().Contains(item2.ToLower())) { Export = false; break; }

                    if (Export)
                    {
                        SetToolStripLabelText("解包: " + fileName, lab_Execute);
                        foreach (var item2 in item.m_Objects)
                        {
                            string SavePath = "";
                            ObjectReader OR = new ObjectReader(item.reader, item, item2);
                            switch (OR.type)
                            {
                                case ClassIDType.Texture2D:
                                    SavePath = txt_Save.Text + "Texture\\";
                                    if (File.Exists(SavePath + fileName + ".png")) return;

                                    if (!Directory.Exists(SavePath)) Directory.CreateDirectory(SavePath);
                                    var m_Texture2D = new Texture2D(OR);
                                    var converter = new Texture2DConverter(m_Texture2D);
                                    var bitmap = converter.ConvertToBitmap(true);
                                    if (bitmap != null)
                                    {
                                        if (fileName.StartsWith("Card"))
                                        {
                                            if (!fileName.Contains("std") && !fileName.EndsWith("w_png") && (bitmap.Width == 1024 && bitmap.Height == 1024)) bitmap = bitmap.ResizeImage(1024, 1331);
                                        }
                                        else if (fileName.StartsWith("Location"))
                                        {
                                            if (bitmap.Width == 512 && bitmap.Height == 512) bitmap = bitmap.ResizeImage(768, 512);
                                            else if (bitmap.Width == 1024 && bitmap.Height == 1024) bitmap = bitmap.ResizeImage(1536, 1024);
                                        }
                                        else if (fileName.Contains("loginBonus_bg") && (bitmap.Width == 1024 && bitmap.Height == 1024)) bitmap = bitmap.ResizeImage(1024, 1536);

                                        bitmap.Save(SavePath + fileName + ".png", ImageFormat.Png);
                                        bitmap.Dispose();
                                    }

                                    m_Texture2D = null;
                                    break;
                                case ClassIDType.AudioClip:
                                    SavePath = txt_Save.Text + "Audio\\";

                                    if (fileName.StartsWith("Sound_Voice"))
                                    {
                                        string[] path = fileName.Split(new char[] { '_' });
                                        string finalPath = "";
                                        for (int i = 0; i < path.Length - 2; i++) finalPath += path[i] + "_";
                                        SavePath += finalPath.Remove(finalPath.Length - 1) + "\\";
                                    }

                                    if (!Directory.Exists(SavePath)) Directory.CreateDirectory(SavePath);

                                    AudioClip m_AudioClip = new AudioClip(OR);
                                    var audioClipConverter = new AudioClipConverter(m_AudioClip);

                                    if (audioClipConverter.IsFMODSupport)
                                    {
                                        byte[] m_AudioData = audioClipConverter.ConvertToWav();
                                        File.WriteAllBytes(SavePath + fileName + ".wav", m_AudioData);
                                    }
                                    else
                                    {
                                        byte[] m_AudioData = m_AudioClip.m_AudioData.Value;
                                        File.WriteAllBytes(SavePath + fileName + audioClipConverter.GetExtensionName(), m_AudioData);
                                    }

                                    m_AudioClip = null;
                                    break;
                                case ClassIDType.TextAsset:
                                    SavePath = txt_Save.Text + "Text\\";
                                    if (!Directory.Exists(SavePath)) Directory.CreateDirectory(SavePath);
                                    TextAsset TA = new TextAsset(OR);
                                    File.WriteAllBytes(SavePath + fileName + ".txt", TA.m_Script);
                                    TA = null;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        string SavePath = txt_Save.Text + "Unity3D\\";
                        if (!Directory.Exists(SavePath)) Directory.CreateDirectory(SavePath);
                        SetToolStripLabelText("略過: " + fileName, lab_Execute);
                        File.Move(item.originalPath, SavePath + fileName + ".unity3d");
                    }

                    SetProgressBarValue(PB_TotalFile.Value + 1, PB_TotalFile);
                    tbManager.SetProgressValue(PB_TotalFile.Value, extFile.Count);
                    SetToolStripLabelText("已解包數: " + PB_TotalFile.Value, lab_DownItem);
                });

                assetsManager.Clear();
                extFile.Clear();
                GC.Collect();
            }

            SW.Stop();
            timer1.Stop();
            SetLabelText("下載檔案:無", lab_Download);
            SetToolStripLabelText("等待中", lab_Status);
            Work_Event(false);
            tbManager.SetProgressState(TaskbarProgressBarState.NoProgress);
            Invoke(new Action(delegate { Text = "清單檔案下載器 "; }));
            if (Program.autoClose) Environment.Exit(1);
            if (lib_Error.Items.Count <= 0) SetButtonEnable(false, btn_Save_Error);
            Environment.ExitCode = 1;
            MessageBox.Show("下載完成");
        }

       

        private void Work_Event(bool Work)
        {
            SetButtonEnable(!Work, btn_Save);
            SetButtonEnable(!Work, btn_Start);
            SetButtonEnable(!Work, btn_File);
            SetButtonEnable(Work, btn_Stop);
            SetButtonEnable(!Work, btn_Save_Error);
            SetGroupBoxEnable(!Work, GB_Server);
            SetGroupBoxEnable(!Work, GB_Ver);
            SetToolStripMenuuItemEnable(!Work, TSM_UnPrefab);
            SetToolStripMenuuItemEnable(!Work, TSM_Convert);
            SetToolStripMenuuItemEnable(!Work, TSM_Log);
            SetToolStripTextBoxEnable(!Work);
            SetCheckBoxEnable(!Work);
            SetTextBoxReadOnly(Work && !rdb_Custom.Checked, TSM_Exclude);
            SetTextBoxReadOnly(Work, TST_DLLength);
            isWorking = Work;
        }
    }
}
