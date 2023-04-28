using Library.App.Services.Interface;
using Library.Domain.Models.Requests;
using Library.Infrastructure.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-author")]
        public async Task<IActionResult> AddAuthor(AddAuthorRequest request)
        {
            var result = await _mediator.Send(new AddAuthorCommand(request.Name, request.LastName));

            return Ok(result);
        }

        [HttpDelete("delete-author")]
        public async Task<IActionResult> DeleteAuthor(RemoveAuthorRequest request)
        {
            await _mediator.Send(new RemoveAuthorCommand(request.Name, request.LastName));

            return Ok();
        }
    }
}
