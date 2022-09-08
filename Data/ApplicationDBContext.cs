using System;
using BulkyBook1Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook1Web.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}

