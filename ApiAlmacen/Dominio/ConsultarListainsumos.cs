using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio
{
    public class ConsultarListaInsumo : IRequest<List<ListaInsumoModelo>>
    {
        

    }

    public class ListaInsumoModelo{
        public int idlista { set; get; }
          public string proyecto { set; get; }
        public string clave { set; get; }
        public string nombreinsumo { set; get; }
        public string partida { set; get; }
        public float cantidad { set; get; }
        public string unidadmedida { set; get; }
    }

    public class ConsultarListaInsumoHandler : IRequestHandler<ConsultarListaInsumo, List<ListaInsumoModelo>>
{
    private readonly AlmacenDbContext context;
    public ConsultarListaInsumoHandler(AlmacenDbContext context)
    {

        this.context = context;
    }

    public async Task<List<ListaInsumoModelo>> Handle(ConsultarListaInsumo request, CancellationToken cancellationToken)
    {
           var resultado =  await context.listainsumo.
           Include(ins => ins.insumos).Include(part => part.insumos.partida).ToListAsync();

           var res = resultado.ToList().Select(x => new ListaInsumoModelo()
           {
            idlista = x.id_listainsumo,
            proyecto =x.proyecto,
            clave = x.proyecto,
            nombreinsumo = x.insumos.descripcion,
            partida = x.insumos.partida.descripcion,
            cantidad = x.cantidad,
            unidadmedida =x.insumos.unidad_medida

           });
           return res.ToList();
    }
    
    }
}