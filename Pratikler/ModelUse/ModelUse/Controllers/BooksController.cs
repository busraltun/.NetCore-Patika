using ModelUse.DBOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelUse.BookOperations.GetBooks;
using ModelUse.BookOperations.CreateBook;
using static ModelUse.BookOperations.CreateBook.CreateBookCommand;
using ModelUse.BookOperations.GetBookDetail;
using ModelUse.BookOperations.UpdateBook;
using static ModelUse.BookOperations.UpdateBook.UpdateBookCommand;
using ModelUse.BookOperations.DeleteBook;

namespace ModelUse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context; //readonly yaptık ki uygulama içerisinden değiştirilemesin, readonly değişkenler sadece constructor içerisinde set edilebilirler

        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {            
               GetBookDetailQuery query = new GetBookDetailQuery(_context);
               query.BookId = id;
               result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
        } //doğru olan yaklaşım budur ıd yle getirmek için, routtan getirmek yani

        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}

        // POST
        [HttpPost]

        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           

            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook) 
        {

            try
            {
              UpdateBookCommand command = new UpdateBookCommand(_context);
              command.BookId = id;
              command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
 
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
