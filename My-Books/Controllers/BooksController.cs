using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Books.Data.Service;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;
        public BooksController(BooksService booksService )
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _booksService.GetBook(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBook(int id,[FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBook(id,book);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var _book = _booksService.GetBook(id);
            if (_book == null)
            {
                return NotFound();
            }
            else
            {
                _booksService.DeleteBook(id);
            }
            return Ok();
        }
    }
}
