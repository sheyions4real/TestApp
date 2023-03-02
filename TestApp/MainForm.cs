using System;
using System.Windows.Forms;
using TestApp.Interface;

namespace TestApp
{
    public partial class MainForm : Form
    {         
        int drug_1, drug_2, drug_3 = 0;
        private readonly IFileOperations _operations;

        public MainForm(IFileOperations operations)
        {
           InitializeComponent();         
           this. _operations = operations;
           // erase the file if it already exist else create it
           _operations.ClearFile();
           // write to the log
           _operations.WriteToLogFile("START");
        }

        private void btnDrug_3_Click(object sender, EventArgs e)
        {
            ResetText(lblDrugCount_3, drug_3 += 1);
            // writingto log file
            _operations.WriteToLogFile(lblDrugName_3.Text, drug_3 - 1, drug_3);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {          
            reset();          
        }

        private void btnDrug_1_Click(object sender, EventArgs e)
        {
            ResetText(lblDrugCount_1, drug_1 += 1);
            // writingto log file
            _operations.WriteToLogFile(lblDrugName_1.Text, drug_1 - 1, drug_1);       
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?" ,"Exit Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }          
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
           LogFile frmLogFile = new LogFile(_operations);
           frmLogFile.ShowDialog(); 
        }

        private void btnDrug_2_Click(object sender, EventArgs e)
        {
            ResetText(lblDrugCount_2, drug_2+=1);
            // writingto log file
            _operations.WriteToLogFile(lblDrugName_2.Text, drug_2-1, drug_2);        
        }
        public void reset()
        {
            ////writing to log file
            _operations.WriteToLogFile("RESET");
            _operations.WriteToLogFile(lblDrugName_1.Text, drug_1,0);
            _operations.WriteToLogFile(lblDrugName_2.Text, drug_2,0);
            _operations.WriteToLogFile(lblDrugName_3.Text, drug_3,0);

            //////////// resetting drug count
            drug_1 = 0;
            drug_2 = 0;
            drug_3 = 0;

            //////restting label value
           ResetText(lblDrugCount_1, drug_1);
           ResetText(lblDrugCount_2, drug_2);
           ResetText(lblDrugCount_3, drug_3);
        }

        public void ResetText(Label lbl, int drug_val)
        {
            lbl.Text = $"{drug_val}";
        }
    }
}
