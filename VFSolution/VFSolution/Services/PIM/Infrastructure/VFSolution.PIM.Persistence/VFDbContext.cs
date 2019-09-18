using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VFSolution.PIM.Domain.Entities;
namespace VFSolution.PIM.Persistence
{
    public class VFDbContext : DbContext
    {
        public VFDbContext(DbContextOptions<VFDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Setup(modelBuilder.Entity<User>());
            Setup(modelBuilder.Entity<UserRole>());
            Setup(modelBuilder.Entity<Product>());
            Setup(modelBuilder.Entity<Customer>());
            Setup(modelBuilder.Entity<Store>());
            Setup(modelBuilder.Entity<Category>());
            Setup(modelBuilder.Entity<Invoice>());
            Setup(modelBuilder.Entity<InvoiceItem>());
            Setup(modelBuilder.Entity<Location>());
            Setup(modelBuilder.Entity<Price>());
            Setup(modelBuilder.Entity<PurchaseOrder>());
            Setup(modelBuilder.Entity<PurchaseOrderItem>());
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

        public void Setup(EntityTypeBuilder<Product> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
            entityConfig.HasMany(x => x.Prices)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public void Setup(EntityTypeBuilder<Customer> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
            entityConfig.HasMany(x => x.Stores)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public void Setup(EntityTypeBuilder<Store> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
            entityConfig.HasMany(x => x.Prices)
                .WithOne(x => x.Store)
                .HasForeignKey(x => x.StoreId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public void Setup(EntityTypeBuilder<Category> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
        }

        public void Setup(EntityTypeBuilder<Invoice> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);

            entityConfig.HasMany(s => s.InvoiceItems)
                .WithOne(x => x.Invoice)
                .HasForeignKey(a => a.InvoiceId);
        }

        public void Setup(EntityTypeBuilder<InvoiceItem> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
        }

        public void Setup(EntityTypeBuilder<Location> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
        }

        public void Setup(EntityTypeBuilder<PurchaseOrder> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);

            entityConfig.HasMany(s => s.PurchaseOrderItems)
                .WithOne(x => x.PurchaseOrder)
                .HasForeignKey(a => a.PurchaseOrderId);

            entityConfig.HasMany(s => s.Invoices)
                .WithOne(x => x.PurchaseOrder)
                .HasForeignKey(a => a.PurchaseOrderId);
        }

        public void Setup(EntityTypeBuilder<PurchaseOrderItem> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
        }

        public void Setup(EntityTypeBuilder<Price> entityConfig)
        {
            entityConfig.HasKey(x => x.Id);
        }
    }
}
