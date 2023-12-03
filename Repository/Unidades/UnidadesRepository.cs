using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Unidades
{
    public class UnidadesRepository : IUnidadRepository
    {
        private readonly ApplicationDbContext _context;

        public UnidadesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UnidadModel> AddUnidad(UnidadModel unidad)
        {
            try
            {
                _context.Unidades.Add(unidad);
                await _context.SaveChangesAsync();
                return unidad;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar unidad", ex);
            }
        }


        public async Task<List<UnidadModel>> GetAllUnidades()
        {
            try
            {
                var unidades = await _context.Unidades.ToListAsync();
                return unidades;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todos las Unidades", ex);
            }
        }

        public async Task<UnidadModel?> GetUnidadById(int unidadId)
        {
            try
            {
                var unidad = await _context.Unidades.FirstOrDefaultAsync(unidad => unidad.Id == unidadId);
                return unidad;
            }
            catch (Exception ex)
            {

                throw new Exception("Unidad no encontrada", ex);
            }
        }

        public async Task RemoveUnidad(int unidadId)
        {
            try
            {
                var index = await GetUnidadById(unidadId);
                _context.Unidades.Remove(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la unidad", ex);
            }
        }

        public async Task<UnidadModel> UpdateUnidad(UnidadModel unidad, UnidadModel existingUnidad)
        {
            try
            {

                existingUnidad.Unidad = unidad.Unidad;
                existingUnidad.Eliminada = unidad.Eliminada;

                await _context.SaveChangesAsync();
                return existingUnidad;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar la Unidad", ex);
            }
        }


    }
}
