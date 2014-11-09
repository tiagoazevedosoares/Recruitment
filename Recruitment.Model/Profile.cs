using System;
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
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public bool EUCitizen { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? YearStartedWorking { get; set; }
        public int? YearsExperience { 
            get {
                if (YearStartedWorking.HasValue)
                    return DateTime.Now.Year - YearStartedWorking;
                else
                    return null;
            } 
        }
        public string CurrentEmployee { get; set; }
        public RoleType? CurrentRoleType { get; set; }
        public int? CurrentSalary { get; set; }
        public int? CurrentDailyRate { get; set; }
        public DateTime? CurrentContractStartDate { get; set; }
        public int? CurrentContractLength { get; set; }
        public DateTime? CurrentContractEnd {
            get {
                if (this.CurrentContractStartDate.HasValue && this.CurrentContractLength.HasValue)
                    return this.CurrentContractStartDate.Value.AddMonths(this.CurrentContractLength.Value);
                else
                    return null;
            }
        }

        public virtual ICollection<Recruiter> Recruiters { get; set; }
        
        public virtual ICollection<Application> Applications { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
