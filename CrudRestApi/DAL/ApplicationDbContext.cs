using CrudRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudRestApi.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
    }
    
    
}
