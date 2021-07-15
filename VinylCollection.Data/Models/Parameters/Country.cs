using System.Collections.Generic;
using VinylCollection.Data.Models.Vinyls;

namespace VinylCollection.Data.Models.Parameters
{
    public class Country
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Vinyl> Vinyls { get; set; }
    }
}
