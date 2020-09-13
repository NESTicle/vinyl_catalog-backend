using System;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Parameters;
using VinylCollection.Data.Models.Security;

namespace VinylCollection.Data.Models.Vinyls
{
    public class Vinyl : BaseEntity
    {
        public int Id_User { get; set; }
        public int Id_Country { get; set; }
        public int Id_SubGenre { get; set; }

        public string Band { get; set; }
        public string Album { get; set; }
        
        public string CoverURL { get; set; }
        public DateTime DateReleased { get; set; }
        public string Info { get; set; }
        public string Color { get; set; }
        public int Disc { get; set; }

        public decimal Price { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public string Currency { get; set; }

        public virtual User User { get; set; }
        public virtual Country Country { get; set; }
        public virtual SubGenre SubGenre { get; set; }
    }
}
