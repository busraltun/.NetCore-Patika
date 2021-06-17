﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Lean Startup",
                GenreId = 1, // personal growth
                PageCount = 200,
                PublishDate = new DateTime(2001,06,12)
            },

            new Book
            {
                Id = 2,
                Title = "Herland",
                GenreId = 2, // science fiction
                PageCount = 250,
                PublishDate = new DateTime(2010,05,23)
            },
            new Book
            {
                Id = 3,
                Title = "Dune",
                GenreId = 2, // personal growth
                PageCount = 540,
                PublishDate = new DateTime(2001,12,21)
            },
        };

        //[HttpGet]
        //public List<Book> GetBooks()
        //{
        //    var bookList = BookList.OrderBy( x => x.Id).ToList<Book>();
        //    return bookList;
        //}

        [HttpGet("{id}") ]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        } //doğru olan yaklaşım budur ıd yle getirmek için, routtan getirmek yani

        [HttpGet]
        public Book Get([FromQuery] string id)
        {
            var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }
    }
}