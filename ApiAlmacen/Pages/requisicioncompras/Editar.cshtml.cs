using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using ApiAlmacen.Dominio;

using Microsoft.Extensions.Configuration;


namespace ApiAlmacen.Pages.requisicioncompras
{
    public class EditarModel : PageModel
    {           
        public DatosAEditar Detalles {get; set;}
        private readonly ILogger<EditarModel> _logger;
        private readonly IMediator mediator;
        private readonly IConfiguration configuracion;
        
    

        public EditarModel(ILogger<EditarModel> logger,
         IMediator mediatr,
         IConfiguration config)
        {
            _logger = logger;
            mediator = mediatr;
            configuracion = config;
        }


        public async Task<IActionResult>OnGet(int id){
            var insumo = await mediator.Send(new ConsultarRequisicionCompraId(id));

            if(insumo ==null){
                return NotFound();
            }
            Detalles =  new DatosAEditar(){
 
                id =insumo.id,
                nombreinsumo = insumo.nombreinsumo,
                cantidad = insumo.cantidad,
                comprador =insumo.comprador,
                solicitante= insumo.solicitante,
                revisor=insumo.revisor,
                autorizante= insumo.autorizante,
                observaciones = insumo.observaciones,
                centro_costo = insumo.centro_costo,
                prioridad = insumo.prioridad,
                unidad = insumo.unidad
            };
            return Page();
        }

        public async Task <IActionResult> Onpost(ModificarRequisicionCompra cmd){
            if(!ModelState.IsValid){
                Detalles =  new DatosAEditar(){
                    id =cmd.id,
                    nombreinsumo = cmd.nombreinsumo,
                    cantidad = cmd.cantidad,
                    comprador =cmd.comprador,
                    solicitante= cmd.solicitante,
                    revisor=cmd.revisor,
                    autorizante= cmd.autorizante,
                    observaciones = cmd.observaciones,
                    centro_costo = cmd.centro_costo,
                    prioridad = cmd.prioridad,
                    unidad = cmd.unidad
                };
                return Page();
            }
                 var insumo = await mediator.Send(new ConsultarRequisicionCompraId(cmd.id));
          
                if(insumo == null){
                return NotFound();
                }
            
                var res = await mediator.Send(cmd);

              return RedirectToPage("./Index");
        }

    }

     public class DatosAEditar 
    {
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
}