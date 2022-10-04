using Microsoft.EntityFrameworkCore;
using RMS.Utility.Models;

namespace RMS.GrpcService.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDoc> UserDocs { get; set; } = default!;
    }
}
