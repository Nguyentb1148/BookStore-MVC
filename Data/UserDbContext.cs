using Microsoft.EntityFrameworkCore;

namespace BulkyBook1Web.Data;

public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {
            
        }
    }