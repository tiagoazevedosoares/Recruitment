using Recruitment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Data
{
    public class UnitOfWork : IDisposable
    {
        private RecruitmentContext context = new RecruitmentContext();

        private GenericRepository<Profile> profileRepository;
        private RecruiterRepository recruiterRepository;
        private GenericRepository<Client> clientRepository;
        private GenericRepository<Role> roleRepository;
        private GenericRepository<Application> applicationRepository;
        private GenericRepository<Note> noteRepository;
        private GenericRepository<Tag> tagRepository;

        public GenericRepository<Profile> ProfileRepository
        {
            get
            {

                if (this.profileRepository == null)
                {
                    this.profileRepository = new GenericRepository<Profile>(context);
                }
                return this.profileRepository;
            }
        }
        public RecruiterRepository RecruiterRepository
        {
            get
            {

                if (this.recruiterRepository == null)
                {
                    this.recruiterRepository = new RecruiterRepository(context);
                }
                return this.recruiterRepository;
            }
        }
        public GenericRepository<Client> ClientRepository
        {
            get
            {

                if (this.clientRepository == null)
                {
                    this.clientRepository = new GenericRepository<Client>(context);
                }
                return this.clientRepository;
            }
        }
        public GenericRepository<Role> RoleRepository
        {
            get
            {

                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(context);
                }
                return this.roleRepository;
            }
        }
        public GenericRepository<Application> ApplicationRepository
        {
            get
            {

                if (this.applicationRepository == null)
                {
                    this.applicationRepository = new GenericRepository<Application>(context);
                }
                return this.applicationRepository;
            }
        }
        public GenericRepository<Note> NoteRepository
        {
            get
            {

                if (this.noteRepository == null)
                {
                    this.noteRepository = new GenericRepository<Note>(context);
                }
                return this.noteRepository;
            }
        }
        public GenericRepository<Tag> TagRepository
        {
            get
            {

                if (this.tagRepository == null)
                {
                    this.tagRepository = new GenericRepository<Tag>(context);
                }
                return this.tagRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
