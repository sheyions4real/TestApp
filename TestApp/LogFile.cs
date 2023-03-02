using System;
using System.Windows.Forms;
using TestApp.Interface;

namespace TestApp
{
    public partial class LogFile : Form
    {
        private readonly IFileOperations _operations;

        public LogFile(IFileOperations operations)
        {
            _operations = operations;
            InitializeComponent();
            txtLogFile.Text = _operations.ReadLog();          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
