using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.DTO.Request;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Productos;

namespace LaEstacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;

        public ProductosController(IProductoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllProductosAsync()
        {
            try
            {
                var producto = await _repository.GetAllProductos();

                var response = _mapper.Map<List<ProductoResponse>>(producto);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{productoId}")]
        public async Task<ActionResult> GetProductosByIdAsync(int productoId)
        {
            try
            {
                var producto = await _repository.GetProductoById(productoId);

                if (producto is null) return StatusCode(StatusCodes.Status404NotFound);

                var response = _mapper.Map<ProductoResponse>(producto);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddProductoAsync(ProductoRequest productoRequest)
        {
            try
            {
                var productoToAdd = _mapper.Map<ProductoModel>(productoRequest);

                await _repository.AddProducto(productoToAdd);

                var response = _mapper.Map<ProductoResponse>(productoToAdd);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{productoId}")]
        public async Task<ActionResult> DeleteProductoAsync(int productoId)
        {
            try
            {
                var productoToDelete = await _repository.GetProductoById(productoId);

                if (productoToDelete is null) return NotFound();

                await _repository.RemoveProducto(productoId);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProductoAsync(ProductoUpdateRequest productoUpdate)
        {
            try
            {
                var existingProducto = await _repository.GetProductoById(productoUpdate.Id);

                if (existingProducto is null) return StatusCode(StatusCodes.Status404NotFound);

                var productoToUpdate = _mapper.Map<ProductoModel>(productoUpdate);

                await _repository.UpdateProducto(productoToUpdate, existingProducto);

                var response = _mapper.Map<ProductoResponse>(productoToUpdate);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed at executing the request", ex);
            }
        }

    }
}



