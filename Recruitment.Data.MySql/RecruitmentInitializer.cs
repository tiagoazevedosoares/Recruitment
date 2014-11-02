using Recruitment.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Data
{
    public class RecruitmentInitializer : DropCreateDatabaseIfModelChanges<RecruitmentContext>
    {
        protected override void Seed(RecruitmentContext context)
        {
            //recruiters
            var recruiters = new List<Recruiter>
            {
                new Recruiter{FirstName = "Tiago", LastName = "Soares", Email = "tiago@email.com", Password = "123"},
                new Recruiter{FirstName = "Claudia", LastName = "Goncalves", Email = "claudia@email.com", Password = "123", CreateDate = DateTime.Now, CreateUser = "seeder"}
            };
            recruiters.ForEach(r => context.Recruiters.Add(r));
            context.SaveChanges();

            //candidates
            var candidates = new List<Profile>
            {
                new Profile{FirstName = "André", LastName = "Soares", Email = "tiago@email.com", CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Profile{FirstName = "Augusta", LastName = "Goncalves", Email = "claudia@email.com", CreateDate = DateTime.Now, CreateUser = "seeder"}
            };
            candidates.ForEach(c => context.Candidates.Add(c));
            context.SaveChanges();

            //clients
            var clients = new List<Client>
            {
                new Client{Name = "Bank ABC", Tags = new List<string>(){".net", "c#", "mvc"}, CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Client{Name = "Inovation Ltd.", Tags = new List<string>(){".net", "c#", "asp.net", "webforms"}, CreateDate = DateTime.Now, CreateUser = "seeder"},
            };
            clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();

            foreach (var client in clients)
            {
                client.Recruiters = new List<Recruiter>();
                client.Recruiters.Add(recruiters[0]);
                if(client.ClientId == 1)
                    client.Recruiters.Add(recruiters[1]);

                context.Clients.Attach(client);
            }
            context.SaveChanges();

            //roles
            var roles = new List<Role>
            {
                new Role{ClientId = 1, RecruiterId = 1, Title = "MVC Senior Developer", Tags = new List<string>(){".net", "c#", "mvc"}, CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 1, RecruiterId = 2, Title = "MVC Senior Developer", Tags = new List<string>(){".net", "c#", "mvc"}, CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 1, RecruiterId = 2, Title = "MVC Junior Developer", Tags = new List<string>(){".net", "c#", "mvc"}, CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 1, Title = "MVC Junior Developer", Tags = new List<string>(){".net", "c#", "mvc"}, CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 2, RecruiterId = 1, Title = "Webforms Senior Developer", Tags = new List<string>(){".net", "c#", "mvc"}, CreateDate = DateTime.Now, CreateUser = "seeder"},
                new Role{ClientId = 2, RecruiterId = 1, Title = "Webforms Junior Developer", Tags = new List<string>(){".net", "c#", "asp.net", "webforms"}, CreateDate = DateTime.Now, CreateUser = "seeder"}
            };
            roles.ForEach(c => context.Roles.Add(c));
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
                new Note(){ RecruiterId = 1, Text = "bla bla bla bla"},
                new Note(){ RecruiterId = 1, Text = "bla2 bla2 bla2 bla2"},
                new Note(){ RecruiterId = 2, Text = "bla2 bla2 bla2 bla2"}
            };
            notes.ForEach(n => context.Notes.Add(n));
            context.SaveChanges();
        }
    }
}
