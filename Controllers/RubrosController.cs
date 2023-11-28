using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Rubros;
using LaEstacion.DTO.Request.Rubro;

namespace LaEstacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RubrosController : ControllerBase
    {
        private readonly IRubroRepository _repository;
        private readonly IMapper _mapper;

        public RubrosController(IRubroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllRubrosAsync()
        {
            try
            {
                var rubro = await _repository.GetAllRubros();

                var response = _mapper.Map<List<RubroResponse>>(rubro);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{rubroId}")]
        public async Task<ActionResult> GetRubrosByIdAsync(int rubroId)
        {
            try
            {
                var rubro = await _repository.GetRubroById(rubroId);

                if (rubro is null) return StatusCode(StatusCodes.Status404NotFound);

                var response = _mapper.Map<RubroResponse>(rubro);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddRubroAsync(RubroRequest rubroRequest)
        {
            try
            {
                var rubroToAdd = _mapper.Map<RubroModel>(rubroRequest);

                await _repository.AddRubro(rubroToAdd);

                var response = _mapper.Map<RubroResponse>(rubroToAdd);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{rubroId}")]
        public async Task<ActionResult> DeleteRubroAsync(int rubroId)
        {
            try
            {
                var rubroToDelete = await _repository.GetRubroById(rubroId);

                if (rubroToDelete is null) return NotFound();

                await _repository.RemoveRubro(rubroId);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRubroAsync(RubroUpdateRequest rubroUpdate)
        {
            try
            {
                var existingRubro = await _repository.GetRubroById(rubroUpdate.Id);

                if (existingRubro is null) return StatusCode(StatusCodes.Status404NotFound);

                var rubroToUpdate = _mapper.Map<RubroModel>(rubroUpdate);

                await _repository.UpdateRubro(rubroToUpdate, existingRubro);

                var response = _mapper.Map<RubroResponse>(rubroToUpdate);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar el Rubro", ex);
            }
        }

    }
}



