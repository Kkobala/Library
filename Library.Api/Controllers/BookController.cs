using Library.App.Models.Requests;
using Library.App.Services.Interface;
using Library.Domain.Models.Requests;
using Library.Infrastructure.Command;
using Library.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookService _bookService;

        public BookController(IBookService bookService,
            IMediator mediator)
        {
            _bookService = bookService;
            _mediator = mediator;
        }

        //[HttpPost("Add-Book")]
        //public async Task<IActionResult> AddBook(AddBookRequest request)
        //{
        //    var book = await _bookService.AddBookAsync(request);

        //    return Ok(book);
        //}

        [HttpPost("Add-Book")]
        public async Task<IActionResult> AddBook(AddBookRequest request)
        {
            var result = await _mediator.Send(new AddBookCommand(request.Title, request.Description, request.AuthorId));

            return Ok(result);
        }

        //[HttpPut("update-book-with-title-and-description")]
        //public async Task<IActionResult> UpdateBook(UpdateBookRequest request)
        //{
        //    var book = await _bookService.UpdateBookAsync(request);

        //    return Ok(book);
        //}

        [HttpPut("update-book-with-title-and-description")]
        public async Task<IActionResult> UpdateBook(UpdateBookRequest request)
        {
            var result = await _mediator.Send(new UpdateBookCommand(request.Title, request.Description));

            return Ok(result);
        }

        [HttpGet("get-books")]
        public async Task<IActionResult> GetBooks([FromQuery]GetBooksRequest request)
        {
            var result = await _mediator.Send(new GetBookQuery());

            return Ok(result);
        }
        
        //[HttpGet("get-books")]
        //public async Task<IActionResult> GetBooks([FromQuery]GetBooksRequest request)
        //{
        //    var book = await _bookService.GetBooksAsync(request);

        //    return Ok(book);
        //}

        //[HttpGet("get-books-by-author")]
        //public async Task<IActionResult> GetBooksByAuthor([FromQuery]GetBookByAuthorRequest request)
        //{
        //    var book = await _bookService.GetBooksByAuthorAsync(request);

        //    return Ok(book);
        //}

        [HttpGet("get-books-by-author")]
        public async Task<IActionResult> GetBooksByAuthor([FromQuery] GetBookByAuthorRequest request)
        {
            var result = await _mediator.Send(new GetBooksByAuthorQuery(request.AuthorName, request.AuthorLastName));

            return Ok(result);
        }


        //[HttpDelete("delete-book")]
        //public async Task<IActionResult> DeleteBook(RemoveBookRequest request)
        //{
        //    await _bookService.RemoveBookAsync(request);

        //    return Ok();
        //}

        [HttpDelete("delete-book")]
        public async Task<IActionResult> DeleteBook(RemoveBookRequest request)
        {
            await _mediator.Send(new RemoveBookCommand(request.Title));

            return Ok();
        }
    }
}
