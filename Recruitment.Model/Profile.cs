﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model
{
    public class Profile : BaseModel
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Tags { get; set; }

        public virtual ICollection<Recruiter> Recruiters { get; set; }
        
        public virtual ICollection<Application> Applications { get; set; }
    }
}
