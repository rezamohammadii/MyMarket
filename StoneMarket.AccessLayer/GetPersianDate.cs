
using System.Globalization;


namespace StoneMarket.AccessLayer
{
    public class GetPersianDate
    {
        public static string GetPersianTime()
        {
            PersianCalendar pc = new PersianCalendar();
            string date = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") +
                             "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");
            return date;
        }
    }
}
