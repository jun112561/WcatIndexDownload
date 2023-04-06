using System;
using System.IO;
using System.Windows.Forms;

namespace WcatIndexDownload
{
    internal static class Program
    {
        public static bool autoDownload = false;

        public static bool autoClose = false;

        public static bool noCreateDirectory = false;

        public static bool autoDelete = false;

        public static string filePath = "";

        public static string directoryPath = "";

        public static string exclude = "";

        public static int server = 1;

        public static int ver = 1;

        [STAThread]
        private static void Main()
        {
            Environment.ExitCode = 0;
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length >= 2)
            {
                foreach (string item in commandLineArgs)
                {
                    #region 顯示說明
                    if (item.ToLower() == "/help" || item == "/?")
                    {
                        MessageBox.Show("Test");
                        Console.WriteLine();
                        Console.WriteLine(Path.GetFileNameWithoutExtension(Application.ExecutablePath) + " \"文字檔檔案位置\" \"下載檔案存放資料夾位置\" [參數] ");
                        Console.WriteLine();
                        Console.WriteLine("文字檔檔案副檔名必須是txt，資料夾必須已存在");
                        Console.WriteLine();
                        Console.WriteLine("參數如下(不分大小寫):");
                        Console.WriteLine("\"/TW\"\t伺服器指定為台版伺服器(預設值)");
                        Console.WriteLine("\"/JP\"\t伺服器指定為日版伺服器");
                        Console.WriteLine("\"/A\"\t下載檔案版本A版(預設值)");
                        Console.WriteLine("\"/I\"\t下載檔案版本I版");
                        Console.WriteLine("\"/AC\"\t下載完後自動關閉視窗");
                        Console.WriteLine("\"/AD\"\t自動下載");
                        Console.WriteLine("\"/NCD\"\t不自動新建資料夾(預設會自動新建)");
                        Console.WriteLine("\"/DD\"\t下載完後刪除Unity3d檔");
                        Console.WriteLine("\"/NS\"\t不自動在檔名後加上#(編號)");
                        Environment.Exit(1);
                    }
                    #endregion

                    if (File.Exists(item) && new FileInfo(item).Extension == ".txt") filePath = item;
                    if (Directory.Exists(item)) directoryPath = item;
                    switch (item.ToLower())
                    {
                        case "/a":
                            ver = 1;
                            break;
                        case "/i":
                            ver = 2;
                            break;
                        case "/ad":
                            autoDownload = true;
                            break;
                        case "/ncd":
                            noCreateDirectory = true;
                            break;
                        case "/ac":
                            autoClose = true;
                            break;
                        case "/dd":
                            autoDelete = true;
                            break;
                        case "/tw":
                            server = 1;
                            break;
                        case "/jp":
                            server = 2;
                            break;
                        case "/ue":
                            exclude = item.Substring(4);
                            break;
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
