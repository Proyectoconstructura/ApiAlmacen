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
    public class ConsultarRequisicionCompra : IRequest<List<ListaCompraModelo>>
    {        
    }
    public class ListaCompraModelo{
        public int id { set; get; }
        public string nombreinsumo { set; get; }
        public DateTime fecha { set; get; } 
        public float cantidad { set; get; }
        public string comprador { set; get; }
        public int numero { set; get; }
        public string solicitante{ set; get; }
        public string revisor  { set; get; }
        public string autorizante{ set; get; }
        public string observaciones { set; get; }
        public string centro_costo { set; get; }
        public string prioridad { set; get; }
        public string unidad{ set; get; }
    }

    public class ConsultarRequisicionCompraHandler : IRequestHandler<ConsultarRequisicionCompra, List<ListaCompraModelo>>
    {
    private readonly AlmacenDbContext context;
    public ConsultarRequisicionCompraHandler(AlmacenDbContext context)
    {

        this.context = context;
    }

    public async Task<List<ListaCompraModelo>> Handle(ConsultarRequisicionCompra request, CancellationToken cancellationToken)
    {
           var resultado =  await context.requisicion_compras.Include(i => i.insumos).ToListAsync();
           var res = resultado.ToList().Select(x => new ListaCompraModelo()
           {
                id = x.id_compra,
                nombreinsumo = x.insumos.descripcion,
                fecha = x.fecha,
                cantidad =x.cantidad,
                comprador =x.comprador,
                numero =x.numero,
                solicitante = x.solicitante,
                revisor = x.revisor,
                autorizante = x.autorizante,
                observaciones =x.observaciones,
                centro_costo = x.centro_costo,
                prioridad = x.prioridad,
                unidad = x.unidad
           });
           
            return res.ToList();
    }
    
    }
}