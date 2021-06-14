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


namespace ApiAlmacen.Pages.requisicioninsumos
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
            var reqInsumo = await mediator.Send(new ConsultarRequisicionInsumoId(id));

            if(reqInsumo ==null){
                return NotFound();
            }
            Detalles =  new DatosAEditar(){
                id =reqInsumo.id,
                solicitante =reqInsumo.solicitante,
                revisor =reqInsumo.revisor,
                autorizante =reqInsumo.autorizante,
                nombreinsumo =reqInsumo.nombreinsumo,
                cantidad =reqInsumo.cantidad,
                observaciones =reqInsumo.observaciones,
                centro_costo =reqInsumo.centro_costo,
                prioridad =reqInsumo.prioridad,
                unidad =reqInsumo.unidad          
                                
            };
            return Page();
        }

        public async Task <IActionResult> Onpost(ModificarRequisicionInsumo cmd){
            if(!ModelState.IsValid){
                Detalles =  new DatosAEditar(){
                id =cmd.id,
                solicitante =cmd.solicitante,
                revisor =cmd.revisor,
                autorizante =cmd.autorizante,
                nombreinsumo =cmd.nombreinsumo,
                cantidad =cmd.cantidad,
                observaciones =cmd.observaciones,
                centro_costo =cmd.centro_costo,
                prioridad =cmd.prioridad,
                unidad =cmd.unidad   
                };
                return Page();
            }
                 var insumo = await mediator.Send(new ConsultarRequisicionInsumoId(cmd.id));
          
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
                public string solicitante{ set; get; }
                public string revisor { set; get; }
                public string autorizante{ set; get; }
                public string nombreinsumo{ set; get; }
                public float cantidad{ set; get; }  
                public string observaciones{ set; get; }
                public string centro_costo{ set; get; }
                public string prioridad{ set; get; }
                public string unidad { set; get; }
    }
}