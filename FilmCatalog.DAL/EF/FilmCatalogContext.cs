using System.Data.Entity;
using FilmCatalog.DAL.Models;

namespace FilmCatalog.DAL.EF
{
    public class FilmCatalogContext:DbContext
    {

        public FilmCatalogContext() : base("DefaultConnection")
        {

        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Poster> Posters { get; set; }
    }
}