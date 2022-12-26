using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using easy_meal_api.Data;
using easy_meal_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace easy_meal_api.Controllers
{
    [Route("api/[controller]")]
    public class AlimentsController : ControllerBase
    {
        private readonly ApiContext _context;

        public AlimentsController(ApiContext iContext)
        {
            _context = iContext;
        }
        // POST api/values
        [HttpPost]
        public JsonResult Post(AlimentDao aliment)
        {
            if (aliment.Id != 0)
            {
                var alimentInDb = _context.Aliments.Find(aliment.Id);

                if (alimentInDb == null)
                    return new JsonResult(NotFound());
                alimentInDb = aliment;
            }
            else
                _context.Aliments.Add(aliment);

            _context.SaveChanges();

            return new JsonResult(Ok(aliment));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Aliments.ToList();

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
    }
}

