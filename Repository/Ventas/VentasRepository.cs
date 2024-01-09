using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Clientes;
using LaEstacion.Repository.Productos;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Ventas
{
    public class VentasRepository : IVentaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductoVendidoRepository _productsVendidosRepository;
        private readonly IClienteRepository _clienteRepository;

        public VentasRepository(ApplicationDbContext context, IProductoVendidoRepository productsVendidosRepository, IClienteRepository clienteRepository)
        {
            _context = context;
            _productsVendidosRepository = productsVendidosRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<VentaModel> AddVenta(VentaModel venta)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                await AddProductosToVenta(venta);
                await SetClienteToVenta(venta);


                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                transaction.Commit();

                return venta;
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                ///Añadido logeo de error al intentar realizar la venta
                Console.WriteLine("Fallo al insertar venta", ex.Message);
                
                throw new Exception("Fallo al insertar venta", ex);
            }
        }

        private async Task SetClienteToVenta(VentaModel venta)
        {
            if(venta.Cliente.Id is 0)
            {
                throw new Exception("Cliente no puede ser nulo");
            }
            var clienteFromDb = await _clienteRepository.GetClienteById(venta.Cliente.Id);
            venta.Cliente = clienteFromDb;

        }
        private async Task AddProductosToVenta(VentaModel venta)
        {
            if (venta.Productos is null)
            {
                throw new Exception($"No hay productos seleccionados");
            }

            foreach (var producto in venta.Productos.ToList())
            {
                producto.VentaId = venta.Id;
                    
                var productoEnBaseDeDatos = _context.Productos.Find(producto.Producto.Id);
                if (productoEnBaseDeDatos == null)
                {
                    throw new Exception($"El producto con ID {producto.Id} no existe");
                }

                if (productoEnBaseDeDatos.Stock >= producto.Cantidad)
                {
                    productoEnBaseDeDatos.Stock -= producto.Cantidad;
                    var productoVendido = new ProductoVendidoModel
                    {
                        Producto = productoEnBaseDeDatos,
                        Cantidad = producto.Cantidad,
                        PrecioUnitario = producto.PrecioUnitario
                    };
                    ///Esto está mal, ya que duplica los items 
                    //venta.Productos.Add(productoVendido);
                    
                    await _productsVendidosRepository.AddProductoVendido(productoVendido);
                    ///Reemplazo el producto, por el añadido a la base de datos
                    venta.Productos[venta.Productos.IndexOf(producto)]= productoVendido;
                }
                else
                {
                    throw new Exception($"No hay suficiente stock para el producto con ID {producto.Id}.");
                }                 
            }
        }




        public async Task<List<VentaModel>> GetAllVentas()
        {
            try
            {
                var ventas = await _context.Ventas
                    .Include(v => v.Cliente)
                    .Include(v => v.Productos)
                    .ToListAsync();
                return ventas;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todas las ventas", ex);
            }
        }

        public async Task<VentaModel?> GetVentaById(int ventaId)
        {
            try
            {
                var venta = await _context.Ventas.FirstOrDefaultAsync(venta => venta.Id == ventaId);
                return venta;
            }
            catch (Exception ex)
            {

                throw new Exception("Venta no encontrada", ex);
            }
        }

    }
}
