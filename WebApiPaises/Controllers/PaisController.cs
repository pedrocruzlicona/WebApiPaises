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
    [Route("api/Pais")]
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
    }
}
