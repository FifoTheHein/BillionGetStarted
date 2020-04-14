using System;
using System.ComponentModel.DataAnnotations;

namespace Geography.Models
{
    public class City
    {
        public Guid CityID { get; set; }
        public int geonameid { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string ASCIITitle { get; set; }

        [MaxLength(10000)]
        public string AlternateTitles { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [MaxLength(2)]
        public string CountryCode { get; set; }

        [MaxLength(40)]
        public string Timezone { get; set; }
    }
}
