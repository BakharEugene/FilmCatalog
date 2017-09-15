using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmCatalog.DAL.EF;
using FilmCatalog.DAL.Models;

namespace FilmCatalog.DAL.Repositories
{
    public class PosterRepository:IRepository<Poster>
    {
        private FilmCatalogContext _applicationDbContext;

        public PosterRepository(FilmCatalogContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Poster> GetAll()
        {
            List<Poster> Posters = _applicationDbContext.Posters.ToList();
            return Posters.ToList();
        }

        public Poster GetById(int? id)
        {
            return _applicationDbContext.Posters.Find(id);
        }

        public void Create(Poster item)
        {
            _applicationDbContext.Posters.Add(item);
        }

        public void Update(Poster item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Posters.Find(id) != null)
            {
                _applicationDbContext.Posters.Remove(_applicationDbContext.Posters.Find(id));
            }
        }
    }
}