using System;
using System.Windows.Forms;

namespace TestApp
{
    public partial class LogFile : Form
    {
        FileOperations operations;

        public LogFile()
        {
            operations = new FileOperations();
            InitializeComponent();
            txtLogFile.Text = operations.ReadLog();          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
