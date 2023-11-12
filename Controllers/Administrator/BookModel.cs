using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sageb.Controllers.Administrator
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        [NotNull]
        public string? Title { get; set; }
        [Required]
        [NotNull]
        public string? Author { get; set; }
        public int? Quantity { get; set; }
        public int? PageQuantity { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
