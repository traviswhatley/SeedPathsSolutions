﻿using System.Web;
using System.Web.Mvc;

namespace MyBlog_Class4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}