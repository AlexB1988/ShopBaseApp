using Microsoft.EntityFrameworkCore;
using ShopBaseApp.Domain.Entities;

namespace ShopBaseApp.Domain
{
    public class DataContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get;}
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }
    }
}
