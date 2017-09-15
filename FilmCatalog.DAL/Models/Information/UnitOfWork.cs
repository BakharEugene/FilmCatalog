using System;
using FilmCatalog.DAL.EF;
using FilmCatalog.DAL.Repositories;

namespace FilmCatalog.DAL.Models.Information
{
    public class UnitOfWork
    {
        FilmCatalogContext db = new FilmCatalogContext();
        private RoleRepository roleRepository;
        private UserRepository userRepository;
        private PosterRepository posterRepository;
        private FilmRepository filmRepository;

        public FilmRepository Films
        {
            get
            {
                if (filmRepository == null)
                    filmRepository = new FilmRepository(db);
                return filmRepository;
            }

        }



        public PosterRepository Posters
        {
            get
            {
                if (posterRepository == null)
                    posterRepository = new PosterRepository(db);
                return posterRepository;
            }

        }


        public RoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }

        }


        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}