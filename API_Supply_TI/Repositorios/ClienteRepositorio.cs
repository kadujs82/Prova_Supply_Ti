using API_Supply_TI.Data;
using API_Supply_TI.Models;
using API_Supply_TI.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace API_Supply_TI.Repositorios
{
    public class ClienteRepositorio : IClientes
    {
        private readonly Suply_DBContext _dbcontext;
        public ClienteRepositorio(Suply_DBContext suply_DBContext)
        {
            _dbcontext = suply_DBContext;
        }

        public async Task<List<ClienteModel>> BuscarClientes()
        {
            return await _dbcontext.Clientes.ToListAsync();
        }

        public async Task<List<ClienteModel>> BuscarClientes2()
        {
            return await _dbcontext.Clientes.ToListAsync();
        }


        public async Task<ClienteModel> BuscarClientesId(int id)
        {
            return await _dbcontext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ClienteModel> AdicionarCliente(ClienteModel cliente)
        {
            await _dbcontext.Clientes.AddAsync(cliente);
            await _dbcontext.SaveChangesAsync();
            return cliente;
        }

        public async Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int id)
        {
            ClienteModel ClientePorId = await BuscarClientesId(id);
            if(ClientePorId == null)
            {
                throw new Exception($"Cliente do ID:{id}, não encontrado.");
            }
            ClientePorId.Name = cliente.Name;
            ClientePorId.Cpf = cliente.Cpf;
            ClientePorId.Email = cliente.Email;
            ClientePorId.Telefone = cliente.Telefone;

            _dbcontext.Clientes.Update(ClientePorId);
            _dbcontext.SaveChanges();
            return ClientePorId;
        }

       
        public async Task<bool> ExcluirCliente(int id)
        {
            ClienteModel ClientePorId = await BuscarClientesId(id);
            if (ClientePorId == null)
            {
                throw new Exception($"Cliente do ID:{id}, não encontrado.");
            }
            _dbcontext.Clientes.Remove(ClientePorId);
            _dbcontext.SaveChanges();
            return true;

        }
    }
}
