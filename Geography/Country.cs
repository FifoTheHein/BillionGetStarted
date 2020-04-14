using System;
using System.ComponentModel.DataAnnotations;

namespace Geography
{
    public class Country
    { 
        
        [MaxLength(2)]
        [Key]
       public string ISO { get; set; }

       [MaxLength(3)]
       public string ISO3 { get; set; }

       [MaxLength(2)]
       public string FIPS { get; set; }

       [MaxLength(200)]
       public string Title { get; set; }

       [MaxLength(200)]
       public string Capital { get; set; }

       [MaxLength(20)]
       public string Continent { get; set; }

       [MaxLength(3)]
       public string CurrencyCode { get; set; }

       [MaxLength(20)]
       public string CurrencyName { get; set; }

       [MaxLength(10)]
       public string PhonePrefix { get; set; }

       [MaxLength(100)]
       public string Languages { get; set; }

       public int geonameid { get; set; }
    }
}
