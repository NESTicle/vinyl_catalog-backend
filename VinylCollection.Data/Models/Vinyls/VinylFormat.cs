using System.Collections.Generic;
using VinylCollection.Data.Models.Base;

namespace VinylCollection.Data.Models.Vinyls
{
    public class VinylFormat : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Vinyl> Vinyls { get; set; }
    }
}
