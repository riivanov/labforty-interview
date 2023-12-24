using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Auth;

public class LoginContext : IdentityDbContext
{
    public LoginContext(DbContextOptions<LoginContext> options)
        : base(options) { }
}
