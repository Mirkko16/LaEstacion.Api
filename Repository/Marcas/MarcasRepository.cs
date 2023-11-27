using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Marcas
{
    public class MarcasRepository : IMarcaRepository
    {
        private readonly ApplicationDbContext _context;

        public MarcasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MarcaModel> AddMarca(MarcaModel marca)
        {
            try
            {
                _context.Marcas.Add(marca);
                await _context.SaveChangesAsync();
                return marca;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar marca", ex);
            }
        }


        public async Task<List<MarcaModel>> GetAllMarcas()
        {
            try
            {
                var marcas = await _context.Marcas.ToListAsync();
                return marcas;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todos las marcas", ex);
            }
        }

        public async Task<MarcaModel?> GetMarcaById(int marcaId)
        {
            try
            {
                var marca = await _context.Marcas.FirstOrDefaultAsync(marca => marca.Id == marcaId);
                return marca;
            }
            catch (Exception ex)
            {

                throw new Exception("Marca no encontrado", ex);
            }
        }

        public async Task RemoveMarca(int marcaId)
        {
            try
            {
                var index = await GetMarcaById(marcaId);
                _context.Marcas.Remove(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la marca", ex);
            }
        }

        public async Task<MarcaModel> UpdateMarca(MarcaModel marca, MarcaModel existingMarca)
        {
            try
            {

                existingMarca.Nombre = marca.Nombre;
                existingMarca.Eliminada = marca.Eliminada;
                
                await _context.SaveChangesAsync();
                return existingMarca;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar la marca", ex);
            }
        }


    }
}
