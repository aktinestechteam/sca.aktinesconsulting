using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.infrastructure.Common
{
    public static class Utilities
    {

        public static string GetDaySuffix(int day)
        {
            if (day >= 11 && day <= 13)
            {
                return "th";
            }

            switch (day % 10)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
            }
        }
        public static string GetDateSuffix(DateTime date)
        {
            string dayWithSuffix = GetDaySuffix(date.Day);
            string formattedString = $"{date.ToString("dd").ToUpper()}{dayWithSuffix.ToUpper()}_{date.ToString("MMMM").ToUpper()}{date.ToString("yy").ToUpper()}_{date.ToString("HHmm")}";
            return formattedString;
        }


    }
}
