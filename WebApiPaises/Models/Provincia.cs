using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApiPaises.Models
{
    public class Provincia
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        //llave foranea para la propiedad pais
        [ForeignKey("pais")]
        public int PaisId { get; set; }
        //propiedad navigacional, a cada provincia le pertenece un Pais
        [JsonIgnore]
        public Pais pais { get; set; }
    }
}
