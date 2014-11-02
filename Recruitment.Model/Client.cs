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
        [NotMapped]
        public List<string> Tags
        {
            get
            {
                return this.TagList.Split(';').ToList();
            }
            set 
            {
                this.TagList = string.Join(";", value);
            }
        }
        public string TagList { get; set; }

        public virtual ICollection<Recruiter> Recruiters { get; set; }
        
        public virtual ICollection<Role> Roles { get; set; }
    }
}
