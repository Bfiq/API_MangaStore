using API_Manga_ecommerce;
using API_Manga_ecommerce.Repositories.Categories;
using API_Manga_ecommerce.Repositories.Orders;
using API_Manga_ecommerce.Repositories.Products;
using API_Manga_ecommerce.Repositories.Users;
using API_Manga_ecommerce.Services.Categories;
using API_Manga_ecommerce.Services.Orders;
using API_Manga_ecommerce.Services.Products;
using API_Manga_ecommerce.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<DatabaseContext>(builder.Configuration.GetConnectionString("mangaBd"));

//Repositorios
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepostitory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//Servicios
builder.Services.AddScoped<ICategoryServices, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();