using System;
using System.ComponentModel.DataAnnotations;

namespace Geography
{
    public class Timezone
    {

        [MaxLength(2)]
        public string CountryCode { get; set; }

        [Key]
        [MaxLength(40)]
        public string TimeZoneId { get; set; }


        public double GMTOffset { get; set; }
        public double DSTOffset { get; set; }

        public double RawOffset { get; set; }
    }
}
