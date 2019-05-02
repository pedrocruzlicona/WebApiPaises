using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiPaises.Models
{
    public class Pais
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }
    }
}
