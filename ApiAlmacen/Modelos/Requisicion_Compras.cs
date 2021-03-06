using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Requisicion_Compras
    {
        [Key]
        public int  id_compra { set; get; }
        public int id_insumo { set; get; }
       
        public int id_lrc{ set; get; }
        public  Lista_req_compras Lista_req_compra{ set; get; }
        public Insumos insumos { set; get; }
        public int id_proveedor {set;get;}
        public Proveedores proveedor{set;get;}
        public int id_modulo {set;get;}
        public Modulos modulos{set;get;}
        public DateTime fecha { set; get; } 
        public float cantidad { set; get; }
            public float importe { set; get; }
            public float precio_unitario{ set; get; }
        public string comprador { set; get; }
        public int numero { set; get; }
        public string solicitante{ set; get; }
        public string revisor  { set; get; }
        public string autorizante{ set; get; }
        public string observaciones { set; get; }
        public string centro_costo { set; get; }
        public string prioridad { set; get; }
        public string unidad{ set; get; }
        [ForeignKey("id_compra")]
        [JsonIgnore]
        public ICollection<Entradas> entrada { set; get; }
    }
}


