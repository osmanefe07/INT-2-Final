using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vize.Models;
namespace vize.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
    public AppDbContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<File> Files { get; set; }

        public DbSet<Folder> Folders { get; set;}

        public DbSet<Category> Categories { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }
        public object File { get; internal set; }
    }


}
