using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{

    public class Lista_req_insumos{
          [Key]
          public int id_lri {set;get;}
          public int id_requisicion{set;get;}
          public Requisiciones_Insumo requisiciones_insumo {set;get;}
          public  DateTime fechacreacion{set;get;}
          public char status {set;get;}

        
    }
}