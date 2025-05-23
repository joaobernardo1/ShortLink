using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.UseCase.Create;
using ShortLink.Application.UseCase.Redirect;
using ShortLink.Communication.Request;
using ShortLink.Communication.Response;

namespace ShortLink.API.Controllers
{
    [ApiController]

    public class ShortLink : ControllerBase
    {
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseShortLinkCreateJson),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ShortLinkCreate(
            [FromServices]ICreateShortLinkUseCase useCase,
            [FromBody]RequestShortLinkCreateJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet("{shortLink}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Redirect(    
        [FromRoute] string shortLink,
        [FromServices] IRedirectUseCase useCase)
        {
            var url = await useCase.Execute(shortLink);
            return Redirect(url!);
        }
    }
}
