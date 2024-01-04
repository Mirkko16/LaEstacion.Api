using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaEstacion.Repository.Productos;
using LaEstacion.Services.Pdf;

namespace LaEstacion.Repository.Productos
{
    public class StockController
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IPdfService _pdfService;

        public StockController(IProductoRepository productoRepository, IPdfService pdfService)
        {
            _productoRepository = productoRepository;
            _pdfService = pdfService;
        }

        //public async Task VerificarStockMinimoYGenerarPdf()
        //{
        //    try
        //    {
        //        // Realiza la verificación de stock mínimo
        //        await _productoRepository.VerificarStockMinimo();

        //        // Obtén la lista de productos que están por debajo del stock mínimo
        //        var productosBajoStock = await _productoRepository.ObtenerProductosBajoStockMinimo();

        //        // Genera el PDF con la lista de productos
        //        var pdfBytes = _pdfService.GenerarPdf(productosBajoStock);

        //        // Puedes guardar el PDF en el sistema de archivos, enviarlo por correo, etc.
        //        // Por ejemplo, guardarlo en la carpeta "ArchivosGenerados"
        //        var rutaPdf = $"ArchivosGenerados/ProductosBajoStock_{DateTime.Now:yyyyMMddHHmmss}.pdf";
        //        System.IO.File.WriteAllBytes(rutaPdf, pdfBytes);

        //        // Puedes realizar otras acciones según tus necesidades
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de errores
        //        Console.WriteLine($"Error al verificar stock mínimo y generar PDF: {ex.Message}");
        //    }
        //}
    }
}
