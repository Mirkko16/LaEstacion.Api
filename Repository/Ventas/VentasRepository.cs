using LaEstacion.DTO.Request.Venta;
using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Ventas
{
    public class VentasRepository : IVentaRepository
    {
        public Task<VentaModel> AddVenta(VentaRequest producto)
        {
            throw new NotImplementedException();
        }

        public Task<List<VentaModel>> GetAllVentas()
        {
            throw new NotImplementedException();
        }

        public Task<VentaModel?> GetVentaById(int ventaId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveVenta(int idVenta)
        {
            throw new NotImplementedException();
        }
    }
}
