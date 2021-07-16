using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ApiAlmacen.Dominio.DListainsumo
{
    public class Borrarlistainsumo: IRequest<bool>
    {
            public int id { get; set; }
    }
        public class BorrarlistainsumoHandler : IRequestHandler<Borrarlistainsumo,bool>
        {
            private readonly AlmacenDbContext context;
            public BorrarlistainsumoHandler(AlmacenDbContext context)
            {
             this.context=context;
            }
            public async Task<bool> Handle(Borrarlistainsumo request, CancellationToken cancellationToken)
            {
                var listinsumo = await context.listainsumo.
                                Where(l => l.id_listainsumo == request.id ).FirstOrDefaultAsync();
                if (listinsumo ==null) return false;
                    
                    listinsumo.status = '0';
                    await context.SaveChangesAsync();
                return true;
            }
       } 
}

      
   