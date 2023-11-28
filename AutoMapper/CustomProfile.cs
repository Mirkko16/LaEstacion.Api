using AutoMapper;
using LaEstacion.DTO.Request.Cliente;
using LaEstacion.DTO.Request.Familia;
using LaEstacion.DTO.Request.Marca;
using LaEstacion.DTO.Request.Producto;
using LaEstacion.DTO.Request.Proveedor;
using LaEstacion.DTO.Request.Rubro;
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
        }
    }
}
