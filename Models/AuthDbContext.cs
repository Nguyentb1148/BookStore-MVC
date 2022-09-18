using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook1Web.Models;

public class AuthDbContext:IdentityDbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options)
    {
        
    }
}