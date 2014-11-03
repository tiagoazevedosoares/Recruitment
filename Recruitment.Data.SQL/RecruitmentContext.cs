using Recruitment.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Data
{
    public class RecruitmentContext : DbContext
    {
        public RecruitmentContext()
            : base("RecruitmentContext")
        {
        }

        //used for seeding. not needed after db initialization
        public DbSet<Company> Companies { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Profile> Candidates { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Recruiter>().
                HasMany(c => c.Profiles).
                WithMany(p => p.Recruiters).
                Map(
                 m =>
                 {
                     m.MapLeftKey("RecruiterId");
                     m.MapRightKey("ProfileId");
                     m.ToTable("RecruiterCandidates");
                 });

            modelBuilder.Entity<Recruiter>().
                HasMany(c => c.Clients).
                WithMany(p => p.Recruiters).
                Map(
                 m =>
                 {
                     m.MapLeftKey("RecruiterId");
                     m.MapRightKey("ClientId");
                     m.ToTable("RecruiterClients");
                 });
        }
        //used for seeding. not needed after db initialization
    }
}
