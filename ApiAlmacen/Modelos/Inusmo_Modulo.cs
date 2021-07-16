using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Inusmo_Modulo
    {
        public int id_modulo {set; get;}
         public Modulos modulos { set; get; }
        public int id_insumo {set; get;}
        public Insumos insumos { set; get; }   
        public float totalinsumo { get; set; }
        public char status  { set; get; }
    }
}