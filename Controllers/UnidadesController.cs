using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Unidades;
using LaEstacion.DTO.Request.Unidad;

namespace LaEstacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesController : ControllerBase
    {
        private readonly IUnidadRepository _repository;
        private readonly IMapper _mapper;

        public UnidadesController(IUnidadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllUnidadesAsync()
        {
            try
            {
                var unidad = await _repository.GetAllUnidades();

                var response = _mapper.Map<List<UnidadResponse>>(unidad);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{unidadId}")]
        public async Task<ActionResult> GetUnidadesByIdAsync(int unidadId)
        {
            try
            {
                var unidad = await _repository.GetUnidadById(unidadId);

                if (unidad is null) return StatusCode(StatusCodes.Status404NotFound);

                var response = _mapper.Map<UnidadResponse>(unidad);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddUnidadAsync(UnidadRequest unidadRequest)
        {
            try
            {
                var unidadToAdd = _mapper.Map<UnidadModel>(unidadRequest);

                await _repository.AddUnidad(unidadToAdd);

                var response = _mapper.Map<UnidadResponse>(unidadToAdd);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{unidadId}")]
        public async Task<ActionResult> DeleteUnidadAsync(int unidadId)
        {
            try
            {
                var unidadToDelete = await _repository.GetUnidadById(unidadId);

                if (unidadToDelete is null) return NotFound();

                await _repository.RemoveUnidad(unidadId);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUnidadAsync(UnidadUpdateRequest unidadUpdate)
        {
            try
            {
                var existingUnidad = await _repository.GetUnidadById(unidadUpdate.Id);

                if (existingUnidad is null) return StatusCode(StatusCodes.Status404NotFound);

                var unidadToUpdate = _mapper.Map<UnidadModel>(unidadUpdate);

                await _repository.UpdateUnidad(unidadToUpdate, existingUnidad);

                var response = _mapper.Map<UnidadResponse>(unidadToUpdate);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed at executing the request", ex);
            }
        }

    }
}



