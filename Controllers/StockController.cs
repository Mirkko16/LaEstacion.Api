using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Productos;
using LaEstacion.Services.Pdf;

namespace LaEstacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IPdfService _pdfService;

        public StockController(IProductoRepository productoRepository, IPdfService pdfService)
        {
            _productoRepository = productoRepository;
            _pdfService = pdfService;
        }

        [HttpGet("verificar-stock-generar-pdf")]
        public async Task<ActionResult> VerificarStockMinimoYGenerarPdf()
        {
            try
            {

                var productosBajoStock = await _productoRepository.ObtenerProductosBajoStockMinimo();

                if (productosBajoStock.Count > 0)
                {

                    var pdfBytes = _pdfService.GenerarPdf(productosBajoStock);

                    var rutaPdf = $"ArchivosGenerados/ProductosBajoStock_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                    System.IO.File.WriteAllBytes(rutaPdf, pdfBytes);
                }
                else
                {
                    Console.WriteLine("No hay productos por debajo del stock mínimo.");                    
                }

                return Ok();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error al verificar stock mínimo y generar PDF: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
