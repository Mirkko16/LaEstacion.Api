using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Users;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Usuarios
{
    public class UsuariosRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuariosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> AddUsuario(UserModel usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar unidad", ex);
            }
        }


        public async Task<List<UserModel>> GetAllUsuarios()
        {
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();
                return usuarios;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todos los usuarios", ex);
            }
        }

        public async Task<UserModel?> GetUsuarioById(int usuarioId)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == usuarioId);
                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception("Usuario no encontrado", ex);
            }
        }

        public async Task RemoveUsuario(int usuarioId)
        {
            try
            {
                var index = await GetUsuarioById(usuarioId);
                _context.Usuarios.Remove(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario", ex);
            }
        }

        public async Task<UserModel> UpdateUsuario(UserModel usuario, UserModel existingUsuario)
        {
            try
            {

                existingUsuario.Password = usuario.Password;
                existingUsuario.Rol = usuario.Rol;

                await _context.SaveChangesAsync();
                return existingUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar el usuario", ex);
            }
        }

        public async Task<UserModel?> UsuarioLogIn(string userlogin, string password)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == userlogin && u.Password == password);
                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al iniciar sesion...");
            }
        }
    }
}
