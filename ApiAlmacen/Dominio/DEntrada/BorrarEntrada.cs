using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ApiAlmacen.Dominio.DEntrada
{
    public class BorrarEntrada: IRequest<bool>
    {
            public int id { get; set; }
    }
        public class BorrarEntradaHandler : IRequestHandler<BorrarEntrada,bool>
        {
            private readonly AlmacenDbContext context;
            public BorrarEntradaHandler(AlmacenDbContext context)
            {
                this.context=context;
            }
            public async Task<bool> Handle(BorrarEntrada request, CancellationToken cancellationToken)
            {
                var entrada = await context.entradas.
                                Where(l => l.id_almacen == request.id ).FirstOrDefaultAsync();
                if (entrada ==null) return false;
                    context.entradas.Remove(entrada);
                    await context.SaveChangesAsync();
                    return true;
            }
       } 
}

      
   