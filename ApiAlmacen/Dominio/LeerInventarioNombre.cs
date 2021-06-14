using ApiAlmacen.Modelos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio
{
    
    public class LeerInventarioNombre: IRequest<inventariomodelonom>
        {
            public string Nombre { get; set; }
            
            public LeerInventarioNombre(string nombre){
                Nombre=nombre;
            }
            }
            public class inventariomodelonom
            {
            
            public string nombreinsumo { set; get; }
            public float Cantidad { get; set; }
            public float PrecioUnitario { get; set; }
            public float Importe { get; set; }
            public string Partida { get; set; }

        }

        public class LeerInventarioNombreHandler : IRequestHandler<LeerInventarioNombre, inventariomodelonom>
        {
            private readonly AlmacenDbContext context;

        public LeerInventarioNombreHandler(AlmacenDbContext context)
        {
            this.context=context;
        }

        public async Task<inventariomodelonom> Handle(LeerInventarioNombre request, CancellationToken cancellationToken)
        {
            var resultado = await context.inventario.
                    Include(i => i.insumos.partida).Include(e => e.entradas).Where(nom=> nom.insumos.descripcion == request.Nombre).FirstOrDefaultAsync();
                    if (resultado ==null) return null;

                    return new inventariomodelonom()
                    {
                        nombreinsumo = resultado.insumos.descripcion,
                        Cantidad= resultado.cantidad,
                        PrecioUnitario = resultado.entradas.precio_unitario,
                        Importe= resultado.entradas.importe,
                        Partida=resultado.insumos.partida.descripcion
                    
                    };
                        
                    
                    
        }        
   

    }
}
      
   