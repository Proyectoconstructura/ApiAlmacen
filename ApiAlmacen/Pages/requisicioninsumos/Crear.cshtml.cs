using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using ApiAlmacen.Dominio;

namespace ApiAlmacen.Pages.requisicioninsumos
{
    public class CrearModel : PageModel
    {

        private readonly ILogger<CrearModel> _logger;
        private readonly IMediator mediator;
    
         public string solicitante{ set; get; }
        public string revisor { set; get; }
        public string autorizante{ set; get; }
        public string nombreinsumo{ set; get; }
        public float cantidad{ set; get; }  
        public string observaciones{ set; get; }
        public string centro_costo{ set; get; }
        public string prioridad{ set; get; }
        public string unidad { set; get; }
        

           public CrearModel(ILogger<CrearModel> logger, IMediator mediatr){

               _logger = logger;
                mediator = mediatr;
           }

            public async Task<IActionResult> OnPost(CrearRequisicionInsumo cmd ){

                if(!ModelState.IsValid){
                    solicitante=cmd.solicitante;
                    revisor=cmd.revisor;
                    autorizante=cmd.autorizante;
                    nombreinsumo=cmd.nombreinsumo;
                    cantidad=cmd.cantidad;
                    observaciones=cmd.observaciones;
                    centro_costo=cmd.centro_costo;
                    prioridad=cmd.prioridad;
                    unidad=cmd.unidad;
                
                return Page();
                }
                 var res = await  mediator.Send(cmd);

            return RedirectToPage("./Index");
               

        }
    }
}