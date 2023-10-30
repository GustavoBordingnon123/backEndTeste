using Gustav2.DataAcces;
using Gustav2.Repositorios.Interfaces;
using Gustav2.ViewData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gustav2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>> GetClientes()
        {
            List<ClienteModel> listaUsuarios = await _clienteRepositorio.GetClientes();
            return Ok(listaUsuarios);
    }

    [HttpGet("GetClienteByName")]
    public async Task<ActionResult<ClienteModel>> GetClienteByName(string NomeCliente)
    {
        ClienteModel cliente = await _clienteRepositorio.GetClienteByName(NomeCliente);
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteModel>> InsertCliente(ClienteModel ClienteNovo)
    {
        ClienteModel clienteNovo = await _clienteRepositorio.InsertCliente(ClienteNovo);
        return Ok(clienteNovo);
    }

    [HttpPut]
    public async Task<ActionResult<ClienteModel>> EditCliente(ClienteModel Cliente, int IdCliente)
    {
        ClienteModel clienteEditado = await _clienteRepositorio.EditCliente(Cliente, IdCliente);
        return Ok(clienteEditado);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteCliente(int IdCliente)
    {
        bool delete = await _clienteRepositorio.DeleteCliente(IdCliente);
        return Ok(delete);
    }
}
}
using Gustav2.DataAcces;
using Gustav2.Repositorios.Interfaces;
using Gustav2.ViewData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gustav2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>> GetClientes()
        {
            List<ClienteModel> listaClientes = await _clienteRepositorio.GetClientes();
            return Ok(listaClientes);
    }

    [HttpGet("ByName/{NomeCliente}")]
    public async Task<ActionResult<ClienteModel>> GetClienteByName(string NomeCliente)
    {
        ClienteModel cliente = await _clienteRepositorio.GetClienteByName(NomeCliente);
        if (cliente == null)
        {
            return NotFound(); // Retorna um status 404 se o cliente não for encontrado.
        }
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteModel>> InsertCliente(ClienteModel ClienteNovo)
    {
        ClienteModel clienteNovo = await _clienteRepositorio.InsertCliente(ClienteNovo);
        return CreatedAtAction(nameof(GetClienteByName), new { NomeCliente = clienteNovo.Nome }, clienteNovo);
    }

    [HttpPut("{IdCliente}")]
    public async Task<ActionResult<ClienteModel>> EditCliente(int IdCliente, ClienteModel Cliente)
    {
        ClienteModel clienteEditado = await _clienteRepositorio.EditCliente(Cliente, IdCliente);
        if (clienteEditado == null)
        {
            return NotFound(); // Retorna um status 404 se o cliente não for encontrado.
        }
        return Ok(clienteEditado);
    }

    [HttpDelete("{IdCliente}")]
    public async Task<ActionResult<bool>> DeleteCliente(int IdCliente)
    {
        bool delete = await _clienteRepositorio.DeleteCliente(IdCliente);
        if (!delete)
        {
            return NotFound(); // Retorna um status 404 se o cliente não for encontrado.
        }
        return Ok(delete);
    }
}
}
