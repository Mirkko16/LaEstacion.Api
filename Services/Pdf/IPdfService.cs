using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Services.Pdf
{
    public interface IPdfService
    {
        byte[] GenerarPdf(List<ProductoModel> productos);
        object GenerarPdf(Task<List<ProductoModel>> productosBajoStock);
    }
}
