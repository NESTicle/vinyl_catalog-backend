using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Parameters;
using VinylCollection.Service.Interfaces;

namespace VinylCollection.Service.Implementations
{
    public class ParameterService : IParameterService
    {
        private readonly VinylDbContext _context;

        public ParameterService(VinylDbContext context)
        {
            _context = context;
        }

        public List<Country> GetCountries()
        {
            try
            {
                return _context.Country.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Genre> GetGenres()
        {
            try
            {
                return _context.Genre.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SubGenre> GetSubGenresByGenreId(int id)
        {
            try
            {
                return _context.SubGenre.Where(x => x.Id_Genre == id).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
