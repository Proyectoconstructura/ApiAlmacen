using ApiAlmacen.Modelos;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAlmacen.Dominio
{
    public class ModificarListainsumo : IRequest<bool>
    {
        public int id { set; get; }
        public string proyecto { set; get; }
        public string clave { set; get; }
        public string nombreinsumo { set; get; }
        public string partida { set; get; }
        public float cantidad { set; get; }
        public string unidadmedida { set; get; }
    }

    public class ModificarListainsumoHandler : IRequestHandler<ModificarListainsumo,bool>
    {
        private readonly AlmacenDbContext context;

        public ModificarListainsumoHandler(AlmacenDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(ModificarListainsumo request, CancellationToken cancellationToken)
        {
            var ininsumo = new Insumos();
            var inpartida = new Partidas();

            var inlistinsumo = context.listainsumo.Where(l => l.id_listainsumo == request.id).FirstOrDefault();
            
            if(inlistinsumo == null){
                return false;
            }
            else{
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
               
                await context.SaveChangesAsync();
            }
            return true;
        }

    
    }
}