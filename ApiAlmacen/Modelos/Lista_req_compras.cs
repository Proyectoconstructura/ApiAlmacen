using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Lista_req_compras
    {
        [Key]
        public int id_lrc {set; get;}
        public  DateTime fechacreacion{set;get;}
        public char status {set;get;}

    
      [ForeignKey("id_lrc")]
        [JsonIgnore]
        public ICollection<Requisicion_Compras> requisicion_Compra { set; get; }
    }
}