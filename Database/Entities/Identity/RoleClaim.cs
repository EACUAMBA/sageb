using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace sageb.Database.Entities.Identity;

public class RoleClaim:IdentityRoleClaim<string>
{
    [Key]
    public string? Id { get; set; }

    public RoleClaim()
    {
        this.Id = Guid.NewGuid().ToString();
    }
}