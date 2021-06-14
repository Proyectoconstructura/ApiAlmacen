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
    public class CrearListaInsumo : IRequest<bool>
    {

        public string proyecto { set; get; }
        public string clave { set; get; }
        public string nombreinsumo { set; get; }
        public string partida { set; get; }
        public float cantidad { set; get; }
        public string unidadmedida { set; get; }
    }

    public class CrearListaInsumoHandler : IRequestHandler<CrearListaInsumo, bool>
    {
        private readonly AlmacenDbContext context;

        public CrearListaInsumoHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(CrearListaInsumo request, CancellationToken cancellationToken)
        {
            var ininsumo = new Insumos();
            var inpartida = new Partidas();
            var inlistinsumo = new listainsumo();

      
            var dtpartida = context.partidas.Where(p => p.descripcion == request.partida).FirstOrDefault();
            if (dtpartida == null){
                inpartida.descripcion = request.partida; 
                 context.partidas.Add(inpartida);
                await context.SaveChangesAsync();
            }
           dtpartida = context.partidas.Where(p => p.descripcion == request.partida).FirstOrDefault();
            var dtinsumo =  context.insumos.Where(i => i.descripcion == request.nombreinsumo).FirstOrDefault();
            if(dtinsumo == null){
                ininsumo.clave = request.clave;
                ininsumo.descripcion = request.nombreinsumo;
                ininsumo.id_partida = dtpartida.id_partida;
                ininsumo.unidad_medida = request.unidadmedida;
                context.insumos.Add(ininsumo);
                await context.SaveChangesAsync();
                
            }
            dtinsumo =  context.insumos.Where(i => i.descripcion == request.nombreinsumo).FirstOrDefault();
            
            inlistinsumo.id_insumo = dtinsumo.id_insumo;
            inlistinsumo.proyecto = request.proyecto;
            inlistinsumo.cantidad = request.cantidad;
            inlistinsumo.status = true;

            context.listainsumo.Add(inlistinsumo);
            await context.SaveChangesAsync();
        
            return true;
        }

    
    }
}