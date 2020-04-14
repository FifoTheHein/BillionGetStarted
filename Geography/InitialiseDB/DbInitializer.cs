using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Geography.Models;
using Microsoft.EntityFrameworkCore;

namespace Geography.InitialiseDB
{
    public static class DbInitializer
    {

        public static void Initialize(this GeographyContext context)
        {
            context.Database.Migrate();

            if (!context.Countries.Any())
            {

                using (var reader = new StreamReader("InitialiseDB/Countries.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Country>();

                    foreach (Country country in records)
                    {
                        context.Countries.Add(country);
                    }
                }


                context.SaveChanges();



            }

            if (!context.Cities.Any())
            {
                using (var reader = new StreamReader("InitialiseDB/Cities.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<CityMap>();
                    var records = csv.GetRecords<City>();

                    foreach (City city in records)
                    {
                        context.Cities.Add(city);
                    }
                }

                context.SaveChanges();

            }

            if (!context.Timezones.Any())
            {
                using (var reader = new StreamReader("InitialiseDB/Timezones.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        var records = csv.GetRecords<Timezone>();

                        foreach (Timezone timezone in records)
                        {
                            context.Timezones.Add(timezone);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                
                context.SaveChanges();

            }

        }
    }

    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Map(m => m.geonameid);
            Map(m => m.Title);
            Map(m => m.ASCIITitle);
            Map(m => m.AlternateTitles);
            Map(m => m.Latitude);
            Map(m => m.Longitude);
            Map(m => m.CountryCode);
            Map(m => m.Timezone);
        }
    }
}
