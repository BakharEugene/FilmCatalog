using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCatalog.DAL.Models
{
    public class Poster
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }
}