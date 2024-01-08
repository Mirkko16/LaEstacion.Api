using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Users
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsuarios();
        Task<UserModel?> GetUsuarioById(int usuarioId);
        Task<UserModel> AddUsuario(UserModel usuario);
        Task<UserModel> UpdateUsuario(UserModel usuario, UserModel existingUsuario);
        Task RemoveUsuario(int usuarioId);
        Task<UserModel?> UsuarioLogIn(string username, string password);

    }
}
