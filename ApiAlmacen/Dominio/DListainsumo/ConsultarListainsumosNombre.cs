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
    public class ConsultarListaInsumoNombre : IRequest<ListaInsumoModelonom>
    {
            public string nombre { get; set; }

            public ConsultarListaInsumoNombre(string Nombre){
            nombre=Nombre;
            }
    }
    

    public class ListaInsumoModelonom{
     
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

    public class ConsultarListaInsumoNombreHandler : IRequestHandler<ConsultarListaInsumoNombre, ListaInsumoModelonom>
{
    private readonly AlmacenDbContext context;
    public ConsultarListaInsumoNombreHandler(AlmacenDbContext context)
    {

        this.context = context;
    }

    public async Task<ListaInsumoModelonom> Handle(ConsultarListaInsumoNombre request, CancellationToken cancellationToken)
    {
           var resultado =  await context.listainsumo.
                Include(ins => ins.insumos).Include(part => part.insumos.partida).Include(lsi => lsi.lista_si).
                Include(m=>m.modulo).Include(pro=> pro.modulo.proyecto).
                Where(li => li.insumos.descripcion== request.nombre || li.status == '1' ).FirstOrDefaultAsync();

          return  new ListaInsumoModelonom()
           {
                nolista = resultado.lista_si.id_lsi,
                idlista = resultado.id_listainsumo,
                proyecto = resultado.modulo.proyecto.descripcion,
                modulo = resultado.modulo.descripcion,
                clave = resultado.insumos.clave,
                nombreinsumo = resultado.insumos.descripcion,
                partida = resultado.insumos.partida.descripcion,
                cantidad = resultado.cantidad,
                unidadmedida = resultado.insumos.unidad_medida
           };
           /*
              var resultado =  await context.listainsumo.Where(li=> li.status == '1').
           Include(ins => ins.insumos).Include(part => part.insumos.partida).Include(lsi => lsi.lista_si).
           Include(m=>m.modulo).Include(pro=> pro.modulo.proyecto).
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
           */
           
    }
}
}