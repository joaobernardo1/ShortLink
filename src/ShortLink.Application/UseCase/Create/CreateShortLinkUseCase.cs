using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShortLink.Application.ShorterLink;
using ShortLink.Communication.Request;
using ShortLink.Communication.Response;
using ShortLink.Domain.Entities;
using ShortLink.Domain.Repository;
using ShortLink.Domain.Repository.ShortLink;

namespace ShortLink.Application.UseCase.Create
{
    public class CreateShortLinkUseCase : ICreateShortLinkUseCase
    {
        private readonly IShortLinkWriteOnly _repository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateShortLinkUseCase(
            IShortLinkWriteOnly repository,
            IUnityOfWork unityOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseShortLinkCreateJson> Execute(RequestShortLinkCreateJson request)
        {
            var entity = _mapper.Map<Link>(request);
            await _repository.Add(entity);
            entity.ShortLink = EncoderLink.Encode(entity.LongLink);
            await _unityOfWork.Commit();
            var requestScheme = _httpContextAccessor.HttpContext.Request.Scheme;
            var requestHost = _httpContextAccessor.HttpContext.Request.Host;    
            var shortUrl = $"{requestScheme}://{requestHost}/{entity.ShortLink}";
            var response = new ResponseShortLinkCreateJson
            {
                ShortLink = shortUrl
            };
            return response;
        }
    }
}
