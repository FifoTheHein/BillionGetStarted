using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geography.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Geography.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimezoneController : ControllerBase
    {
        private readonly ILogger<TimezoneController> _logger;

        private readonly GeographyContext _geographyContext;

        public TimezoneController(ILogger<TimezoneController> logger, GeographyContext context)
        {
            _geographyContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Timezone>> Get(string countryCode = "")
        {

            if (countryCode is null || countryCode == "")
            {
                return await _geographyContext.Timezones.ToListAsync();
            }
            else
            {
                return await _geographyContext.Timezones
                    .Where(t=>t.CountryCode == countryCode)
                    .ToListAsync();
            }

        }
    }
}
