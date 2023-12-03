using AutoMapper;
using LaEstacion.DTO.Response;
using LaEstacion.Repository.Productos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LaEstacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        private readonly IProductoVendidoRepository _repository;
        private readonly IMapper _mapper;

        public ProductoVendidoController(IProductoVendidoRepository productoVendidorepository, IMapper mapper)
        {
            _repository = productoVendidorepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProductosVendidosAsync()
        {
            try
            {
                var productosVendidos = await _repository.GetAllProductosVendidos();

                var response = _mapper.Map<List<ProductoVendidoResponse>>(productosVendidos);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
