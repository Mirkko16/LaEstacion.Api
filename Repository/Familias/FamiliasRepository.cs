using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Familias
{
    public class FamiliasRepository : IFamiliaRepository
    {
        private readonly ApplicationDbContext _context;

        public FamiliasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FamiliaModel> AddFamilia(FamiliaModel familia)
        {
            try
            {
                _context.Familias.Add(familia);
                await _context.SaveChangesAsync();
                return familia;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar familia", ex);
            }
        }


        public async Task<List<FamiliaModel>> GetAllFamilias()
        {
            try
            {
                var familias = await _context.Familias.ToListAsync();
                return familias;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todos las familias", ex);
            }
        }

        public async Task<FamiliaModel?> GetFamiliaById(int familiaId)
        {
            try
            {
                var familia = await _context.Familias.FirstOrDefaultAsync(familia => familia.Id == familiaId);
                return familia;
            }
            catch (Exception ex)
            {

                throw new Exception("Familia no encontrada", ex);
            }
        }

        public async Task RemoveFamilia(int familiaId)
        {
            try
            {
                var index = await GetFamiliaById(familiaId);
                _context.Familias.Remove(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la familia", ex);
            }
        }

        public async Task<FamiliaModel> UpdateFamilia(FamiliaModel familia, FamiliaModel existingFamilia)
        {
            try
            {

                existingFamilia.Nombre = familia.Nombre;
                existingFamilia.Eliminada = familia.Eliminada;

                await _context.SaveChangesAsync();
                return existingFamilia;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar la familia", ex);
            }
        }


    }
}
