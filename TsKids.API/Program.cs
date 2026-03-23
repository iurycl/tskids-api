using Microsoft.EntityFrameworkCore;
using TsKids.Application.UseCases.Categories;
using TsKids.Application.UseCases.Products;
using TsKids.Domain.Interfaces;
using TsKids.Infrastructure.Data;
using TsKids.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ── Services ──────────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TsKids API", Version = "v1", Description = "Marketplace de Carrinhos de Bebê" });
});

// Database
builder.Services.AddDbContext<TsKidsDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories & Use Cases
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<GetProductsUseCase>();
builder.Services.AddScoped<GetProductByIdUseCase>();
builder.Services.AddScoped<GetCategoriesUseCase>();

// CORS
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()
    ?? ["http://localhost:8100", "http://localhost:4200"];

builder.Services.AddCors(opt =>
    opt.AddPolicy("TsKidsPolicy", p =>
        p.WithOrigins(allowedOrigins)
         .AllowAnyHeader()
         .AllowAnyMethod()));

var app = builder.Build();

// ── Migrate & Seed ────────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TsKidsDbContext>();
    db.Database.Migrate();
}

// ── Middleware ────────────────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TsKids API v1"));
}

app.UseCors("TsKidsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
