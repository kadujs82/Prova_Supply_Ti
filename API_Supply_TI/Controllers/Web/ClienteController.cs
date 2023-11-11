using API_Supply_TI.Models;
using API_Supply_TI.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API_Supply_TI.Models.AutoMap;

namespace API_Supply_TI.Controllers.Web
{
    [Route("api/[controller]/web")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientes _Icliente;
        public ClienteController(IClientes iCliente)
        {
            _Icliente = iCliente;

        }
        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> BuscarClientes()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteModel, ClienteView>();
            });

            var mapper = configuration.CreateMapper();

            List<ClienteModel> clientes = await _Icliente.BuscarClientes();
           // ClienteView rt = mapper.Map<ClienteView>(clientes); // Erro
            return clientes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> BuscarClientesId(int id)
        {
            ClienteModel clientes = await _Icliente.BuscarClientesId(id);
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> AdicionarCliente([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _Icliente.AdicionarCliente(clienteModel);
            return Ok(cliente);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> AtualizarCliente([FromBody] ClienteModel clienteModel, int id)
        {
            clienteModel.Id = id;
            ClienteModel cliente = await _Icliente.AtualizarCliente(clienteModel, id);
            return Ok(cliente);

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ClienteModel>> ExcluirCliente(int id)
        {
            bool result = await _Icliente.ExcluirCliente(id);
            return Ok(result);
        }
    }
}
