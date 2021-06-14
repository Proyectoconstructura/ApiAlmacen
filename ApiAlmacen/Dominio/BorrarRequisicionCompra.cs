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
    public class BorrarRequisicionCompra: IRequest<bool>
    {
            public int id { get; set; }
    }
        public class BorrarRequisicionCompraHandler : IRequestHandler<BorrarRequisicionCompra,bool>
        {
            private readonly AlmacenDbContext context;
            public BorrarRequisicionCompraHandler(AlmacenDbContext context)
            {
                this.context=context;
            }
            public async Task<bool> Handle(BorrarRequisicionCompra request, CancellationToken cancellationToken)
            {
                var requisicioncompras = await context.requisicion_compras.
                                Where(l => l.id_compra == request.id ).FirstOrDefaultAsync();
                if (requisicioncompras ==null) return false;
                    context.requisicion_compras.Remove(requisicioncompras);
                    await context.SaveChangesAsync();
                    return true;
            }
       } 
}