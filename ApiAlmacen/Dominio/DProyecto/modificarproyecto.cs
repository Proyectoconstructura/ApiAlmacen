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
    public class  modificarproyecto: IRequest<bool>
    {
        public int id_proyecto { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }

    }

     public class modificarproyectoHandler : IRequestHandler<modificarproyecto, bool>
    {
        private readonly AlmacenDbContext context;

        public modificarproyectoHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(modificarproyecto request, CancellationToken cancellationToken)
        {
           var Rproyecto = context.proyecto.Where(p=>p.id_proyecto== request.id_proyecto).FirstOrDefault();
           if(Rproyecto == null) return false;
           else {
               Rproyecto.descripcion = request.descripcion;
               Rproyecto.direccion =  request.direccion;
                await context.SaveChangesAsync();
            }
            return true;
        }

       
    }
}
