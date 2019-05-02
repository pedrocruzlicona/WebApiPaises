using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiPaises.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPaises.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PaisController : Controller
    {
        private readonly ApplicationDbContext context;

        public PaisController(ApplicationDbContext context)
        {
            //para acceder al contexto de la base de datos
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return context.Paises.ToList();
        }
        [HttpGet("{id}",Name = "paisCreado")]
        public IActionResult GetById(int id)
        {
            var pais = context.Paises.FirstOrDefault(x => x.Id == id);
            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Pais pais)
        {
            if (ModelState.IsValid)
            {
                context.Paises.Add(pais);
                context.SaveChanges();
                return new CreatedAtRouteResult("paisCreado", new { id = pais.Id }, pais);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Pais pais, int id)
        {
            if(pais.Id != id)
            {
                return BadRequest();
            }

            context.Entry(pais).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
    }
}
