using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace sageb.Database.Entities.Identity;

public class UserClaim:IdentityUserClaim<string>
{
    [Key]
    public string? Id { get; set; }

    public UserClaim()
    {
        this.Id = Guid.NewGuid().ToString();
    }
}