using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCatalog.DAL.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Producer { get; set; }
        [ForeignKey("User")]
        public int? IdUser { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Poster")]
        public int? IdPoster { get; set; }
        public virtual Poster Poster { get; set; }
    }
}