using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Common
{
    public static class Extensions
    {
        public static string JoinString(this string[] args)
        {
            if (args != null)
                return string.Join("|", args);
            else
                return null;
        }
        public static DateTime StringToDate(this string args)
        {
            var date = args.Split("-");
            return new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]));
        }

        public static string NullToEmpty(this string args)
        {
            if (string.IsNullOrEmpty(args))
                return string.Empty;
            else
                return args;
        }

    }
  
}
