using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using ApiAlmacen.Dominio;

namespace ApiAlmacen.Pages.entradas
{
    public class CrearModel : PageModel
    {

        private readonly ILogger<CrearModel> _logger;
        private readonly IMediator mediator;

     public string nomalmacen { set; get; } 
        public string nomproveedor { set; get; } 
        public string nombreinsumo { set; get; } 
       
        public int id_compra { set; get; } 
        
        public  float cantidad { set; get; } 
        public float precio_unitario { set; get; } 
        
        

           public CrearModel(ILogger<CrearModel> logger, IMediator mediatr){

               _logger = logger;
                mediator = mediatr;
           }

            public async Task<IActionResult> OnPost(CrearEntrada cmd ){
                
                if(!ModelState.IsValid){
                
                nomalmacen= cmd.nomalmacen;
                nomproveedor= cmd.nomproveedor;
                nombreinsumo =cmd.nombreinsumo;
                id_compra =cmd.id_compra;
                cantidad =cmd.cantidad;
                precio_unitario= cmd.precio_unitario;
                 
                    
                return Page();
                }
                 var res = await  mediator.Send(cmd);

            return RedirectToPage("./Index");
               

        }
    }
}