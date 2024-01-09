using AutoMapper;
using LaEstacion.DTO.Request.Cliente;
using LaEstacion.DTO.Request.Familia;
using LaEstacion.DTO.Request.Marca;
using LaEstacion.DTO.Request.Producto;
using LaEstacion.DTO.Request.Proveedor;
using LaEstacion.DTO.Request.Rubro;
using LaEstacion.DTO.Request.Unidad;
using LaEstacion.DTO.Request.Venta;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.AutoMapper
{
    public class CustomProfile :Profile
    {
        public CustomProfile() 
        {
            //Clientes
            CreateMap<ClienteModel, ClienteResponse>().ReverseMap();
            CreateMap<ClienteModel, ClienteUpdateRequest>().ReverseMap();
            CreateMap<ClienteModel, ClienteRequest>().ReverseMap();

            //Proveedores
            CreateMap<ProveedorModel, ProveedorResponse>().ReverseMap();
            CreateMap<ProveedorModel, ProveedorUpdateRequest>().ReverseMap();
            CreateMap<ProveedorModel, ProveedorRequest>().ReverseMap();

            //Productos
            CreateMap<ProductoModel, ProductoResponse>().ReverseMap();
            CreateMap<ProductoModel, ProductoUpdateRequest>().ReverseMap();
            CreateMap<ProductoModel, ProductoRequest>().ReverseMap();
            CreateMap<ProductoModel, ProductoVendidoRequest>().ReverseMap();

            //Marcas
            CreateMap<MarcaModel, MarcaResponse>().ReverseMap();
            CreateMap<MarcaModel, MarcaUpdateRequest>().ReverseMap();
            CreateMap<MarcaModel, MarcaRequest>().ReverseMap();

            //Familias
            CreateMap<FamiliaModel, FamiliaResponse>().ReverseMap();
            CreateMap<FamiliaModel, FamiliaUpdateRequest>().ReverseMap();
            CreateMap<FamiliaModel, FamiliaRequest>().ReverseMap();
            
            //Rubros
            CreateMap<RubroModel, RubroResponse>().ReverseMap();
            CreateMap<RubroModel, RubroUpdateRequest>().ReverseMap();
            CreateMap<RubroModel, RubroRequest>().ReverseMap();

            //Unidades
            CreateMap<UnidadModel, UnidadResponse>().ReverseMap();
            CreateMap<UnidadModel, UnidadUpdateRequest>().ReverseMap();
            CreateMap<UnidadModel, UnidadRequest>().ReverseMap();

            // ProductosVendidos
            CreateMap<ProductoVendidoModel, ProductoVendidoResponse>().ReverseMap();
            CreateMap<ProductoVendidoModel, ProductoVendidoUpdateRequest>().ReverseMap();
            CreateMap<ProductoVendidoModel, ProductoVendidoRequest>()
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.Producto.Id)).ReverseMap();


            // Ventas
            CreateMap<VentaModel, VentaResponse>().ReverseMap();
            CreateMap<VentaModel, VentaUpdateRequest>().ReverseMap();
            CreateMap<VentaModel, VentaRequest>()
                .ForMember(dest => dest.Productos, 
                           src => src.MapFrom(d => d.Productos))
                .ReverseMap();

        }
    }
}
