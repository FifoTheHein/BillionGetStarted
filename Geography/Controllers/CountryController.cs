using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Geography.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;

        private readonly GeographyContext _geographyContext;

        public CountryController(ILogger<CountryController> logger, GeographyContext context)
        {
            _geographyContext = context;
            _logger = logger;
        }

        [HttpGet]
        public List<Country> Get()
        {
            return _geographyContext.Countries.ToList();
        }
    }
}
