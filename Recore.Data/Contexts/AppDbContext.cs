using Microsoft.EntityFrameworkCore;
using Recore.Domain.Entities.Addresses;
using Recore.Domain.Entities.Attachments;
using Recore.Domain.Entities.Bonuses;
using Recore.Domain.Entities.Inventories;
using Recore.Domain.Entities.Orders;
using Recore.Domain.Entities.Products;
using Recore.Domain.Entities.Suppliers;
using Recore.Domain.Entities.Users;
using Recore.Domain.Enums;

namespace Recore.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Bonus> Bonuses { get; set; }
    public DbSet<BonusSetting> BonusSettings { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryLog> InventoryLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Fluent API
        modelBuilder.Entity<User>()
            .Property<DateTime>("LastUpdated");



        #endregion

        #region SeedData
        modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory { Id = 1, Name = "Burgers", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProductCategory { Id = 2, Name = "Lavashes", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProductCategory { Id = 3, Name = "Hot-Dogs", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProductCategory { Id = 4, Name = "Sendviches", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProductCategory { Id = 5, Name = "Salats", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProductCategory { Id = 6, Name = "Snacks", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProductCategory { Id = 7, Name = "Pizzas", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProductCategory { Id = 8, Name = "Hot drinks", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProductCategory { Id = 9, Name = "Cold drinks", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new ProductCategory { Id = 10, Name = "Sauces", CreatedAt = DateTime.UtcNow, UpdatedAt = null });

        //modelBuilder.Entity<Product>().HasData(
        //    new Product { Id = 1, Name = "Cheeseburger", CategoryId = 1, Description = "", Unit = Unit.pc, Quantity = 10, Price = 24000, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
        //    new Product { Id = 2, Name = "Coffee", CategoryId = 8, Description = "", Unit = Unit.pc, Quantity = 10, Price = 7000, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
        //    new Product { Id = 3, Name = "Moxito", CategoryId = 9, Description = "", Unit = Unit.pc, Quantity = 10, Price = 15000, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
        //    new Product { Id = 4, Name = "Ketchup", CategoryId = 10, Description = "", Unit = Unit.pc, Quantity = 10, Price = 3000, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
        //    new Product { Id = 5, Name = "Caesar", CategoryId = 5, Description = "", Unit = Unit.pc, Quantity = 10, Price = 23000, CreatedAt = DateTime.UtcNow, UpdatedAt = null });
        #endregion
    }
}
