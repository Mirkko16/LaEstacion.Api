﻿using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.DTO.Response
{
    public class VentaResponse
    {
        public int Id { get; set; }
        public int NumVenta { get; set; }
        public ClienteModel Cliente { get; set; }
        public List<ProductoVendidoModel> Producto { get; set; }
        public DateTime FechaVenta { get; set; }
        public string TipoPago { get; set; }
        public string TipoComprobante { get; set; }
        public int Descuento { get; set; }
        public decimal GananciaCuentasCorriente { get; set; }        
        public decimal Total { get; set; }
    }
}
