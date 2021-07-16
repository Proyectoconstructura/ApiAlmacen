using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio.DProyecto
{
    public class  borrarproyecto: IRequest<bool>
    {
        public int id{ get; set; }
    }

     public class borrarproyectoHandler : IRequestHandler<borrarproyecto, bool>
    {
        private readonly AlmacenDbContext context;

        public borrarproyectoHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(borrarproyecto request, CancellationToken cancellationToken)
        {
            var Rproyecto = context.proyecto.Where(p=>p.id_proyecto== request.id).FirstOrDefault();
            if(Rproyecto == null) return false;
                
                Rproyecto.status =  '0';
                await context.SaveChangesAsync();
            
            return true;
        }

       
    }
}
