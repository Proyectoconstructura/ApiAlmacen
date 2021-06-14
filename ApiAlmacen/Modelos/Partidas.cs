using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Partidas
    {
        [Key]
        public int id_partida { set; get; }
        public string descripcion { set; get; }
        [ForeignKey("id_partida")]
        [JsonIgnore]
        public ICollection<Insumos> insumos { get; set; }
    }       
}
