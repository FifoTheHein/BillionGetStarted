using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLAPI
{
    public class City
    {
        public Guid CityID { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public List<Airport> Airports { get; } = new List<Airport>();
    }

    public class Airport
    {
        public Guid AirportID { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(3)]
        public string IATACode { get; set; }

        [MaxLength(4)]
        public string ICAOCode { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal Lat { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal Lon { get; set; }

        public Guid CityID { get; set; }
        public City City { get; set; }

    }

   
}
