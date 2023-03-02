using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
