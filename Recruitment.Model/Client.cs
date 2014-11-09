using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Recruitment.Model
{
    public class Client : BaseModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Recruiter> Recruiters { get; set; }
        
        public virtual ICollection<Role> Roles { get; set; }
    }
}
