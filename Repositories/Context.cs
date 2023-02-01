using Auth_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth_API.Repositories
{
    public class Context : DbContext
    {
        private string connectionString { get; set; }
        public Context(string _connectionString) 
        {
            connectionString= _connectionString;
        }

        public Context(DbContextOptions<Context> options) : base(options) { }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.UserName).HasMaxLength(55).IsRequired();
                entity.Property(x => x.Email).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Pswrd).HasMaxLength(100).IsRequired();
                entity.Property(x => x.CreateDate).IsRequired();
                entity.Property(x => x.LastLogin).IsRequired();
            });
        }
    }
}
