using System.Globalization;

namespace BoniboNews.DateTime
{
    public class PersianDate
    {
        public static string Persian()
        {
            PersianCalendar pc = new PersianCalendar();
            var persianDate = pc.GetYear(System.DateTime.Now) + " / " +
                  pc.GetMonth(System.DateTime.Now).ToString("00") + " / " +
                  pc.GetDayOfMonth(System.DateTime.Now).ToString("00");
            return persianDate;
        }
    }
}
