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
    public class cosultarproyectonom : IRequest<proyectomodelnom>
    {
        public string nom { get; set; }
    }
    public class proyectomodelnom{
        public int id_proyecto { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }
        public DateTime fechacreacion { get; set; }

    }

    public class cosultarproyectonomHandler : IRequestHandler<cosultarproyectonom, proyectomodelnom>
    {
        private readonly AlmacenDbContext context;
        public cosultarproyectonomHandler(AlmacenDbContext context)
        {

            this.context = context;
        }

        public async Task<proyectomodelnom> Handle(cosultarproyectonom request, CancellationToken cancellationToken)
        {
                var resproyecto = await context.proyecto.Where(p=> p.status == '1' && p.descripcion == request.nom).FirstOrDefaultAsync();
                if (resproyecto== null)
                return null;
                return new proyectomodelnom(){
                    id_proyecto= resproyecto.id_proyecto,
                    descripcion = resproyecto.descripcion,
                    direccion = resproyecto.direccion,
                    fechacreacion = resproyecto.fechacreacion,
                };
            
        }
    }
}