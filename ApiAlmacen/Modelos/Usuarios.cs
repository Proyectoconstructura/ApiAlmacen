using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ApiAlmacen.Modelos
{
    public class Usuarios
    {
        [Key]
        public int id_usuario { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public int id_rol { set; get; }
        public Roles roles { set; get; }
         public DateTime ultima_entrada { set; get; }

        
     
    } 
}
