using System.Collections.Generic;
using System.Reflection.Metadata;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using LaEstacion.Persistence.Common.Model;
using Document = iText.Layout.Document;

namespace LaEstacion.Services.Pdf
{
    public class PdfService : IPdfService
    {
        public byte[] GenerarPdf(List<ProductoModel> productos)
        {
            using (var memoryStream = new System.IO.MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                document.Add(new Paragraph("Lista de Productos Bajo Stock Mínimo"));

                foreach (var producto in productos)
                {
                    document.Add(new Paragraph($"Nombre: {producto.Nombre}, Stock: {producto.Stock}"));
                }

                document.Close();

                return memoryStream.ToArray();
            }
        }
    }
}
