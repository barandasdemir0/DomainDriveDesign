using DomainDriveDesign.Domain.Abstraction;
using DomainDriveDesign.Domain.Categories;
using DomainDriveDesign.Domain.Orders;
using DomainDriveDesign.Domain.Products;
using DomainDriveDesign.Domain.Shared;
using DomainDriveDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DomainDriveDesign.Infrastructure.Context;

internal class ApplicationDbContext:DbContext,IUnitOfWork
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=BARANPC\\SQLEXPRESS;Database=DomainDriveDesignDb;integrated security=True; TrustServerCertificate=True;");
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    //configuration işlemlerini yapıyoruz
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
          .Property(p => p.Name)
          .HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<User>()
           .Property(p => p.Email)
           .HasConversion(email => email.Value, value => new(value));

        modelBuilder.Entity<User>()
           .Property(p => p.Password)
           .HasConversion(password => password.Value, value => new(value));

        modelBuilder.Entity<User>()
            .OwnsOne(p => p.Address);

        modelBuilder.Entity<Category>()
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<Product>()
            .OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder
                .Property(p => p.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder
                .Property(p => p.Amount)
                .HasColumnType("money");
            });

        modelBuilder.Entity<OrderLine>()
            .OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder
                .Property(p => p.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder
                .Property(p => p.Amount)
                .HasColumnType("money");
            });
    }
}
