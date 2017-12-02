﻿using RedSocial.Code;
using System.Web;
using System.Web.Mvc;

namespace RedSocial
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomAuthorize());
        }
    }
}
