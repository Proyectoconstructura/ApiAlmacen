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
    public class ConsultarRequisicionCompraId : IRequest<ListaCompraModeloid>
    {      

         public int id { get; set; }

            public ConsultarRequisicionCompraId(int Id){
            id=Id;
            }  
    }
    public class ListaCompraModeloid{
        public int id { set; get; }
        public string nombreinsumo { set; get; }
        public DateTime fecha { set; get; } 
        public float cantidad { set; get; }
        public int numero { set; get; }
        public string comprador { set; get; }
        public string solicitante{ set; get; }
        public string revisor  { set; get; }
        public string autorizante{ set; get; }
        public string observaciones { set; get; }
        public string centro_costo { set; get; }
        public string prioridad { set; get; }
        public string unidad{ set; get; }
    }

    public class ConsultarRequisicionCompraIdHandler : IRequestHandler<ConsultarRequisicionCompraId, ListaCompraModeloid>
    {
    private readonly AlmacenDbContext context;
    public ConsultarRequisicionCompraIdHandler(AlmacenDbContext context)
    {

        this.context = context;
    }

    public async Task<ListaCompraModeloid> Handle(ConsultarRequisicionCompraId request, CancellationToken cancellationToken)
    {
           var x =  await context.requisicion_compras.Include(i => i.insumos).Where(rc => rc.id_compra== request.id).FirstOrDefaultAsync();
           return new ListaCompraModeloid()
           {
                id= x.id_compra,
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
           };
           
            
    }
    
    }
}