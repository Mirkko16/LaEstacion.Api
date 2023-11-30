using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Clientes;
using LaEstacion.DTO.Request.Cliente;

namespace LaEstacion.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class ClientesController : ControllerBase
        {
            private readonly IClienteRepository _repository;
            private readonly IMapper _mapper;

            public ClientesController(IClienteRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }


            [HttpGet]
            public async Task<ActionResult> GetAllClientesAsync()
            {
                try
                {
                    var cliente = await _repository.GetAllClientes();

                    var response = _mapper.Map<List<ClienteResponse>>(cliente);

                    return StatusCode(StatusCodes.Status200OK, response);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }
            }

            [HttpGet("{clienteId}")]
            public async Task<ActionResult> GetClientesByIdAsync(int clienteId)
            {
                try
                {
                    var cliente = await _repository.GetClienteById(clienteId);

                    if (cliente is null) return StatusCode(StatusCodes.Status404NotFound);

                    var response = _mapper.Map<ClienteResponse>(cliente);

                    return StatusCode(StatusCodes.Status200OK, response);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }
            }


            [HttpPost]
            public async Task<ActionResult> AddClienteAsync(ClienteRequest clienteRequest)
            {
                try
                {
                    var clienteToAdd = _mapper.Map<ClienteModel>(clienteRequest);                    

                    var response = _mapper.Map<ClienteResponse>(await _repository.AddCliente(clienteToAdd));

                    return StatusCode(StatusCodes.Status201Created, response);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }
            }

            [HttpDelete("{clienteId}")]
            public async Task<ActionResult> DeleteClienteAsync(int clienteId)
            {
                try
                {
                    var clienteToDelete = await _repository.GetClienteById(clienteId);

                    if (clienteToDelete is null) return NotFound();

                    await _repository.RemoveCliente(clienteId);

                    return StatusCode(StatusCodes.Status200OK);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }
            }

            [HttpPut]
            public async Task<ActionResult> UpdateClienteAsync(ClienteUpdateRequest clienteUpdate)
            {
                try
                {
                    var existingCliente = await _repository.GetClienteById(clienteUpdate.Id);
                    if (existingCliente is null) return StatusCode(StatusCodes.Status404NotFound);
                    var clienteToUpdate = _mapper.Map<ClienteModel>(clienteUpdate);                    

                    var response = _mapper.Map<ClienteResponse>(await _repository.UpdateCliente(clienteToUpdate, existingCliente));

                    return StatusCode(StatusCodes.Status200OK, response);
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed at executing the request", ex);
                }
            }
            
        }
} 



