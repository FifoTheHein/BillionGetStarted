
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GraphQLAPI;
using GraphQLAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories
{
    public class AirportRepository
    {
        private readonly BillionDatabaseContext _dbContext;

        public AirportRepository(BillionDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Airport>> GetAll()
        {
            return await _dbContext.Airport.ToListAsync();
        }

        public async Task<Airport> GetOne(string IATACode)
        {
            return await _dbContext.Airport.SingleOrDefaultAsync(p => p.IATACode == IATACode);
        }

        public async Task<Airport> GetOne(Guid airportID)
        {
            return await _dbContext.Airport.SingleOrDefaultAsync(p => p.AirportID == airportID);
        }

        public async Task<ILookup<Guid, Airport>> GetForCities(IEnumerable<Guid> cityIds)
        {
            var reviews = await _dbContext.Airport
                .Where(pr => cityIds.Contains(pr.CityID))
                .ToListAsync();
            return reviews.ToLookup(r => r.CityID);
        }

        public async Task<Airport> AddAirport(Airport airport)
        {
            _dbContext.Airport.Add(airport);
            await _dbContext.SaveChangesAsync();
            return airport;
        }

        public async Task<Airport> UpdateAirport(Airport airport)
        {
            var dbAirport = await GetOne(airport.AirportID);

            if (dbAirport == null)
            {
                return null;
            }

            dbAirport.Title = airport.Title;
            dbAirport.CityID = airport.CityID;
            dbAirport.ICAOCode = airport.ICAOCode;
            dbAirport.IATACode = airport.IATACode;
            dbAirport.Lat = airport.Lat;
            dbAirport.Lon = airport.Lon;
            
            await _dbContext.SaveChangesAsync();
            return dbAirport;
        }
    }
}
