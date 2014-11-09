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
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Document> Documents { get; set; }

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

            modelBuilder.Entity<Tag>().
                HasMany(c => c.Recruiters).
                WithMany(p => p.Tags).
                Map(
                 m =>
                 {
                     m.MapLeftKey("TagId");
                     m.MapRightKey("RecruiterId");
                     m.ToTable("RecruiterTags");
                 });

            modelBuilder.Entity<Tag>().
                HasMany(c => c.Roles).
                WithMany(p => p.Tags).
                Map(
                 m =>
                 {
                     m.MapLeftKey("TagId");
                     m.MapRightKey("RoleId");
                     m.ToTable("RoleTags");
                 });

            modelBuilder.Entity<Tag>().
                HasMany(c => c.Profiles).
                WithMany(p => p.Tags).
                Map(
                 m =>
                 {
                     m.MapLeftKey("TagId");
                     m.MapRightKey("ProfileId");
                     m.ToTable("ProfileTags");
                 });

            modelBuilder.Entity<Tag>().
                HasMany(c => c.Clients).
                WithMany(p => p.Tags).
                Map(
                 m =>
                 {
                     m.MapLeftKey("TagId");
                     m.MapRightKey("ClientId");
                     m.ToTable("ClientTags");
                 });
        }
        //used for seeding. not needed after db initialization
    }
}
