using AutoMapper;
using DBAccessLibrary.Storage;
using WebApiServer.Models;

namespace WebApiServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<APIMessage, DBAMessage>();

        }
    }
}
