using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio.DRequisicioninsumo
{
    public class CrearRequisicionInsumo : IRequest<bool>
    {
        public DateTime fecha{ set; get; }
         public string solicitante{ set; get; }
        public string revisor { set; get; }
        public string autorizante{ set; get; }
        public string nombreinsumo{ set; get; }
        public float cantidad{ set; get; }  
        public string observaciones{ set; get; }
        public string centro_costo{ set; get; }
        public string prioridad{ set; get; }
        public string unidad { set; get; }
        
    }

     public class CrearRequisicionInsumoHandler : IRequestHandler<CrearRequisicionInsumo, bool>
    {
        private readonly AlmacenDbContext context;

        public CrearRequisicionInsumoHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(CrearRequisicionInsumo request, CancellationToken cancellationToken)
        {
            var RInsumo = new Requisiciones_Insumo();

            var resinsumo = context.insumos.Where(i => i.descripcion == request.nombreinsumo).FirstOrDefault();

            RInsumo.numero = 1 ;
            RInsumo.fecha = DateTime.UtcNow.Date;
            RInsumo.solicitante = request.solicitante;
            RInsumo.revisor = request.revisor;
            RInsumo.autorizante = request.autorizante;
            RInsumo.id_insumo = resinsumo.id_insumo;
            RInsumo.cantidad = request.cantidad;
            RInsumo.observaciones = request.observaciones;
            RInsumo.centro_costo =request.centro_costo;
            RInsumo.prioridad = request.prioridad;
            RInsumo.unidad = request.unidad;
            context.requisiciones_insumo.Add(RInsumo);
            await context.SaveChangesAsync();

            return true;
        }
    }
}

