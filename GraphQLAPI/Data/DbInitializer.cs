using System.Linq;

namespace GraphQLAPI.Data
{
    public static class DbInitializer
    {

        public static void Initialize(this BillionDatabaseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.City.Any())
            {
                return;   // DB has been seeded
            }

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
