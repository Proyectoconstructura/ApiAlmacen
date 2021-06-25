using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Modulos
    {
        [Key]
        public int id_modulo { set; get; }
        public int id_proyecto{set;get;}
         public Proyecto proyecto {set;get;}
        public string descripcion { set; get; }
        public int id_estructura { set; get; }
        public Estructuras estructuras { set; get; }
        public float insumo_modulo { set; get; } 
        public int id_insumo {set; get;}
        public Insumos insumo{set; get;}
        public char status  { set; get; }

         [ForeignKey("id_modulo")]
        [JsonIgnore]
        public ICollection<listainsumo> listainsumos { get; set; } 
         [ForeignKey("id_modulo")]
        [JsonIgnore]
        public ICollection<Requisicion_Compras> requisicion_compras { get; set; } 
    
    
    }
}

