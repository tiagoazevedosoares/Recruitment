using Recruitment.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Data
{
    public class RecruitmentInitializer : DropCreateDatabaseAlways<RecruitmentContext> //DropCreateDatabaseIfModelChanges<RecruitmentContext>
    {
        protected override void Seed(RecruitmentContext context)
        {
            //tags
            var tags = new List<Tag>
            {
                new Tag{Name = ".NET"},
                new Tag{Name = "C#"},
                new Tag{Name = "ASP.NET"},
                new Tag{Name = "Webforms"},
                new Tag{Name = "MVC"},
                new Tag{Name = "Python"},
                new Tag{Name = "Javascript"},
                new Tag{Name = "jquery"},
                new Tag{Name = "bootstrap"},
                new Tag{Name = "AngularJS"},
                new Tag{Name = "KnockoutJS"},
                new Tag{Name = "SQL Server"}
            };
            tags.ForEach(t => context.Tags.Add(t));
            context.SaveChanges();

            //companies
            var companies = new List<Company>
            {
                new Company{Name = "Company1", CreateDate = DateTime.Now, CreateUser = "seeder"}
            };
            companies.ForEach(c => context.Companies.Add(c));
            context.SaveChanges();

            //recruiters
            var recruiters = new List<Recruiter>
            {
                new Recruiter{CompanyId = 1, FirstName = "Tiago", LastName = "Soares", Email = "tiago@email.com", Password = "123", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Recruiter{CompanyId = 1, FirstName = "Claudia", LastName = "Goncalves", Email = "claudia@email.com", Password = "123", CreateDate = DateTime.Now, CreateUser = "seeder"}
            };
            recruiters.ForEach(r => context.Recruiters.Add(r));
            context.SaveChanges();

            foreach (Recruiter rec in recruiters)
            {
                rec.Tags = new List<Tag>();
                rec.Tags.Add(tags[0]);
                rec.Tags.Add(tags[1]);
                rec.Tags.Add(tags[2]);
                rec.Tags.Add(tags[3]);
                rec.Tags.Add(tags[4]);

                context.Recruiters.Attach(rec);
            }
            context.SaveChanges();

            //candidates
            var candidates = new List<Profile>
            {
                new Profile{FirstName = "André", LastName = "Soares", Email = "tiago@email.com", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Profile{FirstName = "Augusta", LastName = "Goncalves", Email = "claudia@email.com", CreateDate = DateTime.Now, CreateUser = "seeder"}
            };
            candidates.ForEach(c => context.Profiles.Add(c));
            context.SaveChanges();

            foreach (Profile prof in candidates)
            {
                prof.Tags = new List<Tag>();
                prof.Tags.Add(tags[0]);
                prof.Tags.Add(tags[1]);
                prof.Tags.Add(tags[2]);
                prof.Tags.Add(tags[3]);
                if (prof.ProfileId == 1)
                    prof.Tags.Add(tags[4]);

                context.Profiles.Attach(prof);
            }
            context.SaveChanges();

            //clients
            var clients = new List<Client>
            {
                new Client{Name = "Bank ABC", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Client{Name = "Inovation Ltd.", CreateDate = DateTime.Now, CreateUser = "seeder"},
            };
            clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();

            foreach (var client in clients)
            {
                client.Recruiters = new List<Recruiter>();
                client.Recruiters.Add(recruiters[0]);
                if (client.ClientId == 1)
                    client.Recruiters.Add(recruiters[1]);

                context.Clients.Attach(client);
            }
            context.SaveChanges();

            foreach (Client client in clients)
            {
                client.Tags = new List<Tag>();
                client.Tags.Add(tags[0]);
                client.Tags.Add(tags[1]);
                client.Tags.Add(tags[2]);
                client.Tags.Add(tags[3]);
                if (client.ClientId == 1)
                    client.Tags.Add(tags[4]);

                context.Clients.Attach(client);
            }
            context.SaveChanges();

            //roles
            var roles = new List<Role>
            {
                new Role{ClientId = 1, RecruiterId = 1, Title = "MVC Senior Developer", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 1, RecruiterId = 2, Title = "MVC Senior Developer", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 1, RecruiterId = 2, Title = "MVC Junior Developer", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 1, Title = "MVC Junior Developer", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 2, RecruiterId = 1, Title = "Webforms Senior Developer", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 2, RecruiterId = 1, Title = "Webforms Junior Developer", CreateDate = DateTime.Now, CreateUser = "seeder"}
            };
            roles.ForEach(c => context.Roles.Add(c));
            context.SaveChanges();

            foreach (Role role in roles)
            {
                role.Tags = new List<Tag>();
                role.Tags.Add(tags[0]);
                role.Tags.Add(tags[1]);
                role.Tags.Add(tags[2]);
                if (role.RoleId > 4)
                    role.Tags.Add(tags[3]);
                else
                    role.Tags.Add(tags[4]);

                context.Roles.Attach(role);
            }
            context.SaveChanges();

            //applications
            var applications = new List<Application>
            {
                new Application(){ProfileId = 1, RecruiterId = 1, RoleId = 1, Status = ApplicationStatus.Added, CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Application(){ProfileId = 2, RecruiterId = 1, RoleId = 1, Status = ApplicationStatus.Added, CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Application(){ProfileId = 2, RecruiterId = 2, RoleId = 2, Status = ApplicationStatus.CVSentToClient, CreateDate = DateTime.Now, CreateUser = "seeder"}
            };
            applications.ForEach(a => context.Applications.Add(a));
            context.SaveChanges();

            //notes
            var notes = new List<Note>
            {
                new Note(){RecruiterId = 1, Text = "bla bla bla bla", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Note(){RecruiterId = 1, Text = "bla2 bla2 bla2 bla2", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Note(){RecruiterId = 2, Text = "bla2 bla2 bla2 bla2", CreateDate = DateTime.Now, CreateUser = "seeder"}
            };
            notes.ForEach(n => context.Notes.Add(n));
            context.SaveChanges();
        }
    }
}
