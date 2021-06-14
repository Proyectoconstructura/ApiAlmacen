using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAlmacen.Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ApiAlmacen.Pages.requisicioncompras
{
    public class IndexModel : PageModel 
    {
        public List<ListaCompraModelo> requisicioncompras {get; set;}
        private readonly ILogger<IndexModel> _logger;
        private readonly IMediator mediator;

        public IndexModel(ILogger<IndexModel> logger, IMediator mediatr)
        {
            _logger = logger;
            mediator=mediatr;
        }
        public async Task OnGet()
        {
            var modelo = await mediator.Send( new ConsultarRequisicionCompra());
            requisicioncompras =modelo;
        }
    }
}