using AutoMapper;
using LaEstacion.DTO.Response;
using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.AutoMapper
{
    public class CustomProfile :Profile
    {
        public CustomProfile() 
        {
            CreateMap<ClienteModel, ClienteResponse>().ReverseMap(); 
        }
    }
}
