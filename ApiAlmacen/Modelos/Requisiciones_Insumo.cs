using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Requisiciones_Insumo
    {
        [Key]
        public int  id_requisicion { set; get; }
        public int id_insumo { set; get; }
        public Insumos insumos { set; get; }
        public int id_estructura{set;get;}
        public Estructuras estructuras{set;get;}
        public DateTime fecha { set; get; } 
        public float cantidad { set; get; }
        public int numero { set; get; }
        public string solicitante{ set; get; }
        public string revisor  { set; get; }
        public string autorizante{ set; get; }
        public string observaciones { set; get; }   
        public string centro_costo { set; get; }
        public string prioridad { set; get; }
        public string unidad{ set; get; }
        
         [ForeignKey("id_requisicion")]
        [JsonIgnore]
        public ICollection<Requisiciones_Insumo> requisiciones_insumo { set; get; }
   


    }
}


  

 

  

   

   

   

 

  