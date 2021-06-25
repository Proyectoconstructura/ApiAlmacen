using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Proveedores
    {
        [Key]
        public int id_proveedor { set; get; }
        public string nombre { set; get; }
        public string rfc { set; get; }
        public string direccion { set; get; }
        public char status  { set; get; }
        
        [ForeignKey("id_proveedor")]
        [JsonIgnore]
        public ICollection<Entradas> entrada { get; set; }
         [ForeignKey("id_proveedor")]
        [JsonIgnore]
        public ICollection<Requisicion_Compras> requisicion_compras { get; set; }
    }
    
}