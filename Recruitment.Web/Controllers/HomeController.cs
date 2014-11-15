using Recruitment.Data;
using Recruitment.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recruitment.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string searchText)
        {
            return View();
        }

        public PartialViewResult QuickSearch(string searchText)
        {
            QuickSearchViewModel viewModel = new QuickSearchViewModel();
            using(RecruitmentContext context = new RecruitmentContext())
            {
                viewModel.SearchText = searchText;
                viewModel.Recruiters = context.Recruiters.Where(r => r.LastName.Contains(searchText) || r.FirstName.Contains(searchText)).ToList();
                viewModel.Clients = context.Clients.Where(c => c.Name.Contains(searchText)).ToList();
                viewModel.Profiles = context.Profiles.Where(p => p.LastName.Contains(searchText) || p.FirstName.Contains(searchText)).ToList();
                viewModel.Roles = context.Roles.Where(r => r.Title.Contains(searchText)).ToList();
            }
            return PartialView(viewModel);
        }
    }
}
