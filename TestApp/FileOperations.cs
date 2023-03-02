using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class FileOperations
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
            catch(FileNotFoundException ex)
            {
                throw;
            }
            catch (FileLoadException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
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

                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void WriteLog(string value)
        {
            try
            {

                TextWriter sw = CreateLogFile();
              
                sw.WriteLine(value );
                 sw.WriteLine("\r\n");
                sw.WriteLine(Environment.NewLine);
                
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            catch (AccessViolationException ex)
            {
                throw;
            }
            catch (Exception ex) {
                throw;
            }
            
        }


        public string ReadLog()
        {
            string value = "";
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        value += reader.ReadLine();
                    }

                    reader.Close();
                    reader.Dispose();
                }
                return value;

            }
            catch (AccessViolationException ex)
            {

                throw;
            }
        }
    }
}
