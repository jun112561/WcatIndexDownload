using System.Windows.Forms;
using System;
using System.Drawing;
namespace WcatIndexDownload
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private OpenFileDialog OFD;

        private FolderBrowserDialog FBO;

        private Label label2;

        private TextBox txt_File;

        private Button btn_Start;

        private Button btn_File;

        private Button btn_Save;

        private ListBox lib_File;

        private Label label1;

        private ListBox lib_Error;

        private Label label3;

        private ProgressBar PB_TotalFile;

        private GroupBox GB_Server;

        private GroupBox GB_Ver;

        private Button btn_Save_Error;

        private SaveFileDialog SFD;

        private Button btn_Stop;

        private StatusStrip statusStrip;

        private ToolStripStatusLabel lab_Status;

        private ToolStripStatusLabel lab_Item;

        private ToolStripStatusLabel lab_DownItem;

        private ToolStripStatusLabel lab_ErrorItem;

        private Label lab_Download;

        private ToolStripStatusLabel lab_time;

        private System.Windows.Forms.Timer timer1;

        public RadioButton rdb_ST;

        public RadioButton rdb_SJ;

        public RadioButton RB_I;

        public RadioButton RB_A;

        private MenuStrip menuStrip1;

        private ToolStripMenuItem 解包選項ToolStripMenuItem;

        private ToolStripStatusLabel lab_Execute;

        private ProgressBar PB_SingleFile;

        private Label lab_Speed;

        private TextBox txt_URL;

        private RadioButton rdb_Custom;

        private CheckBox chb_Unity3d;

        public RadioButton rdb_tennis;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.FBO = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_File = new System.Windows.Forms.TextBox();
            this.txt_Save = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_File = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lib_File = new System.Windows.Forms.ListBox();
            this.rdb_ST = new System.Windows.Forms.RadioButton();
            this.rdb_SJ = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lib_Error = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PB_TotalFile = new System.Windows.Forms.ProgressBar();
            this.GB_Server = new System.Windows.Forms.GroupBox();
            this.rdb_tennis = new System.Windows.Forms.RadioButton();
            this.txt_URL = new System.Windows.Forms.TextBox();
            this.rdb_Custom = new System.Windows.Forms.RadioButton();
            this.GB_Ver = new System.Windows.Forms.GroupBox();
            this.RB_I = new System.Windows.Forms.RadioButton();
            this.RB_A = new System.Windows.Forms.RadioButton();
            this.btn_Save_Error = new System.Windows.Forms.Button();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lab_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_Item = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_DownItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_ErrorItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_Execute = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_Download = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.解包選項ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_Log = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_Convert = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_UnPrefab = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_Exclude = new System.Windows.Forms.ToolStripTextBox();
            this.TSM_OpenLogForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TST_DLLength = new System.Windows.Forms.ToolStripTextBox();
            this.PB_SingleFile = new System.Windows.Forms.ProgressBar();
            this.lab_Speed = new System.Windows.Forms.Label();
            this.chb_Unity3d = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RB_2018 = new System.Windows.Forms.RadioButton();
            this.RB_2020 = new System.Windows.Forms.RadioButton();
            this.RB_2022 = new System.Windows.Forms.RadioButton();
            this.GB_Server.SuspendLayout();
            this.GB_Ver.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OFD
            // 
            this.OFD.DefaultExt = "txt";
            this.OFD.Filter = "文字檔|*.txt|全部格式|*.*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "輸出目錄:";
            // 
            // txt_File
            // 
            this.txt_File.Location = new System.Drawing.Point(12, 42);
            this.txt_File.Name = "txt_File";
            this.txt_File.ReadOnly = true;
            this.txt_File.Size = new System.Drawing.Size(640, 22);
            this.txt_File.TabIndex = 2;
            // 
            // txt_Save
            // 
            this.txt_Save.Location = new System.Drawing.Point(12, 82);
            this.txt_Save.Name = "txt_Save";
            this.txt_Save.ReadOnly = true;
            this.txt_Save.Size = new System.Drawing.Size(640, 22);
            this.txt_Save.TabIndex = 3;
            // 
            // btn_Start
            // 
            this.btn_Start.Enabled = false;
            this.btn_Start.Location = new System.Drawing.Point(621, 329);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(60, 23);
            this.btn_Start.TabIndex = 4;
            this.btn_Start.Text = "開始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_File
            // 
            this.btn_File.Location = new System.Drawing.Point(658, 40);
            this.btn_File.Name = "btn_File";
            this.btn_File.Size = new System.Drawing.Size(23, 23);
            this.btn_File.TabIndex = 5;
            this.btn_File.Text = "...";
            this.btn_File.UseVisualStyleBackColor = true;
            this.btn_File.Click += new System.EventHandler(this.btn_FIle_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(658, 80);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(23, 23);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "...";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lib_File
            // 
            this.lib_File.FormattingEnabled = true;
            this.lib_File.HorizontalScrollbar = true;
            this.lib_File.ItemHeight = 12;
            this.lib_File.Location = new System.Drawing.Point(12, 211);
            this.lib_File.Name = "lib_File";
            this.lib_File.Size = new System.Drawing.Size(325, 112);
            this.lib_File.TabIndex = 7;
            this.lib_File.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lib_File_MouseDown);
            // 
            // rdb_ST
            // 
            this.rdb_ST.AutoSize = true;
            this.rdb_ST.Checked = true;
            this.rdb_ST.Location = new System.Drawing.Point(6, 14);
            this.rdb_ST.Name = "rdb_ST";
            this.rdb_ST.Size = new System.Drawing.Size(47, 16);
            this.rdb_ST.TabIndex = 9;
            this.rdb_ST.TabStop = true;
            this.rdb_ST.Text = "台版";
            this.rdb_ST.UseVisualStyleBackColor = true;
            // 
            // rdb_SJ
            // 
            this.rdb_SJ.AutoSize = true;
            this.rdb_SJ.Location = new System.Drawing.Point(59, 14);
            this.rdb_SJ.Name = "rdb_SJ";
            this.rdb_SJ.Size = new System.Drawing.Size(47, 16);
            this.rdb_SJ.TabIndex = 10;
            this.rdb_SJ.Text = "日版";
            this.rdb_SJ.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "輸入檔案:";
            // 
            // lib_Error
            // 
            this.lib_Error.FormattingEnabled = true;
            this.lib_Error.HorizontalScrollbar = true;
            this.lib_Error.ItemHeight = 12;
            this.lib_Error.Location = new System.Drawing.Point(356, 211);
            this.lib_Error.Name = "lib_Error";
            this.lib_Error.Size = new System.Drawing.Size(325, 112);
            this.lib_Error.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(628, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "錯誤清單";
            // 
            // PB_TotalFile
            // 
            this.PB_TotalFile.Location = new System.Drawing.Point(12, 387);
            this.PB_TotalFile.Name = "PB_TotalFile";
            this.PB_TotalFile.Size = new System.Drawing.Size(669, 23);
            this.PB_TotalFile.Step = 1;
            this.PB_TotalFile.TabIndex = 14;
            // 
            // GB_Server
            // 
            this.GB_Server.Controls.Add(this.rdb_tennis);
            this.GB_Server.Controls.Add(this.txt_URL);
            this.GB_Server.Controls.Add(this.rdb_Custom);
            this.GB_Server.Controls.Add(this.rdb_ST);
            this.GB_Server.Controls.Add(this.rdb_SJ);
            this.GB_Server.Location = new System.Drawing.Point(10, 110);
            this.GB_Server.Name = "GB_Server";
            this.GB_Server.Size = new System.Drawing.Size(671, 59);
            this.GB_Server.TabIndex = 15;
            this.GB_Server.TabStop = false;
            this.GB_Server.Text = "伺服器版本";
            // 
            // rdb_tennis
            // 
            this.rdb_tennis.AutoSize = true;
            this.rdb_tennis.Location = new System.Drawing.Point(112, 14);
            this.rdb_tennis.Name = "rdb_tennis";
            this.rdb_tennis.Size = new System.Drawing.Size(71, 16);
            this.rdb_tennis.TabIndex = 14;
            this.rdb_tennis.TabStop = true;
            this.rdb_tennis.Text = "網球專用";
            this.rdb_tennis.UseVisualStyleBackColor = true;
            // 
            // txt_URL
            // 
            this.txt_URL.Location = new System.Drawing.Point(83, 31);
            this.txt_URL.Name = "txt_URL";
            this.txt_URL.ReadOnly = true;
            this.txt_URL.Size = new System.Drawing.Size(582, 22);
            this.txt_URL.TabIndex = 13;
            // 
            // rdb_Custom
            // 
            this.rdb_Custom.AutoSize = true;
            this.rdb_Custom.Location = new System.Drawing.Point(6, 36);
            this.rdb_Custom.Name = "rdb_Custom";
            this.rdb_Custom.Size = new System.Drawing.Size(71, 16);
            this.rdb_Custom.TabIndex = 12;
            this.rdb_Custom.TabStop = true;
            this.rdb_Custom.Text = "自訂網址";
            this.rdb_Custom.UseVisualStyleBackColor = true;
            this.rdb_Custom.CheckedChanged += new System.EventHandler(this.rdb_Custom_CheckedChanged);
            // 
            // GB_Ver
            // 
            this.GB_Ver.Controls.Add(this.RB_I);
            this.GB_Ver.Controls.Add(this.RB_A);
            this.GB_Ver.Location = new System.Drawing.Point(179, 174);
            this.GB_Ver.Name = "GB_Ver";
            this.GB_Ver.Size = new System.Drawing.Size(111, 36);
            this.GB_Ver.TabIndex = 0;
            this.GB_Ver.TabStop = false;
            this.GB_Ver.Text = "檔案版本";
            // 
            // RB_I
            // 
            this.RB_I.AutoSize = true;
            this.RB_I.Location = new System.Drawing.Point(66, 14);
            this.RB_I.Name = "RB_I";
            this.RB_I.Size = new System.Drawing.Size(39, 16);
            this.RB_I.TabIndex = 1;
            this.RB_I.Text = "I版";
            this.RB_I.UseVisualStyleBackColor = true;
            // 
            // RB_A
            // 
            this.RB_A.AutoSize = true;
            this.RB_A.Checked = true;
            this.RB_A.Location = new System.Drawing.Point(6, 14);
            this.RB_A.Name = "RB_A";
            this.RB_A.Size = new System.Drawing.Size(43, 16);
            this.RB_A.TabIndex = 0;
            this.RB_A.TabStop = true;
            this.RB_A.Text = "A版";
            this.RB_A.UseVisualStyleBackColor = true;
            // 
            // btn_Save_Error
            // 
            this.btn_Save_Error.Enabled = false;
            this.btn_Save_Error.Location = new System.Drawing.Point(460, 329);
            this.btn_Save_Error.Name = "btn_Save_Error";
            this.btn_Save_Error.Size = new System.Drawing.Size(89, 23);
            this.btn_Save_Error.TabIndex = 16;
            this.btn_Save_Error.Text = "輸出錯誤清單";
            this.btn_Save_Error.UseVisualStyleBackColor = true;
            this.btn_Save_Error.Click += new System.EventHandler(this.btn_Save_Error_Click);
            // 
            // SFD
            // 
            this.SFD.DefaultExt = "txt";
            this.SFD.Filter = "文字檔|*.txt";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(555, 329);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(60, 23);
            this.btn_Stop.TabIndex = 17;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab_Status,
            this.lab_Item,
            this.lab_DownItem,
            this.lab_ErrorItem,
            this.lab_time,
            this.lab_Execute});
            this.statusStrip.Location = new System.Drawing.Point(0, 418);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(693, 22);
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lab_Status
            // 
            this.lab_Status.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lab_Status.Name = "lab_Status";
            this.lab_Status.Size = new System.Drawing.Size(43, 17);
            this.lab_Status.Text = "等待中";
            this.lab_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_Item
            // 
            this.lab_Item.Name = "lab_Item";
            this.lab_Item.Size = new System.Drawing.Size(56, 17);
            this.lab_Item.Text = "檔案數: 0";
            // 
            // lab_DownItem
            // 
            this.lab_DownItem.Name = "lab_DownItem";
            this.lab_DownItem.Size = new System.Drawing.Size(68, 17);
            this.lab_DownItem.Text = "已下載數: 0";
            // 
            // lab_ErrorItem
            // 
            this.lab_ErrorItem.Name = "lab_ErrorItem";
            this.lab_ErrorItem.Size = new System.Drawing.Size(80, 17);
            this.lab_ErrorItem.Text = "錯誤檔案數: 0";
            // 
            // lab_time
            // 
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(92, 17);
            this.lab_time.Text = "已用時間: 00:00";
            // 
            // lab_Execute
            // 
            this.lab_Execute.Name = "lab_Execute";
            this.lab_Execute.Size = new System.Drawing.Size(49, 17);
            this.lab_Execute.Text = "解包: 無";
            // 
            // lab_Download
            // 
            this.lab_Download.AutoSize = true;
            this.lab_Download.Location = new System.Drawing.Point(10, 329);
            this.lab_Download.Name = "lab_Download";
            this.lab_Download.Size = new System.Drawing.Size(71, 12);
            this.lab_Download.TabIndex = 19;
            this.lab_Download.Text = "下載檔案: 無";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.解包選項ToolStripMenuItem,
            this.TSM_OpenLogForm,
            this.toolStripMenuItem1,
            this.TST_DLLength});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 27);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 解包選項ToolStripMenuItem
            // 
            this.解包選項ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM_Log,
            this.TSM_Convert,
            this.TSM_UnPrefab,
            this.TSM_Exclude});
            this.解包選項ToolStripMenuItem.Name = "解包選項ToolStripMenuItem";
            this.解包選項ToolStripMenuItem.Size = new System.Drawing.Size(67, 23);
            this.解包選項ToolStripMenuItem.Text = "解包選項";
            // 
            // TSM_Log
            // 
            this.TSM_Log.Checked = true;
            this.TSM_Log.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSM_Log.Name = "TSM_Log";
            this.TSM_Log.Size = new System.Drawing.Size(335, 22);
            this.TSM_Log.Text = "開啟紀錄";
            this.TSM_Log.Click += new System.EventHandler(this.TSM_Click);
            // 
            // TSM_Convert
            // 
            this.TSM_Convert.Checked = true;
            this.TSM_Convert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSM_Convert.Name = "TSM_Convert";
            this.TSM_Convert.Size = new System.Drawing.Size(335, 22);
            this.TSM_Convert.Text = "自動轉換解析度";
            this.TSM_Convert.Click += new System.EventHandler(this.TSM_Click);
            // 
            // TSM_UnPrefab
            // 
            this.TSM_UnPrefab.Checked = true;
            this.TSM_UnPrefab.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSM_UnPrefab.Name = "TSM_UnPrefab";
            this.TSM_UnPrefab.Size = new System.Drawing.Size(335, 22);
            this.TSM_UnPrefab.Text = "不自動解名稱包含下面指定字串的檔案(由\",\"分割)";
            this.TSM_UnPrefab.Click += new System.EventHandler(this.TSM_Click);
            // 
            // TSM_Exclude
            // 
            this.TSM_Exclude.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.TSM_Exclude.Name = "TSM_Exclude";
            this.TSM_Exclude.Size = new System.Drawing.Size(250, 23);
            // 
            // TSM_OpenLogForm
            // 
            this.TSM_OpenLogForm.Name = "TSM_OpenLogForm";
            this.TSM_OpenLogForm.Size = new System.Drawing.Size(91, 23);
            this.TSM_OpenLogForm.Text = "開啟紀錄視窗";
            this.TSM_OpenLogForm.Click += new System.EventHandler(this.TSM_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(82, 23);
            this.toolStripMenuItem1.Text = "下載線程數:";
            // 
            // TST_DLLength
            // 
            this.TST_DLLength.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.TST_DLLength.Name = "TST_DLLength";
            this.TST_DLLength.Size = new System.Drawing.Size(100, 23);
            // 
            // PB_SingleFile
            // 
            this.PB_SingleFile.Location = new System.Drawing.Point(12, 358);
            this.PB_SingleFile.Name = "PB_SingleFile";
            this.PB_SingleFile.Size = new System.Drawing.Size(669, 23);
            this.PB_SingleFile.Step = 1;
            this.PB_SingleFile.TabIndex = 24;
            // 
            // lab_Speed
            // 
            this.lab_Speed.AutoSize = true;
            this.lab_Speed.Location = new System.Drawing.Point(10, 343);
            this.lab_Speed.Name = "lab_Speed";
            this.lab_Speed.Size = new System.Drawing.Size(82, 12);
            this.lab_Speed.TabIndex = 25;
            this.lab_Speed.Text = "0.0 KB / 0.0 KB";
            // 
            // chb_Unity3d
            // 
            this.chb_Unity3d.AutoSize = true;
            this.chb_Unity3d.Checked = true;
            this.chb_Unity3d.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_Unity3d.Location = new System.Drawing.Point(296, 189);
            this.chb_Unity3d.Name = "chb_Unity3d";
            this.chb_Unity3d.Size = new System.Drawing.Size(207, 16);
            this.chb_Unity3d.TabIndex = 26;
            this.chb_Unity3d.Text = "下載時在檔案名稱後面加上.unity3d";
            this.chb_Unity3d.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 211);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(325, 112);
            this.richTextBox1.TabIndex = 27;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RB_2022);
            this.groupBox1.Controls.Add(this.RB_2020);
            this.groupBox1.Controls.Add(this.RB_2018);
            this.groupBox1.Location = new System.Drawing.Point(12, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 34);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "伺服器版本";
            // 
            // RB_2018
            // 
            this.RB_2018.AutoSize = true;
            this.RB_2018.Checked = true;
            this.RB_2018.Location = new System.Drawing.Point(7, 13);
            this.RB_2018.Name = "RB_2018";
            this.RB_2018.Size = new System.Drawing.Size(47, 16);
            this.RB_2018.TabIndex = 0;
            this.RB_2018.TabStop = true;
            this.RB_2018.Text = "2018";
            this.RB_2018.UseVisualStyleBackColor = true;
            // 
            // RB_2020
            // 
            this.RB_2020.AutoSize = true;
            this.RB_2020.Location = new System.Drawing.Point(57, 13);
            this.RB_2020.Name = "RB_2020";
            this.RB_2020.Size = new System.Drawing.Size(47, 16);
            this.RB_2020.TabIndex = 1;
            this.RB_2020.Text = "2020";
            this.RB_2020.UseVisualStyleBackColor = true;
            // 
            // RB_2022
            // 
            this.RB_2022.AutoSize = true;
            this.RB_2022.Location = new System.Drawing.Point(110, 13);
            this.RB_2022.Name = "RB_2022";
            this.RB_2022.Size = new System.Drawing.Size(47, 16);
            this.RB_2022.TabIndex = 2;
            this.RB_2022.Text = "2022";
            this.RB_2022.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 440);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.chb_Unity3d);
            this.Controls.Add(this.lab_Speed);
            this.Controls.Add(this.PB_SingleFile);
            this.Controls.Add(this.lab_Download);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Save_Error);
            this.Controls.Add(this.GB_Ver);
            this.Controls.Add(this.GB_Server);
            this.Controls.Add(this.PB_TotalFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lib_Error);
            this.Controls.Add(this.lib_File);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_File);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.txt_Save);
            this.Controls.Add(this.txt_File);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "清單檔案下載器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.GB_Server.ResumeLayout(false);
            this.GB_Server.PerformLayout();
            this.GB_Ver.ResumeLayout(false);
            this.GB_Ver.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripMenuItem TSM_Log;
        private RichTextBox richTextBox1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripTextBox TST_DLLength;
        private ToolStripMenuItem TSM_OpenLogForm;
        public ToolStripMenuItem TSM_UnPrefab;
        public ToolStripTextBox TSM_Exclude;
        public ToolStripMenuItem TSM_Convert;
        public TextBox txt_Save;
        private GroupBox groupBox1;
        private RadioButton RB_2022;
        private RadioButton RB_2020;
        private RadioButton RB_2018;
    }
}

