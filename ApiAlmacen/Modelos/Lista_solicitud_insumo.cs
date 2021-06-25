using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{

    public class Lista_solicitud_insumo{
          [Key]
          public int id_lsi {set;get;}
          public int id_listainsumo{set;get;}
          public listainsumo listainsumo {set;get;}
          public  DateTime fechacreacion{set;get;}
          public char status {set;get;}

    }
}