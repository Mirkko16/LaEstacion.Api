using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Marcas;
using LaEstacion.DTO.Request.Marca;

namespace LaEstacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaRepository _repository;
        private readonly IMapper _mapper;

        public MarcasController(IMarcaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllMarcasAsync()
        {
            try
            {
                var marca = await _repository.GetAllMarcas();

                var response = _mapper.Map<List<MarcaResponse>>(marca);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{marcaId}")]
        public async Task<ActionResult> GetMarcasByIdAsync(int marcaId)
        {
            try
            {
                var marca = await _repository.GetMarcaById(marcaId);

                if (marca is null) return StatusCode(StatusCodes.Status404NotFound);

                var response = _mapper.Map<MarcaResponse>(marca);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddMarcaAsync(MarcaRequest marcaRequest)
        {
            try
            {
                var marcaToAdd = _mapper.Map<MarcaModel>(marcaRequest);

                await _repository.AddMarca(marcaToAdd);

                var response = _mapper.Map<MarcaResponse>(marcaToAdd);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{marcaId}")]
        public async Task<ActionResult> DeleteMarcaAsync(int marcaId)
        {
            try
            {
                var marcaToDelete = await _repository.GetMarcaById(marcaId);

                if (marcaToDelete is null) return NotFound();

                await _repository.RemoveMarca(marcaId);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMarcaAsync(MarcaUpdateRequest marcaUpdate)
        {
            try
            {
                var existingMarca = await _repository.GetMarcaById(marcaUpdate.Id);

                if (existingMarca is null) return StatusCode(StatusCodes.Status404NotFound);

                var marcaToUpdate = _mapper.Map<MarcaModel>(marcaUpdate);

                await _repository.UpdateMarca(marcaToUpdate, existingMarca);

                var response = _mapper.Map<MarcaResponse>(marcaToUpdate);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed at executing the request", ex);
            }
        }

    }
}



