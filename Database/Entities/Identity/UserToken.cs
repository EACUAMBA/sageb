using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace sageb.Database.Entities.Identity;

public class UserToken : IdentityUserToken<string>
{
    [Key]
    public string? Id { get; set; }

    public UserToken()
    {
        this.Id = Guid.NewGuid().ToString();
    }
}