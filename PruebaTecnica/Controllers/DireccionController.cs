using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DTOs;
using PruebaTecnica.Entidades;

namespace PruebaTecnica.Controllers
{

    [ApiController]
    [Route("api/Cliente/Direccion/{clienteId:int}")]
    public class DireccionController: ControllerBase
    {

        private readonly AplicationDbContext context;
        private readonly IMapper mapper;

        public DireccionController(AplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<ActionResult<List<DireccionDTOs>>> GetDirecciones(int clienteId)
        {

            var direcciones = await context.Direcciones
                                   .Where(DireccionDB => DireccionDB.ClienteId == clienteId).ToListAsync();

            return mapper.Map<List<DireccionDTOs>>(direcciones);
        }


        [HttpPost]
        public async Task<ActionResult> PostDireccion(int clienteId, DireccionesCreacionDTOs direccionesDtos)
        {

            var existeCliente = await context.Cliente.AnyAsync(x => x.Id == clienteId);

            if (!existeCliente)
            {
                return BadRequest($"No hay un cliente con este Id {clienteId}");
            }

            var direccion = mapper.Map<Direcciones>(direccionesDtos);
            direccion.ClienteId = clienteId;
            context.Add(direccion);
            context.SaveChangesAsync();
            return Ok();

        }
    }
}
