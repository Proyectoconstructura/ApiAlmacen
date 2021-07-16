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
    public class CrearListaInsumo : IRequest<bool>
    {
        public int nolista{ set; get; } 
        public string proyecto { get; set; }
        public string descripcionmodulo { set; get; }
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
            var inlistinsumo = new ListaInsumo();
            var inlistasi =  new Lista_solicitud_insumo();
            var inmodulo=new Modulos();
           

            var dtlistasi = context.lista_solicitud_insumo.Where(lsi=> lsi.id_lsi == request.nolista).FirstOrDefault();
            if(dtlistasi ==null){
                inlistasi.fechacreacion = DateTime.Now.Date;
                inlistasi.status ='1';//falta  revisar los demas datos  
            }  

            var dtpartida = context.partidas.Where(p => p.descripcion == request.partida).FirstOrDefault();
            if (dtpartida == null){
                inpartida.descripcion = request.partida; 
                inpartida.status = '1';
                 context.partidas.Add(inpartida);
                await context.SaveChangesAsync();
            }
                
            var dtinsumo = context.insumos.Where(i => i.descripcion == request.nombreinsumo).FirstOrDefault();
            if(dtinsumo == null){
                dtpartida = context.partidas.Where(p => p.descripcion == request.partida).FirstOrDefault();
                ininsumo.clave = request.clave; 
                ininsumo.descripcion = request.nombreinsumo;
                ininsumo.id_partida = dtpartida.id_partida;
                ininsumo.unidad_medida = request.unidadmedida;
                ininsumo.status = '1';
                context.insumos.Add(ininsumo); 
                await context.SaveChangesAsync();
                
            }

            var dtmodulo= context.modulos.Where(m=>m.descripcion == request.descripcionmodulo).FirstOrDefault();
            if(dtmodulo == null){
                 var dtproyecto = context.proyecto.Where(p=>p.descripcion == request.proyecto).FirstOrDefault();
                    inmodulo.id_proyecto = dtproyecto.id_proyecto;
                    inmodulo.descripcion = request.descripcionmodulo;
                    inmodulo.fechacreacion = DateTime.Now.Date;
                    inmodulo.status = '1';

                }

            dtmodulo= context.modulos.Where(m=>m.descripcion == request.descripcionmodulo).FirstOrDefault();
            dtinsumo =  context.insumos.Where(i => i.descripcion == request.nombreinsumo).FirstOrDefault();
            
            inlistinsumo.id_lsi = request.nolista;
            inlistinsumo.id_insumo = dtinsumo.id_insumo;
            inlistinsumo.id_modulo = dtmodulo.id_modulo;
            inlistinsumo.cantidad = request.cantidad;
            inlistinsumo.status = '1';

            context.listainsumo.Add(inlistinsumo);
            await context.SaveChangesAsync();
        
            return true;
        }

    
    }
}