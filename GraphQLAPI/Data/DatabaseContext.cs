using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Data
{
    public class BillionDatabaseContext : DbContext
    {
        public BillionDatabaseContext (DbContextOptions<BillionDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<City> City { get; set; }

        public DbSet<Airport> Airport { get; set; }

        public DbSet<Country> Country { get; set; }

    }
}
