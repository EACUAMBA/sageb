using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace sageb.Database.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public byte[]? CoverImage { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Quantity { get; set; }
        public int? PageQuantity { get; set; }
        public DateTime? PublishDate { get; set; }

        public List<BookOrder> BookOrders { get; set; } = new List<BookOrder>();

    }
}
