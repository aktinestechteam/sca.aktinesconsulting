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
    }
  
}
