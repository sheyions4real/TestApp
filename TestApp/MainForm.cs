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
    public partial class MainForm : Form
    { int drug_1, drug_2, drug_3 = 0;
        FileOperations operations;



        public MainForm()
        {
            operations = new FileOperations();
            // erase the file if it already exist else create it
            operations.ClearFile();
            // write to the log
            operations.WriteLog(DateTime.Now.ToString("MM/dd/yy HH:MM:ss") + " - START\r\n" + Environment.NewLine);

            InitializeComponent();
        }

        private void btnDrug_3_Click(object sender, EventArgs e)
        {
            
            lblDrugCount_3.Text=(drug_3 += 1).ToString();
            // use string builder
            operations.WriteLog(DateTime.Now.ToString("MM/dd/yy HH:MM:ss") + " - " + lblDrugName_3.Text + " - Previous Count: " + (drug_3 - 1).ToString() + " - New Count: " + drug_3.ToString() + " "+ Environment.NewLine);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnDrug_1_Click(object sender, EventArgs e)
        {
            lblDrugCount_1.Text = (drug_1 += 1).ToString();
            // use string builder
            operations.WriteLog(DateTime.Now.ToString("MM/dd/yy HH:MI:ss") + " - " +  lblDrugName_1.Text + " - Previous Count: " + (drug_1 - 1).ToString() + " - New Count: " + drug_1.ToString() +  " " +Environment.NewLine);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Are you sure you want to exit?" ,"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            LogFile frmLogFile = new LogFile();
            frmLogFile.ShowDialog();
            
        }

        private void btnDrug_2_Click(object sender, EventArgs e)
        {
            lblDrugCount_2.Text = (drug_2 += 1).ToString();
            // use string builder
            operations.WriteLog(DateTime.Now.ToString("MM/dd/yy HH:MI:ss") + " - " + lblDrugName_2.Text + " - Previous Count: " + (drug_2 - 1).ToString() + " - New Count: " + drug_2.ToString() + " " + Environment.NewLine);

        }
        public void reset()
        {
            drug_1 = 0;
            drug_2 = 0;
            drug_3 = 0;
            lblDrugCount_1.Text = drug_1.ToString();
            lblDrugCount_2.Text = drug_2.ToString();
            lblDrugCount_3.Text = drug_3.ToString();
        }
    }
}
