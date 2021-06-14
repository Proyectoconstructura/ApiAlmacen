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
    public class ConsultarEntrada : IRequest<List<ListaEntradaModelo>>
    {
    }

    public class ListaEntradaModelo{
        public int id { set; get; }
        public string nombrealmcen { set; get; }
        public string nombreinsumo { set; get; }
        public string nomproveedor { set; get; }
        public float cantidad { set; get; }
        public DateTime fecha_entrada { set; get; }
        public float importe { set; get; }
        public float precio_unitario { set; get; }
    }

    public class ConsultarEntradaHandler : IRequestHandler<ConsultarEntrada, List<ListaEntradaModelo>>
{
    private readonly AlmacenDbContext context;
    public ConsultarEntradaHandler(AlmacenDbContext context)
    {

        this.context = context;
    }

    public async Task<List<ListaEntradaModelo>> Handle(ConsultarEntrada request, CancellationToken cancellationToken)
    {

        
        var resultado =  await context.entradas.
        Include(alm => alm.almacenes).
        Include(ins=>ins.insumos).
        Include(prov => prov.proveedores).ToListAsync();

        var res = resultado.ToList().Select(x => new ListaEntradaModelo()
        {
            id = x.id_entrada,
            nombrealmcen = x.almacenes.decripcion,
            nombreinsumo = x.insumos.descripcion,
            nomproveedor = x.proveedores.nombre,
            cantidad = x.cantidad,
            fecha_entrada = x.fecha_entrada,
            importe = x.importe,
            precio_unitario = x.precio_unitario 
        });

        return res.ToList();
    }
    
    }
}