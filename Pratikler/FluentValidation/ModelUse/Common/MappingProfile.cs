using AutoMapper;
using ModelUse.BookOperations.GetBookDetail;
using ModelUse.BookOperations.GetBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ModelUse.BookOperations.CreateBook.CreateBookCommand;

namespace ModelUse.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>(); //ilk parametre source, 2.parametre target
            //CreateBookModel objesi Book objesine map lenebilir olsun demiş olduk

            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
