using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Inventario
    {
        [Key]
        public int id_inventario { set; get; }
        public int id_insumo { set; get; }
        public Insumos insumos { set; get; }
        public int id_entrada { set; get; }
        public Entradas entradas { set; get; }
        public float cantidad { set; get; }
    }
}
