using System.Collections.Generic;
using VinylCollection.Data.Models.Base;

namespace VinylCollection.Data.Models.Parameters
{
    public class Genre : BaseEntity
    {
        public Genre()
        {
            SubGenres = new HashSet<SubGenre>();
        }

        public string Name { get; set; }

        public virtual ICollection<SubGenre> SubGenres { get; set; }
    }
}
