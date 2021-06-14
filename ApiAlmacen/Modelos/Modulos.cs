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
        public int modulo_id { set; get; }
        public string descripcion { set; get; }
        public int id_estructura { set; get; }
        public Estructuras estructuras { set; get; }
        public float insumo_modulo { set; get; } 
    }
}

