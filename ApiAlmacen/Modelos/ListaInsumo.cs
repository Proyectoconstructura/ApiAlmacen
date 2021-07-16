using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class ListaInsumo
    {
        [Key]
        public int id_listainsumo { get; set; }
        public int id_insumo { get; set; }
        public Insumos insumos{ get; set; }
        
        public int id_lsi { get; set; }
        public Lista_solicitud_insumo lista_si { get; set; }
        public int  id_modulo {set;get;}
        public Modulos modulo {get; set;}
        public float cantidad { get; set; }
        public char status { get; set; }
       
    }
}

   
