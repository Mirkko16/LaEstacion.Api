﻿using LaEstacion.DTO.Request.Venta;
using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Ventas
{
    public interface IVentaRepository
    {
        Task<List<VentaModel>> GetAllVentas();
        Task<VentaModel?> GetVentaById(int ventaId);
        Task<VentaModel> AddVenta(VentaModel venta);        
    }
}
