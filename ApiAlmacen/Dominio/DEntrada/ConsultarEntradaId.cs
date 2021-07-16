using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio.DEntrada
{
    public class ConsultarEntradaId : IRequest<ListaEntradaModeloid>
    {

            public int id { get; set; }

            public ConsultarEntradaId(int Id){
            id=Id;
            }
    }

    

    public class ListaEntradaModeloid{
        public int id { set; get; }
        public string nombrealmcen { set; get; }
        public string nombreinsumo { set; get; }
        public string nomproveedor { set; get; }
        public float cantidad { set; get; }
        public DateTime fecha_entrada { set; get; }
        public float importe { set; get; }
        public float precio_unitario { set; get; }
    }

    public class ConsultarEntradaIdHandler : IRequestHandler<ConsultarEntradaId, ListaEntradaModeloid>
{
    private readonly AlmacenDbContext context;
    public ConsultarEntradaIdHandler(AlmacenDbContext context)
    {

        this.context = context;
    }

    public async Task<ListaEntradaModeloid> Handle(ConsultarEntradaId request, CancellationToken cancellationToken)
    {

        
        var x =  await context.entradas.
        Include(alm => alm.almacenes).
        Include(ins=>ins.insumos).
        Include(prov => prov.proveedores).Where(e => e.id_entrada== request.id).FirstOrDefaultAsync();

        return new ListaEntradaModeloid()
        {
            id = x.id_entrada,
            nombrealmcen = x.almacenes.decripcion,
            nombreinsumo = x.insumos.descripcion,
            nomproveedor = x.proveedores.nombre,
            cantidad = x.cantidad,
            fecha_entrada = x.fecha_entrada,
            importe = x.importe,
            precio_unitario = x.precio_unitario 
        };

    }
    
    }
}