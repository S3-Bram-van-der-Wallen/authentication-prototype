using Authentication_prototype_s3.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication_prototype_s3.Users;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }

    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }
}
