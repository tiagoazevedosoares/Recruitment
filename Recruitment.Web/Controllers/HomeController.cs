using Recruitment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recruitment.Web.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var s = new RecruitmentContext().Recruiters.ToList();

            //var s2 = new RecruitmentContext().Recruiters.Include("Candidates").ToList();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
