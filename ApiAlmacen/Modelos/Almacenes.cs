using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Almacenes
    {
        [Key]
        public int id_almacen { set; get; }
        public string decripcion { set; get; }
        public string direccion { set; get; }

        [ForeignKey("id_almacen")]
        [JsonIgnore]
        public ICollection<Entradas> entrada { get; set; }
    }
}
