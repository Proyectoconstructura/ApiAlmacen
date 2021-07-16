using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
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
        public DateTime fechacreacion { get; set; }
        public char status  { set; get; }

         [ForeignKey("id_modulo")]
        [JsonIgnore]
        public ICollection<ListaInsumo> listainsumos { get; set; } 
         [ForeignKey("id_modulo")]
        [JsonIgnore]
        public ICollection<Requisicion_Compras> requisicion_compras { get; set; } 
        [ForeignKey("id_modulo")]
        [JsonIgnore]
        public ICollection<Estructuras> estructuras { get; set; } 

         [ForeignKey("id_modulo")]
        [JsonIgnore]
        public ICollection<Inusmo_Modulo> inusmo_modulos { get; set; } 
    
    }
}

