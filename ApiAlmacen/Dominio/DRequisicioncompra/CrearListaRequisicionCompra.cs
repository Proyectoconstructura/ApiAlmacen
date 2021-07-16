using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio.DRequisicioncompra
{
    public class CrearListaRequisicionCompra : IRequest<bool>
    {
        public int Norequicicion { set; get; }
        public string prioridad{ set; get; }
        public string centro_costo{ set; get; }
        public DateTime fecha{ set; get; }
        public string nombreinsumo{ set; get; }
         public string unidad { set; get; }
        public float cantidad{ set; get; }
       
       public string comprador{ set; get; }
        public string solicitante{ set; get; }
         public string revisor { set; get; }
        public string autorizante{ set; get; }
        public string observaciones{ set; get; }
    }

     public class CrearListaRequisicionCompraHandler : IRequestHandler<CrearListaRequisicionCompra, bool>
    {
        private readonly AlmacenDbContext context;

        public CrearListaRequisicionCompraHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(CrearListaRequisicionCompra request, CancellationToken cancellationToken)
        {
            var RCompra = new Requisicion_Compras();

            var resinsumo = context.insumos.Where(i => i.descripcion == request.nombreinsumo).FirstOrDefault();

            RCompra.id_insumo = resinsumo.id_insumo;
            RCompra.fecha = DateTime.UtcNow.Date;
            RCompra.cantidad = request.cantidad;
            RCompra.comprador = request.comprador;
            RCompra.numero = 1 ;
            RCompra.solicitante= request.solicitante;
            RCompra.revisor   = request.revisor;
            RCompra.autorizante= request.autorizante;
            RCompra.observaciones = request.observaciones;
            RCompra.centro_costo =request.centro_costo;
            RCompra.prioridad = request.prioridad;
            RCompra.unidad = request.unidad;
            context.requisicion_compras.Add(RCompra);
            await context.SaveChangesAsync();

            return true;
        }

       
    }
}

