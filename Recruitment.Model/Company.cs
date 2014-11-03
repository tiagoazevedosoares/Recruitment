using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Recruitment.Model
{
    public class Company : BaseModel
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Recruiter> Recruiters { get; set; }
    }
}
