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
    public class CrearEntrada : IRequest<bool>
    {
        public string nomalmacen { set; get; } 
        public string nomproveedor { set; get; } 
        public string nombreinsumo { set; get; } 
       
        public int id_compra { set; get; } 
        
        public  float cantidad { set; get; } 
        public float precio_unitario { set; get; } 
        
    }

     public class CrearEntradaHandler : IRequestHandler<CrearEntrada, bool>
    {
        private readonly AlmacenDbContext context;

        public CrearEntradaHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(CrearEntrada request, CancellationToken cancellationToken)
        {
            var insumo = new Insumos();
            var entr = new Entradas();
            var alm = new Almacenes();
            var prov = new Proveedores();
            var inven = new Inventario();

            var dtalmacen = context.almacenes.Where(a => a.decripcion == request.nomalmacen).FirstOrDefault();
            

            if(dtalmacen == null){
                alm.decripcion = request.nomalmacen;
                context.almacenes.Add(alm);
                 await context.SaveChangesAsync();
            }
            var dtprov = context.proveedores.Where(pro => pro.nombre == request.nomproveedor).FirstOrDefault();
            if (dtprov == null){
                prov.nombre = request.nomproveedor;
                context.proveedores.Add(prov);
                await context.SaveChangesAsync();
            }



            var dtinsumo =  context.insumos.Where(i => i.descripcion == request.nombreinsumo).FirstOrDefault();
            var dtcompra = context.requisicion_compras .Where(rc => rc.id_insumo == dtinsumo.id_insumo).FirstOrDefault();

            dtalmacen = context.almacenes.Where(a => a.decripcion == request.nomalmacen).FirstOrDefault();
            dtprov = context.proveedores.Where(pro => pro.nombre == request.nomproveedor).FirstOrDefault();
            

            entr.id_proveedor = dtprov.id_proveedor; 
            entr.id_almacen = dtalmacen.id_almacen;
            entr.id_insumo = dtinsumo.id_insumo;
            entr.id_compra =1;
            entr.fecha_entrada =DateTime.UtcNow.Date;
            entr.cantidad = request.cantidad;
            entr.precio_unitario= request.precio_unitario;
            entr.importe = request.cantidad * request.precio_unitario;
            

            context.entradas.Add(entr);
            await context.SaveChangesAsync();
//
            var dtentrada = context.entradas.Where(e => e.id_insumo == dtinsumo.id_insumo ).FirstOrDefault();
            var dtinvenrio= context.inventario.Where(inv => inv.id_insumo == dtentrada.id_insumo).FirstOrDefault();

            if(dtinvenrio ==null)
            {
            inven.id_insumo = dtinsumo.id_insumo;
            inven.id_entrada = dtentrada.id_entrada;
            inven.cantidad = dtentrada.cantidad;
            context.inventario.Add(inven);
            }else{
               dtinvenrio.id_entrada = dtentrada.id_entrada;
                dtinvenrio.cantidad = dtinvenrio.cantidad + dtentrada.cantidad;
            }
            await context.SaveChangesAsync();

            return true;
        }
    }
}