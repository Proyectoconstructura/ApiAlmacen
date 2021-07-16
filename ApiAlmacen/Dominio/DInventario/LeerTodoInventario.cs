using ApiAlmacen.Modelos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio.DInventario
{
    public class LeerTodoInventario : IRequest<List<inventariomodelo>>
    { }

public class inventariomodelo
{
    public string nombreinsumo { set; get; }
    public float Cantidad { get; set; }
    public float PrecioUnitario { get; set; }
    public float Importe { get; set; }
    public string Partida { get; set; }

}
public class LeerTodoInventariosHandler : IRequestHandler<LeerTodoInventario, List<inventariomodelo>>
{
    private readonly AlmacenDbContext context;
    public LeerTodoInventariosHandler(AlmacenDbContext context)
    {

        this.context = context;
    }

    public async Task<List<inventariomodelo>> Handle(LeerTodoInventario request, CancellationToken cancellationToken)
    {
            var a = new Insumos();
        var resultado = await context.inventario.
        Include(i => i.insumos.partida).Include(e => e.entradas).ToListAsync();
        var res = resultado.ToList().Select(x => new inventariomodelo()
        {
            nombreinsumo = x.insumos.descripcion,
            Cantidad = x.cantidad,
            PrecioUnitario = x.entradas.precio_unitario,
            Importe = x.entradas.importe,
            Partida = x.insumos.partida.descripcion

        }
        );
        return res.ToList();
    }    
      
    }

   
}
