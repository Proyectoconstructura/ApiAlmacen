using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
 
namespace ApiAlmacen.Dominio.DModulo
{
    public class Crearmodulo : IRequest<bool>
    {
        
        public string descripcionmodulo { get; set; }
        public string descripcionproyecto { get; set; }

    }

     public class CrearmoduloHandler : IRequestHandler<Crearmodulo, bool>
    {
        private readonly AlmacenDbContext context;

        public CrearmoduloHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(Crearmodulo request, CancellationToken cancellationToken)
        {
            var inmodulo = new Modulos();

            var resproyecto = context.proyecto.Where(p => p.descripcion == request.descripcionproyecto).FirstOrDefault();
            
                inmodulo.id_proyecto= resproyecto.id_proyecto;
                inmodulo.descripcion= request.descripcionmodulo;
                inmodulo.fechacreacion =DateTime.Now.Date;
                inmodulo.status= '1';
                context.modulos.Add(inmodulo);
                await context.SaveChangesAsync();
            return true;
        }

       
    }
}

