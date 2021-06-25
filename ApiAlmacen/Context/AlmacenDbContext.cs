using ApiAlmacen.Modelos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace ApiAlmacen
{
    public class AlmacenDbContext : DbContext
    {

        public AlmacenDbContext(DbContextOptions<AlmacenDbContext> options)
       : base(options)
        {
        }
        /* public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }*/
        public  DbSet<Inventario> inventario { set; get; }
        public  DbSet<Almacenes> almacenes { set; get; }
        public  DbSet<Entradas> entradas { set; get; }
        public  DbSet<Estructuras> estructuras { set; get; }
        public  DbSet<Insumos> insumos { set; get; }
        public  DbSet<Modulos> modulos { set; get; }
        public  DbSet<Partidas> partidas { set; get; }
        public  DbSet<Proveedores> proveedores { set; get; }
        public  DbSet<Requisicion_Compras> requisicion_compras { set; get; }
        public  DbSet<Requisiciones_Insumo> requisiciones_insumo { set; get; }
        public  DbSet<Roles> roles { set; get; }
        public  DbSet<Usuarios> usuarios { set; get; }
        public DbSet<listainsumo> listainsumo { set; get; }
        public DbSet<lista_solicitud_insumo> lista_solicitud_insum { set; get; }
        public DbSet<Lista_req_compras> lista_req_compras { set; get; }

       public DbSet<Lista_req_insumos> lista_req_insumos { set; get; }
       public DbSet<Lista_solicitud_insumo> lista_solicitud_insumo { set; get; }

    }


}
