using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmCatalog.DAL.EF;
using FilmCatalog.DAL.Models;

namespace FilmCatalog.DAL.Repositories
{

    public class RoleRepository : IRepository<Role>
    {

        private FilmCatalogContext _applicationDbContext;

        public RoleRepository(FilmCatalogContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Role> GetAll()
        {
            List<Role> Roles = _applicationDbContext.Roles.ToList();
            return Roles.ToList();
        }

        public Role GetById(int? id)
        {
            return _applicationDbContext.Roles.Find(id);
        }

        public void Create(Role item)
        {
            _applicationDbContext.Roles.Add(item);
        }

        public void Update(Role item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Roles.Find(id) != null)
            {
                _applicationDbContext.Roles.Remove(_applicationDbContext.Roles.Find(id));
            }
        }
    }
}