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
    public class EntradaController : ControllerBase
        {
            private readonly IMediator mediator;
            public EntradaController(IMediator mediator)
            {
                this.mediator= mediator;
            }
             [HttpGet]
            public async Task<IActionResult> GetAll(){
                return Ok(await mediator.Send(new ConsultarEntrada()));
            }
            [HttpPost]
             public async Task<IActionResult> Create(CrearEntrada command)
            {
            return Ok(await mediator.Send(command));
            }
    }
}