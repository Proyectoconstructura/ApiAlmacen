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
    public class BorrarRequisicionInsumos: IRequest<bool>
    {
            public int id { get; set; }
    }
        public class BorrarRequisicionInsumosHandler : IRequestHandler<BorrarRequisicionInsumos,bool>
        {
            private readonly AlmacenDbContext context;
            public BorrarRequisicionInsumosHandler(AlmacenDbContext context)
            {
                this.context=context;
            }
            public async Task<bool> Handle(BorrarRequisicionInsumos request, CancellationToken cancellationToken)
            {
                var requisicioninsumo = await context.requisiciones_insumo.
                                Where(l => l.id_requisicion == request.id ).FirstOrDefaultAsync();
                if (requisicioninsumo ==null) return false;
                    context.requisiciones_insumo.Remove(requisicioninsumo);
                    await context.SaveChangesAsync();
                    return true;
            }
       } 
}