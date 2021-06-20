using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelUse.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider) //Burayı program.cs e bağlayacağız
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                    //eğer burada hiç veri varsa bir şey dönmesin, çalıştırma
                }
                context.Books.AddRange(  //n tane veriyi Books a eklemek için AddRange kullanıyoruz, Books Book adında bir dizi alıyor7
            new Book
            {
                //Id = 1, 
                Title = "Lean Startup",
                GenreId = 1, // personal growth
                PageCount = 200,
                PublishDate = new DateTime(2001, 06, 12)
            },

            new Book
            {
                // Id = 2,
                Title = "Herland",
                GenreId = 2, // science fiction
                PageCount = 250,
                PublishDate = new DateTime(2010, 05, 23)
            },
            new Book
            {
                //Id = 3,
                Title = "Dune",
                GenreId = 2, // personal growth
                PageCount = 540,
                PublishDate = new DateTime(2001, 12, 21)
            }

                      );

                context.SaveChanges(); //commit ediyoruz gibi düşünebiliriz.

            }
        }
    }
}
