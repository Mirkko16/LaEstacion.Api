﻿using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.DTO.Request.Producto
{
    public class ProductoUpdateRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodBarra { get; set; }
        public int MarcaId { get; set; }
        public int FamiliaId { get; set; }
        public int RubroId { get; set; }
        public int UnidadId { get; set; }
        public int ProveedorId { get; set; }
        public decimal Costo { get; set; }
        public decimal Rentabilidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
        public bool Eliminado { get; set; }
    }
}
