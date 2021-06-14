using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using ApiAlmacen.Dominio;

namespace ApiAlmacen.Pages.listainsumos
{
    public class BorrarModel : PageModel
    {
        public int idaborrar {get; set;}
         private readonly ILogger<BorrarModel> _logger;
        private readonly IMediator mediator;

        public BorrarModel(ILogger<BorrarModel> logger,
            IMediator mediat)
            {
                _logger = logger;
                mediator = mediat;
            
         }

             public async Task<IActionResult> OnGet(int id)
        {
           var estudiante = await mediator.Send(new ConsultarListaInsumoNombre(id));
          
            if(estudiante == null){
                return NotFound();
            }
                idaborrar= estudiante.idlista;

            return Page();
        }

               public async Task<IActionResult> OnPost(Borrarlistainsumo cmd){

             if(!ModelState.IsValid){
                idaborrar = cmd.id;
                return Page();
            }
                  var estudiante = await mediator.Send(new ConsultarListaInsumoNombre(cmd.id));
          
            if(estudiante == null){
                return NotFound();
            }
            
            var res = await mediator.Send(cmd);

            return RedirectToPage("./Index");

      

              }
              
    }
}
