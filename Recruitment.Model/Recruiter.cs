using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model
{
    public class Recruiter : BaseModel
    {
        public int RecruiterId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? WrongPasswords { get; set; }
        public bool ChangePassword { get; set; }

        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        
        public virtual ICollection<Profile> Profiles { get; set; }
        
        public virtual ICollection<Application> Applications { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
