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
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;

        private readonly GeographyContext _geographyContext;

        public CityController(ILogger<CityController> logger, GeographyContext context)
        {
            _geographyContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<City>> Get(string countryCode)
        {
            return await _geographyContext.Cities.Where(c=>c.CountryCode == countryCode).ToListAsync();
        }
    }
}
