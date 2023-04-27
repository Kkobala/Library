﻿using Library.App.Models.Requests;
using Library.App.Services.Interface;
using Library.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("Add-Book")]
        public async Task<IActionResult> AddBook(AddBookRequest request)
        {
            var book = await _bookService.AddBookAsync(request);

            return Ok(book);
        }

        [HttpPut("update-book-with-title-and-description")]
        public async Task<IActionResult> UpdateBook(UpdateBookRequest request)
        {
            var book = await _bookService.UpdateBookAsync(request);

            return Ok(book);
        }

        [HttpGet("get-books")]
        public async Task<IActionResult> GetBooks([FromQuery]GetBooksRequest request)
        {
            var book = await _bookService.GetBooksAsync(request);

            return Ok(book);
        }

        [HttpGet("get-books-by-author")]
        public async Task<IActionResult> GetBooksByAuthor([FromQuery]GetBookByAuthorRequest request)
        {
            var book = await _bookService.GetBooksByAuthorAsync(request);

            return Ok(book);
        }

        [HttpPut("delete-book")]
        public async Task<IActionResult> DeleteBook(RemoveBookRequest request)
        {
            await _bookService.RemoveBookAsync(request);

            return Ok();
        }
    }
}