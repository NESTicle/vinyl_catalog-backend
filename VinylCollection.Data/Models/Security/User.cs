using System.Collections.Generic;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Communities;
using VinylCollection.Data.Models.Vinyls;

namespace VinylCollection.Data.Models.Security
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsEmailValid { get; set; }

        public virtual ICollection<Vinyl> Vinyls { get; set; }
        public virtual ICollection<Community> Communities { get; set; }
    }
}
