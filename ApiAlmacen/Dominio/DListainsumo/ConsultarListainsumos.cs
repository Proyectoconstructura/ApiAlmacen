using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio.DListainsumo
{
    public class ConsultarListaInsumo : IRequest<List<ListaInsumoModelo>>
    {
        

    }

     public class ListaInsumoModelo{
        public int nolista { get; set; }
        public int idlista { set; get; }
        public string proyecto { set; get; }
        public string modulo { get; set; }
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
           Include(ins => ins.insumos).Include(part => part.insumos.partida).Include(lsi => lsi.lista_si).
           Include(m=>m.modulo).Include(pro=> pro.modulo.proyecto).Where(li=> li.status == '1').
           ToListAsync();
           
           var res = resultado.ToList().Select(x => new ListaInsumoModelo()
           {
                nolista = x.lista_si.id_lsi,
                idlista = x.id_listainsumo,
                proyecto = x.modulo.proyecto.descripcion,
                modulo = x.modulo.descripcion,
                clave = x.insumos.clave,
                nombreinsumo = x.insumos.descripcion,
                partida = x.insumos.partida.descripcion,
                cantidad = x.cantidad,
                unidadmedida = x.insumos.unidad_medida
           });
           return res.ToList();
    }
    
    }
}