using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Roles
    {
        [Key]
        public int id_rol { get; set;  }
        public string descripcion { set; get; }
        [ForeignKey("id_rol")]
        [JsonIgnore]
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
