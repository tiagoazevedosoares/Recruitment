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
        TelephoneScreening,
        FaceToFaceInterview,
        Rejected
    }

    public enum RoleType : int
    {
        Contract,
        Permanent,
        FixedTermContract
    }

    public enum EventType : int
    {

    }
}
