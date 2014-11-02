using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model
{
    public enum ApplicationStatus : int
    {
        Added,
        CVSentToClient,
        TelefoneScreening,
        FaceToFace,
        Rejected
    }

    public class Application : BaseModel
    {
        public int ApplicationId { get; set; }
        public ApplicationStatus Status { get; set; }

        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public int RecruiterId { get; set; }
        public virtual Recruiter Recruiter { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}