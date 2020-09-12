using System;

namespace VinylCollection.Data.Models.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateCreated = DateTime.Now;
            Deleted = false;
        }

        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
