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
    public class ConsultarListaInsumoNombre : IRequest<ListaInsumoModelonom>
    {
            public int id { get; set; }

            public ConsultarListaInsumoNombre(int Id){
            id=Id;
            }
    }
    

    public class ListaInsumoModelonom{
        public int idlista { set; get; }
          public string proyecto { set; get; }
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
           Include(ins => ins.insumos).Include(part => part.insumos.partida).Where(nom => nom.id_listainsumo== request.id).FirstOrDefaultAsync();

          return  new ListaInsumoModelonom()
           {
            idlista = resultado.id_listainsumo,
            proyecto =resultado.proyecto,
            clave = resultado.proyecto,
            nombreinsumo = resultado.insumos.descripcion,
            partida = resultado.insumos.partida.descripcion,
            cantidad = resultado.cantidad,
            unidadmedida =resultado.insumos.unidad_medida
           };
           
    }
}
}