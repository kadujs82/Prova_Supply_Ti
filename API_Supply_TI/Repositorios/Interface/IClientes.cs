using API_Supply_TI.Models;

namespace API_Supply_TI.Repositorios.Interface
{
    public interface IClientes
    {
        Task<List<ClienteModel>> BuscarClientes();
        Task<ClienteModel> BuscarClientesId(int id);
        Task<ClienteModel> AdicionarCliente(ClienteModel cliente);
        Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int id);
        Task<bool> ExcluirCliente(int id);

    }
}
