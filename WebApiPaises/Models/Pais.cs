using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiPaises.Models
{
    public class Pais
    {
        public Pais()
        {
            Provincias = new List<Provincia>();
        }
        public int Id { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }

        //a cada pais le pertenece un listado de provincias
        public List<Provincia> Provincias { get; set; }
    }
}
