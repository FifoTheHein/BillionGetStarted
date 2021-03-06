﻿using System;
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
        public async Task<List<Country>> Get(string continentCode = "")
        {
            if (continentCode is null || continentCode == "")
            {
                return await _geographyContext.Countries.ToListAsync();
            }
            else
            {
                return await _geographyContext.Countries.Where(c=>c.Continent == continentCode).ToListAsync();
            }
            
        }
    }
}
