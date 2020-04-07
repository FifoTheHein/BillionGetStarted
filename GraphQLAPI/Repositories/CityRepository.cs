﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLAPI;
using GraphQLAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories
{
    public class CityRepository
    {
        private readonly BillionDatabaseContext _dbContext;

        public CityRepository(BillionDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _dbContext.City.ToListAsync();
        }

        public async Task<City> GetOne(string title)
        {
            return await _dbContext.City.SingleOrDefaultAsync(p => p.Title == title);
        }

        public async Task<City> GetOne(Guid cityID)
        {
            return await _dbContext.City.SingleOrDefaultAsync(p => p.CityID == cityID);
        }

        public async Task<City> AddCity(City city)
        {
            _dbContext.City.Add(city);
            await _dbContext.SaveChangesAsync();
            return city;
        }

        public async Task<City> UpdateCity(City city)
        {
            var dbCity = await GetOne(city.CityID);

            if (dbCity == null)
            {
                return null;
            }

            dbCity.Title = city.Title;
           
            await _dbContext.SaveChangesAsync();
            return dbCity;
        }

    }
}