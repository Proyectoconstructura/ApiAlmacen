using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Entradas
    {
        [Key]
        public int id_entrada { set; get; }
        public int id_almacen { set; get; }
        public Almacenes almacenes { set; get; }
        public int id_insumo { set; get; }
        public Insumos insumos{ set; get; }
        public int id_proveedor { set; get; }
        public Proveedores proveedores { set; get; }
        public int id_compra { set; get; }
        public Requisicion_Compras compras { set; get; }
        public DateTime fecha_entrada { set; get; }
        public float cantidad { set; get; }
        
        [ForeignKey("id_entrada")]
        [JsonIgnore]
        public ICollection<Inventario> inventario { get; set; }
    }
}

  