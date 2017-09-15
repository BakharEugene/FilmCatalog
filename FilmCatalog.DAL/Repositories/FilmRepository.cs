using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmCatalog.DAL.EF;
using FilmCatalog.DAL.Models;

namespace FilmCatalog.DAL.Repositories
{
    public class FilmRepository:IRepository<Film>
    {
        private FilmCatalogContext _applicationDbContext;

        public FilmRepository(FilmCatalogContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Film> GetAll()
        {
            List<Film> Films = _applicationDbContext.Films.ToList();
            return Films.ToList();
        }

        public Film GetById(int? id)
        {
            return _applicationDbContext.Films.Find(id);
        }

        public void Create(Film item)
        {
            _applicationDbContext.Films.Add(item);
        }

        public void Update(Film item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Films.Find(id) != null)
            {
                _applicationDbContext.Films.Remove(_applicationDbContext.Films.Find(id));
            }
        }
    }
}