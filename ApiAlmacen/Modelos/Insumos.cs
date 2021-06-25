using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAlmacen.Modelos
{
    public class Insumos
    {
        [Key]
        public int id_insumo { get; set; }
        public string clave { get; set; }
        public string descripcion { get; set; }
        public int id_partida { get; set; }
        public Partidas partida { get; set; }
        public string unidad_medida { get; set; }
        public char status  { set; get; }

        [ForeignKey("id_insumo")]
        [JsonIgnore]
        public ICollection<listainsumo> lisaInsumo { get; set; }
        [ForeignKey("id_insumo")]
        [JsonIgnore]
        public ICollection<Requisicion_Compras> requisicioncompra { get; set; }
        [ForeignKey("id_insumo")]
        [JsonIgnore]
        public ICollection<Requisiciones_Insumo> requisicioninsumos { get; set; }
        [ForeignKey("id_insumo")]
        [JsonIgnore]
        public ICollection<Inventario> inventario { get; set; }
        [ForeignKey("id_insumo")]
        [JsonIgnore]
        public ICollection<Estructuras> estructuras { get; set; }
        [ForeignKey("id_insumo")]
        [JsonIgnore]
        public ICollection<Entradas> entrada { get; set; }
        [ForeignKey("id_insumo")]
        [JsonIgnore]
        public ICollection<Modulos> modulo { get; set; }


    }
}
