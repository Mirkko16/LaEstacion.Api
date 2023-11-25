using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.DTO.Request;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Proveedores;

namespace LaEstacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedorRepository _repository;
        private readonly IMapper _mapper;

        public ProveedoresController(IProveedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllProveedoresAsync()
        {
            try
            {
                var proveedor = await _repository.GetAllProveedores();

                var response = _mapper.Map<List<ProveedorResponse>>(proveedor);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{proveedorId}")]
        public async Task<ActionResult> GetProveedoresByIdAsync(int proveedorId)
        {
            try
            {
                var proveedor = await _repository.GetProveedorById(proveedorId);

                if (proveedor is null) return StatusCode(StatusCodes.Status404NotFound);

                var response = _mapper.Map<ProveedorResponse>(proveedor);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddProveedorAsync(ProveedorRequest proveedorRequest)
        {
            try
            {
                var proveedorToAdd = _mapper.Map<ProveedorModel>(proveedorRequest);

                await _repository.AddProveedor(proveedorToAdd);

                var response = _mapper.Map<ProveedorResponse>(proveedorToAdd);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{proveedorId}")]
        public async Task<ActionResult> DeleteProveedorAsync(int proveedorId)
        {
            try
            {
                var proveedorToDelete = await _repository.GetProveedorById(proveedorId);

                if (proveedorToDelete is null) return NotFound();

                await _repository.RemoveProveedor(proveedorId);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProveedorAsync(ProveedorUpdateRequest proveedorUpdate)
        {
            try
            {
                var existingProveedor = await _repository.GetProveedorById(proveedorUpdate.Id);

                if (existingProveedor is null) return StatusCode(StatusCodes.Status404NotFound);

                var proveedorToUpdate = _mapper.Map<ProveedorModel>(proveedorUpdate);

                await _repository.UpdateProveedor(proveedorToUpdate, existingProveedor);

                var response = _mapper.Map<ProveedorResponse>(proveedorToUpdate);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed at executing the request", ex);
            }
        }

    }
}



