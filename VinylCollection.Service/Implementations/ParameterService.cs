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
                return _context.Country
                    .OrderBy(x => x.Name)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Country GetCountryById(int id)
        {
            try
            {
                return _context.Country.FirstOrDefault(x => x.Id == id);
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

        public int AddCountry(Country country)
        {
            try
            {
                _context.Country.Add(country);
                _context.SaveChanges();

                return country.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int UpdateCountry(Country country)
        {
            try
            {
                Country model = GetCountryById(country.Id);

                if (model == null)
                    throw new Exception("An error occurred trying to update a country");

                model.Code = country.Code;
                model.Name = country.Name;

                _context.Update(model);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int AddMultipleCountries(List<Country> model)
        {
            try
            {
                _context.Country.AddRange(model);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
