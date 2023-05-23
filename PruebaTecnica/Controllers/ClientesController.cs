using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DTOs;
using PruebaTecnica.Entidades;

namespace PruebaTecnica.Controllers
{

    [ApiController]
    [Route("api/Clientes")]
    public class ClientesController : ControllerBase
    {

        private readonly AplicationDbContext context;
        private readonly IMapper mapper;

        public ClientesController(AplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet("{id:int}")]
        public async Task<ClienteDTOs> GetClientesID(int id)
        {

            var cliente = await context.Cliente
                .Include(DBDireccion => DBDireccion.Direcciones).FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<ClienteDTOs>(cliente);
        }



        [HttpGet]
        public async Task<List<ClienteDTOs>> GetClientes()
        {
            
            var clientes = await context.Cliente.ToListAsync();

            return mapper.Map<List<ClienteDTOs>>(clientes);
        }


        [HttpPost]
        public async Task<ActionResult> PostClientes([FromBody] ClienteCreacionDTOs clienteCreacionDTOs)
        {
            var existeClienteConElMismoNombre = await context.Cliente.AnyAsync(x => x.Nombre == clienteCreacionDTOs.Nombre);

            if (existeClienteConElMismoNombre)
            {
                return BadRequest($"Ya existe un cliente con el ese nombre {clienteCreacionDTOs.Nombre}");
            }


            var cliente = mapper.Map<Cliente>(clienteCreacionDTOs);

            context.Add(cliente);
            context.SaveChangesAsync();
            return Ok();
        }



        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutClientes([FromBody]ClienteDTOs clienteDto, int id)
        {

            if(clienteDto.Id != id)
            {
                return BadRequest("El id De cliente no coincide con el id de la URL");
            }

            var existeCliente = await context.Cliente.AnyAsync(x => x.Id == id);

            if (!existeCliente)
            {
                return NotFound();

            }


            var cliente = mapper.Map<Cliente>(clienteDto);



            context.Update(cliente);
            await context.SaveChangesAsync();
            return Ok("El Cliente se Actualizo Correctamente");
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {

            var existeCliente = await context.Cliente.AnyAsync(x => x.Id == id);

            if (!existeCliente)
            {
                return NotFound();
            }

            context.Remove(new Cliente() { Id = id });
            await context.SaveChangesAsync();
            return Ok("El Cliente Fue eliminado Correctamente");
        }
    }



    
}
