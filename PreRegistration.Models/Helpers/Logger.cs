using System;
using System.Configuration;
using System.IO;
using System.IO.Compression;

namespace PreRegistration.Models.Helpers
{
    public class Logger
    {
        public string LoggerDir = ConfigurationManager.AppSettings["LoggerDir"].ToString();

        public void Log(String lines)
        {
            var LoggerMonthDir = LoggerDir + DateTime.Now.ToString("MM.yyy");

            if (!Directory.Exists(LoggerMonthDir))
            {
                System.IO.Directory.CreateDirectory(LoggerMonthDir);
            }

            var LoggerLastMonthDir = LoggerDir + DateTime.Now.AddMonths(-1).ToString("MM.yyy");

            if (Directory.Exists(LoggerLastMonthDir))
            {
                Directory.CreateDirectory(LoggerLastMonthDir);
                ZipFile.CreateFromDirectory(LoggerLastMonthDir, LoggerDir + "\\zipped\\" + "PreRegistrationLog-" + DateTime.Now.AddMonths(-1).ToString("MM.yyy") + ".zip");
                Directory.Delete(LoggerLastMonthDir, true);
            }
            try
            {
                using (var stream = new System.IO.StreamWriter(LoggerMonthDir + "\\PreRegistrationLog-" + DateTime.Now.ToString("MM.dd.yyy") + ".txt", true))
                {
                    stream.WriteLine("********************************************");
                    stream.WriteLine("Date: " + DateTime.Now);
                    stream.WriteLine(lines);

                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("some reason to rethrow", ex);
            }
        }
    }
}
