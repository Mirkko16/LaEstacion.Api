using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Proveedores
{
    public class ProveedoresRepository : IProveedorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProveedorModel> AddProveedor(ProveedorModel proveedor)
        {
            try
            {
                _context.Proveedores.Add(proveedor);
                await _context.SaveChangesAsync();
                return proveedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar proveedor", ex);
            }
        }


        public async Task<List<ProveedorModel>> GetAllProveedores()
        {
            try
            {
                var proveedores = await _context.Proveedores.ToListAsync();
                return proveedores;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todos los proveedores", ex);
            }
        }

        public async Task<ProveedorModel?> GetProveedorById(int proveedorId)
        {
            try
            {
                var proveedor = await _context.Proveedores.FirstOrDefaultAsync(proveedor => proveedor.Id == proveedorId);
                return proveedor;
            }
            catch (Exception ex)
            {

                throw new Exception("Proveedor no encontrado", ex);
            }
        }

        public async Task RemoveProveedor(int proveedorId)
        {
            try
            {
                var index = await GetProveedorById(proveedorId);
                _context.Proveedores.Remove(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el proveedor", ex);
            }
        }

        public async Task<ProveedorModel> UpdateProveedor(ProveedorModel proveedor, ProveedorModel existingProveedor)
        {
            try
            {

                existingProveedor.Nombre = proveedor.Nombre;
                existingProveedor.Apellido = proveedor.Apellido;
                existingProveedor.CUIT = proveedor.CUIT;
                existingProveedor.Correo = proveedor.Correo;
                existingProveedor.Telefono = proveedor.Telefono;
                existingProveedor.Debe = proveedor.Debe;
                existingProveedor.Haber = proveedor.Haber;
                existingProveedor.Saldo = proveedor.Saldo;
                existingProveedor.Activo = proveedor.Activo;

                await _context.SaveChangesAsync();
                return existingProveedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar el proveedor", ex);
            }
        }

        
    }
}
