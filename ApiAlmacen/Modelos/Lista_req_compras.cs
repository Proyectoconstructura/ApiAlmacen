using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Lista_req_compras
    {
        [Key]
        public int id_lrc {set; get;}
        public int id_compra { set;get;}
        public Requisicion_Compras requisicion_compras{set;get;}
           public  DateTime fechacreacion{set;get;}
          public char status {set;get;}

    }
}