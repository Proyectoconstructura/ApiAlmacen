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
    public class Crearproyecto : IRequest<bool>
    {
        public string descripcion { set; get; }
        public string direccion { get; set; }
    }

     public class CrearproyectoHandler : IRequestHandler<Crearproyecto, bool>
    {
        private readonly AlmacenDbContext context;

        public CrearproyectoHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(Crearproyecto request, CancellationToken cancellationToken)
        {
            var inproyecto = new Proyecto();

            var resproyecto = context.proyecto.Where(p => p.descripcion == request.descripcion).FirstOrDefault();
            if(resproyecto != null) return false;
                inproyecto.descripcion= request.descripcion;
                inproyecto.fechacreacion =DateTime.Now.Date;
                context.proyecto.Add(inproyecto);
                await context.SaveChangesAsync();
            return true;
        }

       
    }
}

