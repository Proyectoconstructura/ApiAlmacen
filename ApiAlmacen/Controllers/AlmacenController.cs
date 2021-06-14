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
    public class AlmacenController : ControllerBase
        {
            private readonly IMediator mediator;

            public AlmacenController(IMediator mediator)
            {
                this.mediator= mediator;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll(){
                return Ok(await mediator.Send(new LeerTodoInventario()));
            }

            [HttpGet("{nombre}")]
            public async Task<IActionResult> GetByName(string nombre){
                return Ok(await mediator.Send(new LeerInventarioNombre(nombre)));
            }
    }
}

