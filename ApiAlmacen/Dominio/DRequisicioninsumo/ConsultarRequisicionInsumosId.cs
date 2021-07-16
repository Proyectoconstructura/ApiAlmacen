using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio.DRequisicioninsumo
{
    public class ConsultarRequisicionInsumoId : IRequest<ReqInsumoModeloid>
    {        
            public int id { get; set; }

            public ConsultarRequisicionInsumoId(int Id){
            id=Id;
            }  

    }
    public class ReqInsumoModeloid{
        public int id { set; get; }
        public string nombreinsumo { set; get; }
        public DateTime fecha { set; get; } 
        public float cantidad { set; get; }
        public int numero { set; get; }
        public string solicitante{ set; get; }
        public string revisor  { set; get; }
        public string autorizante{ set; get; }
        public string observaciones { set; get; }
        public string centro_costo { set; get; }
        public string prioridad { set; get; }
        public string unidad{ set; get; }
    }

    public class ConsultarRequisicionInsumoIdHandler : IRequestHandler<ConsultarRequisicionInsumoId, ReqInsumoModeloid>
    {
    private readonly AlmacenDbContext context;
    public ConsultarRequisicionInsumoIdHandler(AlmacenDbContext context)
    {

        this.context = context;
    }

    public async Task<ReqInsumoModeloid> Handle(ConsultarRequisicionInsumoId request, CancellationToken cancellationToken)
    {
           var x =  await context.requisiciones_insumo.
           Include(i => i.insumos).Where(ri => ri.id_requisicion== request.id).FirstOrDefaultAsync();
           return new ReqInsumoModeloid()
           {
                id=x.id_requisicion,
                nombreinsumo = x.insumos.descripcion,
                fecha = x.fecha,
                cantidad =x.cantidad,
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