using AutoMapper;
using LaEstacion.Data;
using LaEstacion.DTO.Request.Producto;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Familias;
using LaEstacion.Repository.Marcas;
using LaEstacion.Repository.Proveedores;
using LaEstacion.Repository.Rubros;
using LaEstacion.Repository.Unidades;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Productos
{
    public class ProductosRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMarcaRepository _marcasRepository;
        private readonly IFamiliaRepository _familiasRepository;
        private readonly IRubroRepository _rubrosRepository;
        private readonly IProveedorRepository _proveedoresRepository;
        private readonly IUnidadRepository _unidadesRepository;

        public ProductosRepository(ApplicationDbContext context, IMapper mapper, IMarcaRepository marcasRepository, 
            IFamiliaRepository familiasRepository, IRubroRepository rubrosRepository, 
            IProveedorRepository proveedoresRepository, IUnidadRepository unidadesRepository)
        {
            _context = context;
            _mapper = mapper;
            _marcasRepository = marcasRepository;
            _familiasRepository = familiasRepository;
            _rubrosRepository = rubrosRepository;
            _proveedoresRepository = proveedoresRepository;
            _unidadesRepository = unidadesRepository;
        }


        public async Task<ProductoModel> AddProducto(ProductoRequest productoRequest)
        {
            try
            {
                var productoToAdd = _mapper.Map<ProductoModel>(productoRequest);

                if (productoRequest.Marca.Id != 0)
                {
                    var marca = await _marcasRepository.GetMarcaById(productoRequest.Marca.Id);
                    if (marca != null)
                    {
                        productoToAdd.Marca = marca;
                    }
                }
                if (productoRequest.Familia.Id != 0)
                {
                    var familia = await _familiasRepository.GetFamiliaById(productoRequest.Familia.Id);
                    if (familia != null)
                    {
                        productoToAdd.Familia = familia;
                    }
                }
                if (productoRequest.Rubro.Id > 0)
                {
                    var rubro = await _rubrosRepository.GetRubroById(productoRequest.Rubro.Id);
                    if (rubro != null)
                    {
                        productoToAdd.Rubro = rubro;
                    }
                }
                if (productoRequest.Proveedor.Id > 0)
                {
                    var proveedor = await _proveedoresRepository.GetProveedorById(productoRequest.Proveedor.Id);
                    if (proveedor != null)
                    {
                        productoToAdd.Proveedor = proveedor;
                    }
                }
                if (productoRequest.Unidad.Id > 0)
                {
                    var unidad = await _unidadesRepository.GetUnidadById(productoRequest.Unidad.Id);
                    if (unidad  != null)
                    {
                        productoToAdd.Unidad = unidad;
                    }
                }
                if (productoRequest.Rentabilidad != 0) 
                {
                    productoToAdd.PrecioVenta = ((productoToAdd.Costo * productoToAdd.Rentabilidad) / 100) + (productoToAdd.Costo);
                }

                _context.Productos.Add(productoToAdd);
                await _context.SaveChangesAsync();
                
                return productoToAdd;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar producto", ex);
            }
        }


        public async Task<List<ProductoModel>> GetAllProductos()
        {
            try
            {
                var productos = await _context.Productos
                    .Include(x => x.Marca)
                    .Include(x => x.Familia)
                    .Include(x => x.Rubro)
                    .Include(x => x.Proveedor)
                    .ToListAsync();
                return productos;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todos los Productos", ex);
            }
        }

        public async Task<ProductoModel?> GetProductoById(int productoId)
        {
            try
            {
                var producto = await _context.Productos.FirstOrDefaultAsync(producto => producto.Id == productoId);
                return producto;
            }
            catch (Exception ex)
            {

                throw new Exception("Producto no encontrado", ex);
            }
        }

        public async Task RemoveProducto(int productoId)
        {
            try
            {
                var index = await GetProductoById(productoId);
                _context.Productos.Remove(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Producto", ex);
            }
        }

        public async Task<ProductoModel> UpdateProducto(ProductoUpdateRequest productoUpdate, ProductoModel productoToUpdate)
        {
            try
            {
                if (productoUpdate.Marca.Id > 0)
                {
                    var marca = await _marcasRepository.GetMarcaById(productoUpdate.Marca.Id);
                    if (marca != null)
                    {
                        productoToUpdate.Marca = marca;
                    }
                }
                if (productoUpdate.Familia.Id > 0)
                {
                    var familia = await _familiasRepository.GetFamiliaById(productoUpdate.Familia.Id);
                    if (familia != null)
                    {
                        productoToUpdate.Familia = familia;
                    }
                }
                if (productoUpdate.Rubro.Id > 0)
                {
                    var rubro = await _rubrosRepository.GetRubroById(productoUpdate.Rubro.Id);
                    if (rubro != null)
                    {
                        productoToUpdate.Rubro = rubro;
                    }
                }
                if (productoUpdate.Proveedor.Id > 0)
                {
                    var proveedor = await _proveedoresRepository.GetProveedorById(productoUpdate.Proveedor.Id);
                    if (proveedor != null)
                    {
                        productoToUpdate.Proveedor = proveedor;
                    }
                }

                productoToUpdate.Nombre = productoUpdate.Nombre;
                productoToUpdate.CodBarra = productoUpdate.CodBarra;                
                productoToUpdate.Costo = productoUpdate.Costo;
                productoToUpdate.Rentabilidad = productoUpdate.Rentabilidad;
                productoToUpdate.PrecioVenta = ((productoUpdate.Costo * productoUpdate.Rentabilidad) / 100) + (productoToUpdate.Costo);
                productoToUpdate.Stock = productoUpdate.Stock;
                productoToUpdate.Eliminado = productoUpdate.Eliminado;
                

                await _context.SaveChangesAsync();
                return productoToUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar el producto", ex);
            }
        }
    }
}
