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
        public int id_modulo { set; get; }
        public Modulos modulos { set; get; }
        public char status { set; get; }
       [ForeignKey("id_estructura")]
        [JsonIgnore]
        public ICollection<Requisiciones_Insumo> requisiciones_insumos { get; set; } 
    
        [ForeignKey("id_estructura")]
        [JsonIgnore]
        public ICollection<Insumo_Estructura> insumo_estructuras { get; set; } 
    
    }
}

   
    
