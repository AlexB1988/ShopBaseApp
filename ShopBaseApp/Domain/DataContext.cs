using Microsoft.EntityFrameworkCore;

namespace ShopBaseApp.Domain
{
    public class DataContext:DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }
    }
}
