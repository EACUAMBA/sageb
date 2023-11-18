using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace sageb.Database.Entities.Identity;

public class UserLogin:IdentityUserLogin<string>
{
}