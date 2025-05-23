using AutoMapper;
using ShortLink.Communication.Request;
using ShortLink.Domain.Entities;

namespace ShortLink.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
        }

        public void RequestToEntity()
        {
            CreateMap<RequestShortLinkCreateJson,Link>();
        }
    }
}
