using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Unidades
{
    public interface IUnidadRepository
    {
        Task<List<UnidadModel>> GetAllUnidades();
        Task<UnidadModel?> GetUnidadById(int unidadId);
        Task<UnidadModel> AddUnidad(UnidadModel unidad);
        Task<UnidadModel> UpdateUnidad(UnidadModel unidad, UnidadModel existingUnidad);
        Task RemoveUnidad(int unidadId);
    }
}
