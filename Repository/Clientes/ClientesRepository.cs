using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Clientes
{
    public class ClientesRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClienteModel> AddCliente(ClienteModel cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar cliente", ex);
            }
        }
               

        public async Task<List<ClienteModel>> GetAllClientes()
        {
            try
            {
                var clientes = await _context.Clientes.ToListAsync();
                return clientes;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todos los clientes", ex);
            }
        }

        public async Task<ClienteModel?> GetClienteById(int clienteId)
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == clienteId);
                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception("Cliente no encontrado", ex);
            }
        }

        public async Task RemoveCliente(int clienteId)
        {
            try
            {
                var index = await GetClienteById(clienteId);
                _context.Clientes.Remove(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente", ex);
            }
        }

        public async Task<ClienteModel> UpdateCliente(ClienteModel cliente)
        {
            try
            {
                var cliente_A_Actualizar = await GetClienteById(cliente.Id);
                cliente_A_Actualizar.Nombre = cliente.Nombre;
                cliente_A_Actualizar.Apellido = cliente.Apellido;
                cliente_A_Actualizar.Telefono = cliente.Telefono;
                cliente_A_Actualizar.Activo = cliente.Activo;

                await _context.SaveChangesAsync();
                return cliente_A_Actualizar;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar el cliente", ex);
            }
        }
    }
}
