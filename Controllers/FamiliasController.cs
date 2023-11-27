using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Familias;
using LaEstacion.DTO.Request.Familia;

namespace LaEstacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FamiliasController : ControllerBase
    {
        private readonly IFamiliaRepository _repository;
        private readonly IMapper _mapper;

        public FamiliasController(IFamiliaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllFamiliasAsync()
        {
            try
            {
                var familia = await _repository.GetAllFamilias();

                var response = _mapper.Map<List<FamiliaResponse>>(familia);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{familiaId}")]
        public async Task<ActionResult> GetFamiliasByIdAsync(int familiaId)
        {
            try
            {
                var familia = await _repository.GetFamiliaById(familiaId);

                if (familia is null) return StatusCode(StatusCodes.Status404NotFound);

                var response = _mapper.Map<FamiliaResponse>(familia);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddFamiliaAsync(FamiliaRequest familiaRequest)
        {
            try
            {
                var familiaToAdd = _mapper.Map<FamiliaModel>(familiaRequest);

                await _repository.AddFamilia(familiaToAdd);

                var response = _mapper.Map<FamiliaResponse>(familiaToAdd);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{familiaId}")]
        public async Task<ActionResult> DeleteFamiliaAsync(int familiaId)
        {
            try
            {
                var familiaToDelete = await _repository.GetFamiliaById(familiaId);

                if (familiaToDelete is null) return NotFound();

                await _repository.RemoveFamilia(familiaId);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateFamiliaAsync(FamiliaUpdateRequest familiaUpdate)
        {
            try
            {
                var existingFamilia = await _repository.GetFamiliaById(familiaUpdate.Id);

                if (existingFamilia is null) return StatusCode(StatusCodes.Status404NotFound);

                var familiaToUpdate = _mapper.Map<FamiliaModel>(familiaUpdate);

                await _repository.UpdateFamilia(familiaToUpdate, existingFamilia);

                var response = _mapper.Map<FamiliaResponse>(familiaToUpdate);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed at executing the request", ex);
            }
        }

    }
}



