using AutoMapper;
using LaEstacion.DTO.Request;
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
        }
    }
}
