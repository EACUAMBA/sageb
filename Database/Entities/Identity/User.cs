using Microsoft.AspNetCore.Identity;

namespace sageb.Database.Entities.Identity
{
    public class User : IdentityUser
    {
        public List<BookOrder> BookOrders { get; set; } = new List<BookOrder>();
    }
}
