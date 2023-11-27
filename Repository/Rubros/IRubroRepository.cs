using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Rubros
{
    public interface IRubroRepository
    {
        Task<List<RubroModel>> GetAllRubros();
        Task<RubroModel?> GetRubroById(int rubroId);
        Task<RubroModel> AddRubro(RubroModel rubro);
        Task<RubroModel> UpdateRubro(RubroModel rubro, RubroModel existingRubro);
        Task RemoveRubro(int rubroId);
    }
}
