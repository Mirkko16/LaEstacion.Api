using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Familias
{
    public interface IFamiliaRepository
    {
        Task<List<FamiliaModel>> GetAllFamilias();
        Task<FamiliaModel?> GetFamiliaById(int familiaId);
        Task<FamiliaModel> AddFamilia(FamiliaModel familia);
        Task<FamiliaModel> UpdateFamilia(FamiliaModel familia, FamiliaModel existingFamilia);
        Task RemoveFamilia(int familiaId);
    }
}
