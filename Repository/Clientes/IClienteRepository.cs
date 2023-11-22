using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Clientes
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> GetAllClientes();
        Task<ClienteModel?> GetClienteById(int clienteId);
        Task<ClienteModel> AddCliente(ClienteModel cliente);
        Task<ClienteModel> UpdateCliente(ClienteModel cliente);
        Task RemoveCliente(int clienteId);        
    }
}
