using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Estructuras
    {
        [Key]
        public int id_estructura {set; get;}
        public string descripcion {set; get;}
        public int id_insumo {set; get;}
        public Insumos insumos { set; get; }
        public float cantidad {set; get;}
        [ForeignKey("id_estructura")]
        [JsonIgnore]
        public ICollection<Modulos> modulo { get; set; } 
    }
}

   
    
