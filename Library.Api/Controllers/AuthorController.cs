using Library.App.Services.Interface;
using Library.Domain.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("Add-author")]
        public async Task<IActionResult> AddAuthor(AddAuthorRequest request)
        {
            var author = await _authorService.AddAuthorAsync(request);

            return Ok(author);
        }

        [HttpPut("delete-author")]
        public async Task<IActionResult> DeleteAuthor(RemoveAuthorRequest request)
        {
            await _authorService.DeleteAuthorAsync(request);

            return Ok();
        }
    }
}
