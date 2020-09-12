﻿using Microsoft.EntityFrameworkCore;
using VinylCollection.Data.Models.Communities;
using VinylCollection.Data.Models.Mappings.Models;
using VinylCollection.Data.Models.Parameters;
using VinylCollection.Data.Models.Security;
using VinylCollection.Data.Models.Vinyls;

namespace VinylCollection.Data.Models.Base
{
    public class VinylDbContext : DbContext
    {
        #region Communities

        public DbSet<Community> Community { get; set; }

        #endregion

        #region Vinyl

        public DbSet<Vinyl> Vinyl { get; set; }

        #endregion

        #region Parameters

        public DbSet<Country> Country { get; set; }

        #endregion

        #region Security

        public DbSet<User> User { get; set; }

        #endregion

        public VinylDbContext(DbContextOptions<VinylDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new VinylMap());
            modelBuilder.ApplyConfiguration(new CommunityMap());
            modelBuilder.ApplyConfiguration(new CountryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}