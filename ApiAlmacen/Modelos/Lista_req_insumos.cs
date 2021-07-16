using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace ApiAlmacen.Modelos
{

    public class Lista_req_insumos{
          [Key]
          public int id_lri {set;get;}
          public  DateTime fechacreacion{set;get;}
          public char status {set;get;}

           [ForeignKey("id_lri")]
        [JsonIgnore]
        public ICollection<Requisiciones_Insumo> requisiciones_Insumo { get; set; }
        
    }
}