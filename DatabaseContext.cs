using API_Manga_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Manga_ecommerce;

public class DatabaseContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrdersDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        List<Category> categories = new List<Category>();
        categories.Add(new Category { CategoryId=1, Name="Mangas Fisicos"});
        categories.Add(new Category { CategoryId = 2, Name = "Mangas Virtuales" });

        modelBuilder.Entity<Category>(categoryTable =>
        {
            categoryTable.ToTable("Category");
            categoryTable.HasKey(t => t.CategoryId);
            categoryTable.Property(t => t.Name).IsRequired().HasMaxLength(100);
            categoryTable.Property(t => t.Description);

            categoryTable.HasData(categories);
        });

        modelBuilder.Entity<Product>(productTable =>
        {
            productTable.ToTable("Product");
            productTable.HasKey(t=>t.ProductId);
            productTable.HasOne(t => t.Category).WithMany(t => t.Products).HasForeignKey(t=>t.CategoryId);
            productTable.Property(t => t.Name).IsRequired();
            productTable.Property(t => t.Description).IsRequired(false);
            productTable.Property(t => t.Price).IsRequired();
            productTable.Property(t => t.Quantity).IsRequired();
            productTable.Property(t => t.Url).IsRequired(false);
        });

        modelBuilder.Entity<User>(userTable =>
        {
            userTable.ToTable("User");
            userTable.HasKey(t => t.UserId);
            userTable.Property(t => t.Email).IsRequired();
            userTable.Property(t => t.Password).IsRequired();
            userTable.Property(t=> t.Role).IsRequired();
            userTable.Property(t => t.shippingAddress).IsRequired(false);
        });

        modelBuilder.Entity<Order>(orderTable =>
        {
            orderTable.ToTable("Order");
            orderTable.HasKey(t => t.OrderId);
            orderTable.HasOne(t => t.User).WithMany(t => t.Orders).HasForeignKey(t=>t.UserId);
            orderTable.Property(t => t.OrderDate);
            orderTable.Property(t => t.TotalAmount);
            orderTable.Property(t => t.OrderStatus).IsRequired();
        });

        modelBuilder.Entity<OrderDetails>(orderDetailsTable =>
        {
            orderDetailsTable.ToTable("OrderDetails");
            orderDetailsTable.HasKey(t => t.OrderDetailsId);
            orderDetailsTable.HasOne(t => t.Order).WithMany(t => t.OrderDetails).HasForeignKey(t => t.OrderId);
            orderDetailsTable.HasOne(t => t.Product).WithMany(t => t.OrderDetails).HasForeignKey(t => t.ProductId);
            orderDetailsTable.Property(t => t.Quantity);
            orderDetailsTable.Property(t => t.UnitPrice);
            orderDetailsTable.Property(t => t.Discount).IsRequired(false);
        });

        modelBuilder.Entity<Payment>(paymentTable =>
        {
            paymentTable.ToTable("Payment");
            paymentTable.HasKey(t => t.PaymentId);
            paymentTable.HasOne(t => t.Order).WithMany(t => t.Payments).HasForeignKey(t => t.OrderId);
            paymentTable.Property(t => t.Status).IsRequired(false);
            paymentTable.Property(t => t.Amount).IsRequired(false);
            paymentTable.Property(t => t.CreatedAt);
            paymentTable.Property(t => t.PaymontMethodType).IsRequired(false);
        });
    }
}
