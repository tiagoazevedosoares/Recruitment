using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model
{
    public class Note : BaseModel
    {
        public int NoteId { get; set; }
        public string Text { get; set; }
        public DateTime? Reminder { get; set; }
        public bool Public { get; set; }

        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public int RecruiterId { get; set; }
        public virtual Recruiter Recruiter { get; set; }

        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}