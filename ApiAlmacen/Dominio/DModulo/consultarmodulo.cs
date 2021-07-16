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
    public class cosultarmodulo : IRequest<List<modulomodelo>>
    {
    }
        public class modulomodelo
        {
            public int id_modulo { get; set; } 
            public int id_proyecto { get; set; }
            public string descripcionmodulo { get; set; }
            public string descripcionproyecto { get; set; }
            public DateTime fechacreacion { get; set; }

            
            
        }
     

     public class cosultarmoduloHandler : IRequestHandler<cosultarmodulo, List<modulomodelo>>
    {
        private readonly AlmacenDbContext context;

        public cosultarmoduloHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<List<modulomodelo>> Handle(cosultarmodulo request, CancellationToken cancellationToken)
        {
          
          
          var resultado =  await context.modulos.Include(pro=> pro.proyecto).Where(m=>m.status == '1').ToListAsync();

          var res = resultado.ToList().Select(x=> new modulomodelo
          {
                id_modulo = x.id_modulo,
                id_proyecto = x.id_proyecto,
                descripcionmodulo = x.descripcion,
                descripcionproyecto = x.proyecto.descripcion,
                fechacreacion = x.fechacreacion

          });
          return res.ToList();
        } 

       
    }
}
