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
    public class  ModificarRequisicionCompra: IRequest<bool>
    {
        public int id { set; get; }
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

     public class ModificarRequisicionCompraHandler : IRequestHandler<ModificarRequisicionCompra, bool>
    {
        private readonly AlmacenDbContext context;

        public ModificarRequisicionCompraHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(ModificarRequisicionCompra request, CancellationToken cancellationToken)
        {
            var RCompra = context.requisicion_compras.Where(rc=>rc.id_compra == request.id).FirstOrDefault();
              if(RCompra == null){
                return false;
            }else{
            var resinsumo = context.insumos.Where(i => i.descripcion == request.nombreinsumo).FirstOrDefault();

            RCompra.id_insumo = resinsumo.id_insumo;
            RCompra.fecha = DateTime.UtcNow.Date;
            RCompra.cantidad = request.cantidad;
            RCompra.comprador = request.comprador;
            RCompra.numero = 1 ;
            RCompra.solicitante= request.solicitante;
            RCompra.revisor  = request.revisor;
            RCompra.autorizante= request.autorizante;
            RCompra.observaciones = request.observaciones;
            RCompra.centro_costo =request.centro_costo;
            RCompra.prioridad = request.prioridad;
            RCompra.unidad = request.unidad;

            await context.SaveChangesAsync();
            }
            return true;
        }

       
    }
}

