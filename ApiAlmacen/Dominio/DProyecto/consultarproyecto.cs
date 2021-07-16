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
    public class cosultarproyecto : IRequest<List<proyectomodel>>
    {
    }
    
      public class proyectomodel{
        public int id_proyecto { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }
        public DateTime fechacreacion { get; set; }

    }
    public class proyectomodeloHandler : IRequestHandler<cosultarproyecto, List<proyectomodel>>
{
    private readonly AlmacenDbContext context;
    public proyectomodeloHandler(AlmacenDbContext context)
    {

        this.context = context;
    }

    public async Task<List<proyectomodel>> Handle(cosultarproyecto request, CancellationToken cancellationToken)
    {
            var resproyecto = await context.proyecto.Where(p=> p.status == '1').ToListAsync();
             if (resproyecto== null) return null;
           var res = resproyecto.ToList().Select(x=> new proyectomodel()
           {
                id_proyecto = x.id_proyecto,
                descripcion= x.descripcion,
                direccion = x.direccion,
                fechacreacion = x.fechacreacion
           });
            return res.ToList();
           
    }
}
} 