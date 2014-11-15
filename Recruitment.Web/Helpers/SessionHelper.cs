using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Web.Helpers
{
    public class SessionHelper
    {
        public static int UserId
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies["user"];
                if (cookie != null)
                    return int.Parse(cookie["id"]);

                if (HttpContext.Current.Session["UserId"] != null)
                    return int.Parse(HttpContext.Current.Session["UserFullName"].ToString());

                return -1;
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static string UserFullName
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies["user"];
                if (cookie != null)
                    return cookie["fullname"];

                if (HttpContext.Current.Session["UserFullName"] != null)
                    return HttpContext.Current.Session["UserFullName"].ToString();

                return "John Doe";
            }
            set
            {
                HttpContext.Current.Session["UserFullName"] = value;
            }
        }
    }
}