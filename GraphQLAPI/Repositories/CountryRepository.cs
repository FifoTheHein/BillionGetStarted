using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Repositories
{
    public class CountryRepository
    {
        private readonly BillionDatabaseContext _dbContext;

        public CountryRepository(BillionDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Country>> GetAllWithChildren()
        {
            return await _dbContext.Country
                .Where(c=>c.IsDeleted == false)
                .Include(country => country.Cities)
                .ThenInclude(city=>city.Airports)
                .ToListAsync();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _dbContext.Country
                .Where(c=>c.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<Country> GetOne(string title)
        {
            return await _dbContext.Country
                .Where(c=>c.IsDeleted == false)
                .Include(c=>c.Cities)
                .SingleOrDefaultAsync(p => p.Title == title);
        }

        public async Task<Country> GetOne(Guid countryId)
        {
            return await _dbContext.Country
                .Where(c=>c.IsDeleted == false)
                .Include(c=>c.Cities)
                .SingleOrDefaultAsync(p => p.CountryID == countryId);
        }

        public Country GetOneNow(Guid countryId)
        {
            return  _dbContext.Country
                .Where(c=>c.IsDeleted == false)
                .Include(c=>c.Cities)
                .SingleOrDefault(p => p.CountryID == countryId);
        }

        public async Task<Country> Delete(Guid countryId)
        {
            var dbCountry = await GetOne(countryId);

            if (dbCountry == null)
            {
                return null;
            }

            foreach (City city in dbCountry.Cities)
            {
                foreach (Airport airport in city.Airports)
                    airport.IsDeleted = true;

                city.IsDeleted = true;
            }

            dbCountry.IsDeleted = true;
           
            await _dbContext.SaveChangesAsync();
            return dbCountry;
        }

        public async Task<Country> AddCountry(Country country)
        {
            _dbContext.Country.Add(country);
            await _dbContext.SaveChangesAsync();
            return country;
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            var dbCountry = await GetOne(country.CountryID);

            if (dbCountry == null)
            {
                return null;
            }

            dbCountry.Title = country.Title;
           
            await _dbContext.SaveChangesAsync();
            return dbCountry;
        }

    }
}