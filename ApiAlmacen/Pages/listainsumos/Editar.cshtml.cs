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


namespace ApiAlmacen.Pages.listainsumos
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
            var insumo = await mediator.Send(new ConsultarListaInsumoNombre(id));

            if(insumo ==null){
                return NotFound();
            }
            Detalles =  new DatosAEditar(){
                id = insumo.idlista,
                proyecto = insumo.proyecto,
                clave = insumo.clave,
                nombreinsumo= insumo.nombreinsumo,
                partida =  insumo.partida,
                cantidad    = insumo.cantidad,
                unidadmedida = insumo.unidadmedida
            };
            return Page();
        }

        public async Task <IActionResult> Onpost(ModificarListainsumo cmd){
            if(!ModelState.IsValid){
                Detalles =  new DatosAEditar(){
                    id =cmd.id,
                    proyecto = cmd.proyecto,
                    clave = cmd.clave,
                    nombreinsumo= cmd.nombreinsumo,
                    partida = cmd.partida,
                    cantidad = cmd.cantidad,
                    unidadmedida = cmd.unidadmedida
                };
                return Page();
            }
                 var insumo = await mediator.Send(new ConsultarListaInsumoNombre(cmd.id));
          
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
        public string proyecto { set; get; }
        public string clave { set; get; }
        public string nombreinsumo { set; get; }
        public string partida { set; get; }
        public float cantidad { set; get; }
        public string unidadmedida { set; get; }
    }
}