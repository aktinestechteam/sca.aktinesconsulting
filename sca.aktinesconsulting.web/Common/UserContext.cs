﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Common
{
    public static class UserContext
    {
        public static int? GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal!=null)
            {
                var userId= claimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Sid.ToString()).Select(c => c.Value).SingleOrDefault();
                if (userId != null)
                    return Convert.ToInt32(userId);
            }
            return null;
        }

    }
}