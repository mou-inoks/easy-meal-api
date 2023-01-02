using System;
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
    }
}

