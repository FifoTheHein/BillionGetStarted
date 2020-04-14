using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Geography
{
    public class GeographyContext: DbContext
    {
        public GeographyContext(DbContextOptions<GeographyContext> options) : base(options)
        { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Timezone> Timezones { get; set; }
    }
}
