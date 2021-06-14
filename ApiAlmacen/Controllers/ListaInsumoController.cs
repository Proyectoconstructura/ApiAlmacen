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
    public class ListainsumoController : ControllerBase
        {
            private readonly IMediator mediator;
            public ListainsumoController(IMediator mediator)
            {
                this.mediator= mediator;
            }
            [HttpGet]
            public async Task<ActionResult<List<ListaInsumoModelo>>> Get(){
               var modelo =  await mediator.Send(new ConsultarListaInsumo());
               return modelo;
               // return Ok(await mediator.Send(new ConsultarListaInsumo()));
            }
            [HttpPost]
             public async Task<IActionResult> Create(CrearListaInsumo command)
            {
            return Ok(await mediator.Send(command));
            }
            [HttpPost("{Id}")]
            public async Task<IActionResult>Delete(int Id)
            {
                return Ok(await mediator.Send(new Borrarlistainsumo{id=Id}));
            }
            /*[HttpPut("{id}")]
            public async Task<IActionResult> Update (int id , ModificarListainsumo request)
            {
                if(id != request.id)
                 {
                    return BadRequest();
                 }
                return Ok(await mediator.Send(request));
            }*/
    }
}