using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmCatalog.DAL.EF;
using FilmCatalog.DAL.Models;

namespace FilmCatalog.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private FilmCatalogContext _applicationDbContext;

        public UserRepository(FilmCatalogContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> Users = _applicationDbContext.Users.ToList();
            return Users.ToList();
        }

        public User GetById(int? id)
        {
            return _applicationDbContext.Users.Find(id);
        }

        public void Create(User item)
        {
            _applicationDbContext.Users.Add(item);
        }

        public void Update(User item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Users.Find(id) != null)
            {
                _applicationDbContext.Users.Remove(_applicationDbContext.Users.Find(id));
            }
        }
    }
}