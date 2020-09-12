using System;
using System.Collections.Generic;
using System.Linq;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Vinyls;
using VinylCollection.Domain.Helper;
using VinylCollection.Service.Interfaces;

namespace VinylCollection.Service.Implementations
{
    public class VinylService : IVinylService
    {
        private readonly VinylDbContext _context;

        public VinylService(VinylDbContext context)
        {
            _context = context;
        }

        public List<Vinyl> GetVinyls(QueryParamsHelper queryParameters, string search)
        {
            try
            {
                var query = _context.Vinyl.AsQueryable();

                if (!string.IsNullOrEmpty(search))
                    query = query.Where(x => x.Band.ToLower().Contains(search.ToLower()));

                var vinylList = query
                                  .OrderByDescending(x => x.DateCreated)
                                  .Skip(queryParameters.PageCount * (queryParameters.Page - 1))
                                  .Take(queryParameters.PageCount)
                                  .ToList();

                return vinylList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Vinyl GetVinylById(int id)
        {
            return _context.Vinyl.Where(x => x.Id == id).FirstOrDefault();
        }

        public int SaveVinyl(Vinyl model)
        {
            try
            {
                if(model.Id <= 0)
                {
                    model.Id_User = 3;
                    _context.Vinyl.Add(model);
                }
                else
                {
                    var entity = GetVinylById(model.Id);

                    entity.Band = model.Band;
                    entity.Album = model.Album;
                    entity.Genre = model.Genre;
                    entity.CoverURL = model.CoverURL;
                    entity.DateReleased = model.DateReleased;
                    entity.Country = model.Country;
                    entity.Info = model.Info;
                    entity.Color = model.Color;
                    entity.DatePublished = model.DatePublished;
                    entity.Disc = model.Disc;
                    entity.Link = model.Link;
                    entity.Notes = model.Notes;
                    entity.Price = model.Price;
                    entity.Type = model.Type;
                    entity.Currency = model.Currency;

                    _context.Vinyl.Update(entity);
                }

                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
