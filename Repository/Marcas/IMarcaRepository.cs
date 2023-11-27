using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Marcas
{
    public interface IMarcaRepository
    {
        Task<List<MarcaModel>> GetAllMarcas();
        Task<MarcaModel?> GetMarcaById(int marcaId);
        Task<MarcaModel> AddMarca(MarcaModel marca);
        Task<MarcaModel> UpdateMarca(MarcaModel marca, MarcaModel existingMarca);
        Task RemoveMarca(int marcaId);
    }
}
