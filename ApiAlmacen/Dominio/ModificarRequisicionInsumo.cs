using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio
{
    public class ModificarRequisicionInsumo : IRequest<bool>
    {
        public int id { set; get; }
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

     public class ModificarRequisicionInsumoHandler : IRequestHandler<ModificarRequisicionInsumo, bool>
    {
        private readonly AlmacenDbContext context;

        public ModificarRequisicionInsumoHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(ModificarRequisicionInsumo request, CancellationToken cancellationToken)
        {
            var RInsumo = context.requisiciones_insumo.Where(ri => ri.id_requisicion== request.id).FirstOrDefault();

             if(RInsumo == null){
                return false;
            }
            else{
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
            
            await context.SaveChangesAsync();
            }
            return true;
        }
    }
}

