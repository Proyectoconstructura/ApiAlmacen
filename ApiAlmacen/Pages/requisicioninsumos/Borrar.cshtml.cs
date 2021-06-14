using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using ApiAlmacen.Dominio;

namespace ApiAlmacen.Pages.requisicioninsumos
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
           var insumo = await mediator.Send(new ConsultarRequisicionCompraId(id));
          
            if(insumo == null){
                return NotFound();
            }
                idaborrar= insumo.id;
            return Page();
        }

               public async Task<IActionResult> OnPost(BorrarRequisicionInsumos cmd){

             if(!ModelState.IsValid){
                idaborrar = cmd.id;
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
}