using System;
using Microsoft.EntityFrameworkCore;

namespace WebApiPaises.Models
{
    public class ApplicationDbContext:DbContext
    {
        //le enviamos las opciones del ApplicationDbContext a Startup.cs
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        //para crear la tabla de paises
        public DbSet<Pais> Paises { get; set; }

        //para crear la tabla provincias
        public DbSet<Provincia> Provincias { get; set; }

    }
}
