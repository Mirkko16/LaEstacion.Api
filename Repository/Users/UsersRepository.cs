using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Users;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace LaEstacion.Repository.Usuarios
{
    public class UsersRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> AddUsuario(UserModel usuario)
        {
            try
            {
                // Genera el hash de la contraseña antes de almacenarla en la base de datos
                usuario.PasswordHash = GenerarPasswordHash(usuario.Password);

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar usuario", ex);
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
                existingUsuario.Nombre = usuario.Nombre;
                existingUsuario.Apellido = usuario.Apellido;
                existingUsuario.Username = usuario.Username;
                existingUsuario.Password = usuario.Password;
                existingUsuario.PasswordHash = usuario.PasswordHash;
                existingUsuario.Correo = usuario.Correo;
                existingUsuario.Rol = usuario.Rol;
                existingUsuario.Activo = usuario.Activo;

                await _context.SaveChangesAsync();
                return existingUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar el usuario", ex);
            }
        }

        public async Task<UserModel?> UsuarioLogIn(string username, string password)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);

                // Verifica si el usuario existe y compara el hash de la contraseña
                if (usuario != null && VerificarPasswordHash(password, usuario.PasswordHash))
                {
                    return usuario;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al iniciar sesión...", ex);
            }
        }

        // Agrega un método para generar el hash de la contraseña
        private string GenerarPasswordHash(string password)
        {
            try
            {
                // Utiliza BCrypt.Net para generar el hash de la contraseña
                return BCryptNet.HashPassword(password);
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la generación del hash
                Console.WriteLine($"Error al generar el hash de la contraseña: {ex.Message}");
                throw;
            }
        }

        private bool VerificarPasswordHash(string password, string storedHash)
        {
            try
            {
                // Compara el hash almacenado con el hash de la contraseña proporcionada
                return BCryptNet.Verify(password, storedHash);
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la verificación
                Console.WriteLine($"Error al verificar el hash de la contraseña: {ex.Message}");
                return false;
            }
        }
    }
}
