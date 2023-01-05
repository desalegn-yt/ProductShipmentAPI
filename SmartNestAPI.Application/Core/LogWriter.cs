using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using Microsoft.AspNetCore.Hosting;

namespace SmartNestAPI.Application.Core
{
    public class LogWriter
    {
        private static IWebHostEnvironment _hostingEnvironment;

        public LogWriter(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void WriteLog(string text)
        {
            try
            {
                var logFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Logs\\");
                if (!Directory.Exists(logFilePath))
                {
                    Directory.CreateDirectory(logFilePath);
                }
                var fileName = "Log.txt";
                StreamWriter sw = new StreamWriter(logFilePath + fileName, true);
                sw.WriteLine(DateTime.UtcNow.AddHours(3) + " ... " + text);
                sw.Dispose();

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ex"></param>
        public void WriteLog(string text, Exception ex)
        {
            try
            {
                var logFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Logs\\");

                if (!Directory.Exists(logFilePath))
                {
                    Directory.CreateDirectory(logFilePath);
                }


                var fileName = "Log.txt";
                StreamWriter sw = new StreamWriter(logFilePath + fileName, true);
                var exception = ex.Message + " >> " + ex.InnerException?.Message + " >>> " + ex.InnerException?.InnerException?.Message;

                sw.WriteLine(DateTime.UtcNow.AddHours(3) + " ... " + text + " Exception: " + exception);
                sw.Dispose();
            }
            catch (Exception e)
            {

            }
        }

        public void WriteLog(string text, string fileName)
        {
            try
            {
                var logFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Logs\\");

                if (!Directory.Exists(logFilePath))
                {
                    Directory.CreateDirectory(logFilePath);
                }

                StreamWriter sw = new StreamWriter(logFilePath + fileName, true);

                sw.WriteLine(DateTime.UtcNow.AddHours(3) + " ... " + text);
                sw.Dispose();

            }
            catch (Exception e)
            {

            }
        }

        public static void WriteLog(string text, string fileName, Exception ex)
        {
            try
            {
                var logFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Logs\\");

                if (!Directory.Exists(logFilePath))
                {
                    Directory.CreateDirectory(logFilePath);
                }

                StreamWriter sw = new StreamWriter(logFilePath + fileName, true);
                var exception = ex.Message + " >> " + ex.InnerException?.Message + " >>> " + ex.InnerException?.InnerException?.Message;

                sw.WriteLine(DateTime.UtcNow.AddHours(3) + " ... " + text + " Exception: " + exception);
                sw.Dispose();

            }
            catch (Exception e)
            {

            }
        }

    }
}