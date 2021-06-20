using AutoMapper;
using ModelUse.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelUse.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title); //newBook = Model
            if (book is not null) // if (book != null ) şeklinde de yazılabilirdi.
                throw new InvalidOperationException("Kitap zaten mevcut");

            book = _mapper.Map<Book>(Model); //Model ile gelen veriyi Book objesine maple convert et
            //new Book();
            //book.Title = Model.Title;
            //book.PublishDate = Model.PublishDate;
            //book.PageCount = Model.PageCount;♥
            //book.GenreId = Model.GenreId;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
