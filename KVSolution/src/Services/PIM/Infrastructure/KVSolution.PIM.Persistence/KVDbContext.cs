using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KVSolution.PIM.Domain.Entities;
namespace KVSolution.PIM.Persistence
{
    public class KVDbContext : DbContext
    {
        public KVDbContext(DbContextOptions<KVDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Setup(modelBuilder.Entity<User>());
            Setup(modelBuilder.Entity<UserRole>());
            Setup(modelBuilder.Entity<Customer>());
            Setup(modelBuilder.Entity<Category>());
        }
        public void Setup(EntityTypeBuilder<User> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);

            entityConfig.HasMany(s => s.UserRoles)
                .WithOne(x => x.User)
                .HasForeignKey(a => a.UserId);
        }
        public void Setup(EntityTypeBuilder<UserRole> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
        }
        public void Setup(EntityTypeBuilder<Customer> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
        }
        public void Setup(EntityTypeBuilder<Category> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
        }
        public void Setup(EntityTypeBuilder<Blog> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
        }
    }
}
