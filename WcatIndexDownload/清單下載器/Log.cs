using System;
using System.Windows.Forms;

namespace 清單下載器
{
    public partial class Log : Form
    {
        public bool isColse = true;

        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            isColse = false;
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            isColse = true;
            Hide();
            e.Cancel = true;
        }
        
        private void Log_Activated(object sender, EventArgs e)
        {
            isColse = false;
        }
    }
}
