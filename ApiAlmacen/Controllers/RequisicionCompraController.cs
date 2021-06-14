using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ApiAlmacen.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using MediatR;
using ApiAlmacen.Dominio;
namespace ApiAlmacen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequisicionCompraController : ControllerBase
        {
            private readonly IMediator mediator;
            public RequisicionCompraController(IMediator mediator)
            {
                this.mediator= mediator;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll(){
                return Ok(await mediator.Send(new ConsultarRequisicionCompra()));
            }
            [HttpPost]
             public async Task<IActionResult> Create(CrearListaRequisicionCompra command)
            {
            return Ok(await mediator.Send(command));
            }
    }
}