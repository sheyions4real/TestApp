using System;
using System.IO;
using System.Windows.Forms;
using TestApp.Interface;

namespace TestApp
{
    class FileOperations : IFileOperations
    {
        string filename = "DrugIncrementTest.log";
      
        public StreamWriter CreateLogFile()
        {
            try
            {
                StreamWriter sw;
                if (!File.Exists(filename))
                {
                    sw = File.CreateText(filename);
                }
                else
                {
                    sw = File.AppendText(filename);
                }
                return sw;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Execption: {ex.Message}");
                throw ex;
            }
        }

        public void ClearFile()
        {
            try
            {
                File.WriteAllText(filename, string.Empty);
            }
            catch (FileNotFoundException) {
                StreamWriter sw = CreateLogFile();
            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show($"AccessViolationException: {ex.Message}");
                //throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GenericException: {ex.Message}");
                //throw;
            }
        }
        public void WriteLog(string value)
        {
            try
            {
                TextWriter sw = CreateLogFile();
                sw.WriteLine(value);
                sw.WriteLine(string.Empty);
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show($"AccessViolationException: {ex.Message}");
                return;
                
            }
            catch (Exception ex) {
                MessageBox.Show($"GenericException: {ex.Message}");
                return;
               
            }
            
        }
        public string ReadLog()
        {
            string value = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        value += reader.ReadLine();
                        value += Environment.NewLine;
                    }

                    reader.Close();
                    reader.Dispose();
                }
                return value;

            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show($"AccessViolationException: {ex.Message}");
                return value;
            }
        }
        public void WriteToLogFile(string msg)
        {
            WriteLog($"{DateTime.Now:MM / dd / yy HH:mm:ss} - {msg}");
        }
        public void WriteToLogFile(string lblText, int drug_val, int new_count)
        {
            WriteLog($"{DateTime.Now:MM / dd / yy HH:mm:ss} - {lblText}  - Previous Count: {drug_val} - New Count: {new_count}");
        }
    }
}
