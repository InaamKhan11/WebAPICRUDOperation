using Microsoft.EntityFrameworkCore;

namespace WebAPICRUDOperation.Models
{
    public class UserApiContext : DbContext
    {
        public UserApiContext(DbContextOptions<UserApiContext> options) : base(options)
        {
            
        }
        public DbSet<UserApi> UserApis { get; set; }
    }
}
