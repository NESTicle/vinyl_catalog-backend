using System.Collections.Generic;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Vinyls;

namespace VinylCollection.Data.Models.Parameters
{
    public class SubGenre : BaseEntity
    {
        public int Id_Genre { get; set; }
        public string Name { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<Vinyl> Vinyls { get; set; }
    }
}
