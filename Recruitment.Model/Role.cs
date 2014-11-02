using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model
{
    public class Role : BaseModel
    {
        public int RoleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int? RecruiterId { get; set; }
        public virtual Recruiter Recruiter { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
