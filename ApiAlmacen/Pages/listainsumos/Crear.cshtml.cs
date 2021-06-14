using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using ApiAlmacen.Dominio;

namespace ApiAlmacen.Pages.listainsumos
{
    public class CrearModel : PageModel
    {

        private readonly ILogger<CrearModel> _logger;
        private readonly IMediator mediator;

        public string proyecto { set; get; }
        public string clave { set; get; }
        public string nombreinsumo { set; get; }
        public string partida { set; get; }
        public float cantidad { set; get; }
        public string unidadmedida { set; get; }

           public CrearModel(ILogger<CrearModel> logger, IMediator mediatr){

               _logger = logger;
                mediator = mediatr;
           }

            public async Task<IActionResult> OnPost(CrearListaInsumo cmd ){
                
                if(!ModelState.IsValid){
                proyecto=cmd.proyecto;
                clave=cmd.clave;
                nombreinsumo=cmd.nombreinsumo;
                partida=cmd.partida;
                cantidad=cmd.cantidad;
                unidadmedida=cmd.unidadmedida;
                return Page();
                }
                 var res = await  mediator.Send(cmd);

            return RedirectToPage("./Index");
               

        }
    }
}