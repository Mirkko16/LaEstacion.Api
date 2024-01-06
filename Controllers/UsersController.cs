using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Users;
using LaEstacion.DTO.Request.User;


namespace LaEstacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult> UsuarioLogIn([FromBody] UsuarioLogInRequest loginRequest)
        {
            try
            {
                var usuario = await _repository.UsuarioLogIn(loginRequest.Username, loginRequest.Password);

                if (usuario == null)
                {
                    // Usuario no encontrado o credenciales incorrectas
                    return StatusCode(StatusCodes.Status401Unauthorized, "Credenciales inválidas");
                }

                // Aquí puedes agregar lógica adicional después de iniciar sesión con éxito

                var response = _mapper.Map<UsuarioResponse>(usuario);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpGet]
        public async Task<ActionResult> GetAllUsuariosAsync()
        {
            try
            {
                var usuario = await _repository.GetAllUsuarios();

                var response = _mapper.Map<List<UsuarioResponse>>(usuario);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult> GetUsuariosByIdAsync(int usuarioId)
        {
            try
            {
                var usuario = await _repository.GetUsuarioById(usuarioId);

                if (usuario is null) return StatusCode(StatusCodes.Status404NotFound);

                var response = _mapper.Map<UsuarioResponse>(usuario);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddUsuarioAsync(UserRequest usuarioRequest)
        {
            try
            {
                var usuarioToAdd = _mapper.Map<UserModel>(usuarioRequest);

                await _repository.AddUsuario(usuarioToAdd);

                var response = _mapper.Map<UsuarioResponse>(usuarioToAdd);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{usuarioId}")]
        public async Task<ActionResult> DeleteUsuarioAsync(int usuarioId)
        {
            try
            {
                var usuarioToDelete = await _repository.GetUsuarioById(usuarioId);

                if (usuarioToDelete is null) return NotFound();

                await _repository.RemoveUsuario(usuarioId);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUsuarioAsync(UserUpdateRequest usuarioUpdate)
        {
            try
            {
                var existingUsuario = await _repository.GetUsuarioById(usuarioUpdate.Id);

                if (existingUsuario is null) return StatusCode(StatusCodes.Status404NotFound);

                var usuarioToUpdate = _mapper.Map<UserModel>(usuarioUpdate);

                await _repository.UpdateUsuario(usuarioToUpdate, existingUsuario);

                var response = _mapper.Map<UsuarioResponse>(usuarioToUpdate);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed at executing the request", ex);
            }
        }

    }
}



