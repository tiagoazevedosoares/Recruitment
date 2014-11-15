using Recruitment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Web.ViewModels
{
    public class QuickSearchViewModel : BaseViewModel
    {
        public string SearchText { get; set; }
        public List<Recruiter> Recruiters { get; set; }
        public List<Client> Clients { get; set; }
        public List<Profile> Profiles { get; set; }
        public List<Role> Roles { get; set; }
    }
}