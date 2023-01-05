using easy_meal_api.Data;
using easy_meal_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        [HttpGet("{id}")]
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
            if (aliment.Name == null || aliment.Name == "" || aliment.Name.Length < 3)
                throw new ValidationException();
            else if (aliment.TypeId == null || aliment.TypeId == "")
                throw new ValidationException();
            else
            {
                var alim = new AlimentDao()
                {
                    Name = aliment.Name,
                    TypeId = aliment.TypeId,
                };

                await _context.AddAsync(alim);
                await _context.SaveChangesAsync();
            }


            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAliment(int id)
        {
            var alim = await _context.Aliment.FirstOrDefaultAsync(x => x.Id == id);

            if (alim == null)
                return NotFound();
            else
            {
                _context.Aliment.Remove(alim);
                await _context.SaveChangesAsync();

            }


            return Ok();
        }

        [HttpGet("Type")]
        public async Task<ActionResult<IEnumerable<TypeDao>>> GetAllTypes()
        {
            return await _context.Type.ToListAsync();
        }


        [HttpPost("Type")]
        public async Task<ActionResult<TypeDao>> CreateType(TypeDao type)
        {
            if (type.Type == null || type.Type == "")
                throw new ValidationException();
            else
            {
                var t = new TypeDao()
                {
                    Type = type.Type,
                };

                await _context.AddAsync(t);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpDelete("Type/{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var type = await _context.Type.FirstOrDefaultAsync(x => x.Id == id);

            if (type == null)
                return NotFound();
            else
            {
                _context.Type.Remove(type);
                await _context.SaveChangesAsync();

            }

            return Ok();
        }


        [HttpGet("Repas")]
        public async Task<ActionResult<IEnumerable<RepasDao>>> GetAllRepas()
        {
            return await _context.Repas.ToListAsync();
        }

        [HttpPost("Repas")]
        public async Task<ActionResult<RepasDao>> CreateRepas(RepasDao repas)
        {
            if (repas.Name == null || repas.Name == "" || repas.Ingrédients == null || repas.Ingrédients == "" || repas.Ingrédients.Length < 3)
                throw new ValidationException();
            else
            {
                var t = new RepasDao()
                {
                    Ingrédients = repas.Ingrédients,
                    Name = repas.Name,
                };

                await _context.AddAsync(t);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpDelete("Repas/{id}")]
        public async Task<IActionResult> DeleteRepas(int id)
        {
            var repas = await _context.Repas.FirstOrDefaultAsync(x => x.Id == id);

            if (repas == null)
                return NotFound();
            else
            {
                _context.Repas.Remove(repas);
                await _context.SaveChangesAsync();

            }

            return Ok();
        }
    }
}

