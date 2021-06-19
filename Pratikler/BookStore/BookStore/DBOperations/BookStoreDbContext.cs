using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DBOperations
{
    public class BookStoreDbContext : DbContext
    {

        public BookStoreDbContext (DbContextOptions<BookStoreDbContext>options) : base (options)
        {
           
        }

        public DbSet<Book>Books
        {
            get;
            set;
        } //Bu şekilde Books context ine Book entity sini eklemiş olduk ve Books ile Book entitysine ait her şeye erişebiliriz, ınmemory

        //
    }
}
