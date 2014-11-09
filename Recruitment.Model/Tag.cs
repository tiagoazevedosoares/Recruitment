using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }

        public ICollection<Recruiter> Recruiters { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<Profile> Profiles { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
