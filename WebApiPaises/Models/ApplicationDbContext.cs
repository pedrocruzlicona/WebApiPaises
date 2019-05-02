using System;
using Microsoft.EntityFrameworkCore;

namespace WebApiPaises.Models
{
    public class ApplicationDbContext:DbContext
    {
        //para crear la tabla de paises
       public DbSet<Pais> Paises { get; set; }
    }
}
