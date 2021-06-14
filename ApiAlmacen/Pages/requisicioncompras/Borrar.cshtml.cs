using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using ApiAlmacen.Dominio;

namespace ApiAlmacen.Pages.requisicioncompras
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
           var estudiante = await mediator.Send(new ConsultarRequisicionCompraId(id));
          
            if(estudiante == null){
                return NotFound();
            }
                idaborrar= estudiante.id;

            return Page();
        }

               public async Task<IActionResult> OnPost(BorrarRequisicionCompra cmd){

             if(!ModelState.IsValid){
                idaborrar = cmd.id;
                return Page();
            }
                  var estudiante = await mediator.Send(new ConsultarRequisicionCompraId(cmd.id));
          
            if(estudiante == null){
                return NotFound();
            }
            
            var res = await mediator.Send(cmd);

            return RedirectToPage("./Index");

      

              }
              
    }
}
