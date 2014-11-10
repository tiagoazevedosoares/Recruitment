using Recruitment.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace Recruitment.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}