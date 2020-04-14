using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Data
{
    public static class DbInitializer
    {

        public static void Initialize(this BillionDatabaseContext context)
        {
            context.Database.Migrate();

            if (!context.Country.Any(c => c.IsDeleted == false))
            {
                var countries = new Country[]
                {
                    new Country{Title = "South Africa"},
                    new Country{Title = "United States Of America"}
                };
                foreach (Country s in countries)
                {
                    context.Country.Add(s);
                }
                context.SaveChanges();

                if (!context.City.Any(c => c.IsDeleted == false))
                {
                    foreach (Country country in context.Country)
                    {
                        if (country.Title == "South Africa")
                        {
                            country.Cities.Add(new City(){Title = "Johannesburg"});
                            country.Cities.Add(new City(){Title = "Durban"});
                            country.Cities.Add(new City(){Title = "Cape Town"});
                        }
                    
                    }

                    context.SaveChanges();


                    foreach (City city in context.City)
                    {
                        if(city.Title == "Johannesburg")
                            city.Airports.Add(new Airport(){IATACode = "JNB", ICAOCode = "FAOR", Lat = -26.13920M, Lon = 28.24600M, Title = "OR Tambo International Airport"});
                        else if(city.Title == "Durban")
                            city.Airports.Add(new Airport(){IATACode = "DUR", ICAOCode = "FALE", Lat = -29.61444M, Lon = 31.11972M, Title = "King Shaka International Airport"});
                        else if(city.Title == "Cape Town")
                            city.Airports.Add(new Airport(){IATACode = "CPT", ICAOCode = "FACT", Lat = -33.96480M, Lon = 18.60170M, Title = "Cape Town International Airport"});
                    }

                    context.SaveChanges();
                }
                else
                {

                    var sa = context.Country
                        .FirstOrDefault(c => c.Title == "South Africa");
                    foreach (City city in context.City)
                    {
                        sa.Cities.Add(city);
                    }

                    context.SaveChanges();
                }
            }

            if (!context.City.Any(c => c.IsDeleted == false))
            {
                var cities = new City[]
                {
                    new City{Title = "Johannesburg"},
                    new City{Title = "Durban"},
                    new City{Title = "Cape Town"}
                
                };
                foreach (City s in cities)
                {
                    context.City.Add(s);
                }
                context.SaveChanges();

                foreach (City city in context.City)
                {
                    if(city.Title == "Johannesburg")
                        city.Airports.Add(new Airport(){IATACode = "JNB", ICAOCode = "FAOR", Lat = -26.13920M, Lon = 28.24600M, Title = "OR Tambo International Airport"});
                    else if(city.Title == "Durban")
                        city.Airports.Add(new Airport(){IATACode = "DUR", ICAOCode = "FALE", Lat = -29.61444M, Lon = 31.11972M, Title = "King Shaka International Airport"});
                    else if(city.Title == "Cape Town")
                        city.Airports.Add(new Airport(){IATACode = "CPT", ICAOCode = "FACT", Lat = -33.96480M, Lon = 18.60170M, Title = "Cape Town International Airport"});
                }

                context.SaveChanges();
            }

        }
    }
}
