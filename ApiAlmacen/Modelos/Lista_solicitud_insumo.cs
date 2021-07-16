using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

 
namespace ApiAlmacen.Modelos
{

    public class Lista_solicitud_insumo{
          [Key]
          public int id_lsi {set;get;}
          public  DateTime fechacreacion{set;get;}
          public char status {set;get;}

        
        [ForeignKey("id_lsi")]
        [JsonIgnore]
        public ICollection<ListaInsumo> listainsumos { get; set; }

    }
}