using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Ventas;
using LaEstacion.DTO.Request.Venta;
using LaEstacion.DTO.Request.Unidad;

namespace LaEstacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentaRepository _repository;
        private readonly IMapper _mapper;

        public VentasController(IVentaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllVentasAsync()
        {
            try
            {
                var venta = await _repository.GetAllVentas();

                var response = _mapper.Map<List<VentaResponse>>(venta);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{ventaId}")]
        public async Task<ActionResult> GetVentasByIdAsync(int ventaId)
        {
            try
            {
                var venta = await _repository.GetVentaById(ventaId);

                if (venta is null) return StatusCode(StatusCodes.Status404NotFound);

                var response = _mapper.Map<VentaResponse>(venta);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddVentaAsync(VentaRequest ventaRequest)
        {
            try
            {
                var ventaToAdd = _mapper.Map<VentaModel>(ventaRequest);

                await _repository.AddVenta(ventaToAdd);

                var response = _mapper.Map<VentaModel>(ventaRequest);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

       

        [HttpPut]
        public async Task<ActionResult> UpdateVentaAsync(VentaUpdateRequest ventaUpdate)
        {
            try
            {
                var existingVenta = await _repository.GetVentaById(ventaUpdate.Id);
                if (existingVenta is null) return StatusCode(StatusCodes.Status404NotFound);
                var ventaToUpdate = _mapper.Map<VentaModel>(ventaUpdate);

                

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed at executing the request", ex);
            }
        }

    }
}



