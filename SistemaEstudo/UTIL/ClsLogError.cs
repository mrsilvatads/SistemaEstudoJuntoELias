using System;
using System.Diagnostics;
using System.IO;

namespace SistemaEstudo.UTIL
{

    public static class ClsLogError
    {

        public static string LogError(Exception ex)
        {
            SecondLevelException sec;
            try
            {
                Type type = typeof(Exception);
                sec = new SecondLevelException(ex.Message.ToString(), ex);

                int errNo = sec.getHResult();
                ClsFileLog.createFileLog(ex, sec.InnerException.Message.ToString());
                return sec.InnerException.Message.ToString();
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public static void LogError(string err, Exception ex)
        {
            try
            {
                ClsFileLog.createFileLog(ex, err);
            }
            catch (Exception e){}
        }
    }
    public class SecondLevelException : Exception
    {
        const int SecondLevelHResult = unchecked((int)0x81234567);
        // Set HResult for this exception, and include it in 
        // the exception message.
        public SecondLevelException(string message, Exception inner) :
            base(string.Format("(HRESULT:0x{1:X8}) {0}",
                message, SecondLevelHResult), inner)
        {
            HResult = SecondLevelHResult;
        }
        public int getHResult()
        {
            return SecondLevelHResult;
        }
    }
    public static class ClsFileLog
    {
        public static void createFileLog(Exception e, string err)
        {
            try
            {
                //testa se siretorio ja esta criando se não estiver será criado!

                //if (!Directory.Exists(Path.GetDirectoryName(ClsPathExe.path)))
                //    Directory.CreateDirectory(Path.GetDirectoryName(ClsPathExe.path)); // falta implementar esta com erro!! 19/03/2019
                string r = GetCurrentMethod();
                TextWriter tw = new StreamWriter(ClsPathExe.path + @"\Logs\log_" + e.GetType().FullName + " " + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".txt", true);
                tw.WriteLine("METODO=" + r.GetType().Name + "\n"); //tw.WriteLine("METODO=" + e.GetType().FullName + "\n");
                tw.WriteLine("EXCEPTION=" + e.Message.ToString() + "\n");
                tw.WriteLine("STACKTRACE=" + e.StackTrace + "\n");
                tw.WriteLine("TRADUCAO=" + err);
                tw.WriteLine("********************************************************************");
                tw.WriteLine("");
                tw.Close();
            }
            catch (Exception ex) { }
        }
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            return sf.GetMethod().Name;
        }
    }
}
