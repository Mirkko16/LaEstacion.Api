using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Proveedores
{
    public interface IProveedorRepository
    {
        Task<List<ProveedorModel>> GetAllProveedores();
        Task<ProveedorModel?> GetProveedorById(int proveedorId);
        Task<ProveedorModel> AddProveedor(ProveedorModel proveedor);
        Task<ProveedorModel> UpdateProveedor(ProveedorModel proveedor, ProveedorModel existingProveedor);
        Task RemoveProveedor(int proveedorId);
    }
}
