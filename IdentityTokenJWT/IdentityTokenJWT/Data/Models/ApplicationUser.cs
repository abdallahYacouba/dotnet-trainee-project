using Microsoft.AspNetCore.Identity;

namespace IdentityTokenJWT.Data.Models;
public class ApplicationUser : IdentityUser
{
    public string? Custom { get; set; }
}
