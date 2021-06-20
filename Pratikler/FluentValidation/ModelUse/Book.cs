using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelUse
{
    public class Book
    {
        //Auto increment, tabloya yeni bir kayıt eklendiğinde benzersiz bir sayının otomatik olarak oluşturulmasına izin verir. 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }


    }
}
