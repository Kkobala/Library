using Library.App.Models.Requests;
using Library.App.Services.Interface;
using Library.Domain.Models.Requests;
using Library.Infrastructure.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService,
            IMediator mediator)
        {
            _authorService = authorService;
            _mediator = mediator;
        }

        //[HttpPost("Add-author")]
        //public async Task<IActionResult> AddAuthor(AddAuthorRequest request)
        //{
        //    var author = await _authorService.AddAuthorAsync(request);

        //    return Ok(author);
        //}


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

        //[HttpDelete("delete-author")]
        //public async Task<IActionResult> DeleteAuthor(RemoveAuthorRequest request)
        //{
        //    await _authorService.DeleteAuthorAsync(request);

        //    return Ok();
        //}
    }
}
