using StoneMarket.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;
using Microsoft.AspNetCore.Http;
namespace StoneMarket.Core.Classes
{
    public class CodeFactory
    {
        private static Random random = new Random();
        public static string UploadedFile(IFormFile? file, string uploadsFolder)
        {
            string? uniqueFileName = null;

            if (file != null)
            {
                
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public static string RandomString()
        {
            var st = new StringBuilder();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string randStr = new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            st.Append(randStr);
           string randNum =  random.Next(1000, 9999).ToString();
            st.Append("-");
            st.Append(randNum);
            return st.ToString();
        }

        public static string PersianDate()
        {
            PersianCalendar pc = new PersianCalendar();
            string date = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") +
                             "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");
            return date;
        }
    }
}
