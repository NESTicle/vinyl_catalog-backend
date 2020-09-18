using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Vinyls;
using VinylCollection.Domain.Helper;
using VinylCollection.Domain.Transversal;
using VinylCollection.Service.Interfaces;

namespace VinylCollection.Service.Implementations
{
    public class VinylService : IVinylService
    {
        private readonly VinylDbContext _context;
        private IAppPrincipal _appPrincipal { get; }

        public VinylService(VinylDbContext context, IAppPrincipal appPrincipal)
        {
            _context = context;
            _appPrincipal = appPrincipal;
        }

        public List<Vinyl> GetVinyls(QueryParamsHelper queryParameters, string search)
        {
            try
            {
                var query = _context.Vinyl
                    .Include(x => x.SubGenre.Genre)
                    .Include(x => x.Country)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(search))
                    query = query.Where(x => x.Band.ToLower().Contains(search.ToLower()));

                var vinylList = query.Where(x => x.Id_User == _appPrincipal.Id)
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
                    model.Id_User = _appPrincipal.Id;
                    _context.Vinyl.Add(model);
                }
                else
                {
                    var entity = GetVinylById(model.Id);

                    entity.Band = model.Band;
                    entity.Album = model.Album;
                    entity.Id_SubGenre = model.Id_SubGenre;
                    entity.CoverURL = model.CoverURL;
                    entity.DateReleased = model.DateReleased;
                    entity.Country = model.Country;
                    entity.Info = model.Info;
                    entity.Color = model.Color;
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
