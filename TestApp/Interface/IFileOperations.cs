
namespace TestApp.Interface
{
    public interface IFileOperations
    {
        string ReadLog();
        void ClearFile();
        void WriteLog(string value);
        void WriteToLogFile(string msg);
        void WriteToLogFile(string lblText, int drug_val, int new_count);
    }
}
