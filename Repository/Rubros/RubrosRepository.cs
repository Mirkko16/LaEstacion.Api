using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Rubros
{
    public class RuborosRepository : IRubroRepository
    {
        private readonly ApplicationDbContext _context;

        public RuborosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RubroModel> AddRubro(RubroModel rubro)
        {
            try
            {
                _context.Rubros.Add(rubro);
                await _context.SaveChangesAsync();
                return rubro;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar rubro", ex);
            }
        }


        public async Task<List<RubroModel>> GetAllRubros()
        {
            try
            {
                var rubros = await _context.Rubros.ToListAsync();
                return rubros;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todos los rubros", ex);
            }
        }

        public async Task<RubroModel?> GetRubroById(int rubroId)
        {
            try
            {
                var rubro = await _context.Rubros.FirstOrDefaultAsync(rubro => rubro.Id == rubroId);
                return rubro;
            }
            catch (Exception ex)
            {

                throw new Exception("Familia no encontrada", ex);
            }
        }

        public async Task RemoveRubro(int rubroId)
        {
            try
            {
                var index = await GetRubroById(rubroId);
                _context.Rubros.Remove(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rubro", ex);
            }
        }

        public async Task<RubroModel> UpdateRubro(RubroModel rubro, RubroModel existingRubro)
        {
            try
            {

                existingRubro.Nombre = rubro.Nombre;
                existingRubro.Eliminado = rubro.Eliminado;

                await _context.SaveChangesAsync();
                return existingRubro;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar el rubro", ex);
            }
        }


    }
}
