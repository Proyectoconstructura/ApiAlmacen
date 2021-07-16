
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Proyecto
    {
        [Key]
        public int id_proyecto {set; get;}
        public string descripcion {set; get;}
        public string direccion {set; get;}
         public DateTime fechacreacion { get; set; }
        public char status { get; set; }
         [ForeignKey("id_proyecto")]
        [JsonIgnore]
        public ICollection<Modulos> modulos { get; set; } 
   
    }
}