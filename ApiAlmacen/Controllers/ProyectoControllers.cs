using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ApiAlmacen.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using MediatR;
using ApiAlmacen.Dominio.DProyecto;
namespace ApiAlmacen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
        {
            private readonly IMediator mediator;
            public ProyectoController(IMediator mediator)
            {
                this.mediator= mediator;
            }
            [HttpGet]
            public async Task<ActionResult<List<proyectomodel>>> Get(){
               var modelo =  await mediator.Send(new cosultarproyecto());
               return modelo;
               
            }
            [HttpGet("{Id}")]
            public async Task<IActionResult> GetByNom(string Nom)
            {
                return Ok(await mediator.Send(new cosultarproyectonom{nom = Nom}));
            }
            [HttpPost]
             public async Task<IActionResult> Create(Crearproyecto command)
            {
            return Ok(await mediator.Send(command));
            }
            [HttpDelete("{Id}")]
            public async Task<IActionResult>Delete(int Id)
            {
                return Ok(await mediator.Send(new borrarproyecto{id=Id}));
            }
           [HttpPut("{Id}")]
            public async Task<IActionResult> Update (int Id , modificarproyecto request)
            {
                if(Id != request.id_proyecto)
                 {
                    return BadRequest();
                 }
                return Ok(await mediator.Send(request));
            }
    }
}