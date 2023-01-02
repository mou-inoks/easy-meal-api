﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using easy_meal_api.Data;
using easy_meal_api.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace easy_meal_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentsController : ControllerBase
    {
        private readonly ApiContext _context;

        public AlimentsController(ApiContext iContext)
        {
            _context = iContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlimentDao>>> GetAliments()
        {
            return await _context.Aliment.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<ActionResult<AlimentDao>> GetAliments(int id)
        {
            var aliment = await _context.Aliment.FindAsync(id);

            if (aliment == null)
                return null;
            else
                return aliment;
        }
        [HttpPost]
        public async Task<ActionResult<AlimentDao>> CreateAliment(AlimentDao aliment)
        {
            var alim = new AlimentDao()
            {
                Name = aliment.Name,
                TypeId = aliment.TypeId,
            };

            await _context.AddAsync(alim);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

