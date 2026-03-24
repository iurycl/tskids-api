using Microsoft.EntityFrameworkCore;
using TsKids.Application.UseCases.Categories;
using TsKids.Application.UseCases.Products;
using TsKids.Domain.Interfaces;
using TsKids.Infrastructure.Data;
using TsKids.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ── Connection String ─────────────────────────────────────────────
// Railway injeta DATABASE_URL no formato:
// postgresql://user:password@host:port/database
// Também aceita a string no formato EF Core via appsettings.json
static string BuildConnectionString()
{
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
    if (!string.IsNullOrEmpty(databaseUrl))
    {
        // Converter formato postgresql:// para formato Npgsql
        var uri = new Uri(databaseUrl);
        var userInfo = uri.UserInfo.Split(':');
        return $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";
    }

    // Fallback: variáveis individuais do Railway (PGHOST, PGPORT etc.)
    var pgHost     = Environment.GetEnvironmentVariable("PGHOST");
    var pgPort     = Environment.GetEnvironmentVariable("PGPORT") ?? "5432";
    var pgDb       = Environment.GetEnvironmentVariable("PGDATABASE");
    var pgUser     = Environment.GetEnvironmentVariable("PGUSER");
    var pgPassword = Environment.GetEnvironmentVariable("PGPASSWORD");

    if (!string.IsNullOrEmpty(pgHost))
        return $"Host={pgHost};Port={pgPort};Database={pgDb};Username={pgUser};Password={pgPassword};SSL Mode=Require;Trust Server Certificate=true";

    // Local: ler do appsettings
    return string.Empty;
}

// ── Services ──────────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TsKids API", Version = "v1", Description = "Marketplace de Carrinhos Eletricos Infantis" });
});

// Database
var connStr = BuildConnectionString();
builder.Services.AddDbContext<TsKidsDbContext>(opt =>
    opt.UseNpgsql(
        string.IsNullOrEmpty(connStr)
            ? builder.Configuration.GetConnectionString("DefaultConnection")
            : connStr));

// Repositories & Use Cases
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<GetProductsUseCase>();
builder.Services.AddScoped<GetProductByIdUseCase>();
builder.Services.AddScoped<GetCategoriesUseCase>();

// CORS — em produção aceita qualquer origem (Vercel gera URLs dinâmicas)
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddCors(opt =>
    opt.AddPolicy("TsKidsPolicy", p =>
    {
        if (builder.Environment.IsProduction())
            p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        else
            p.WithOrigins(allowedOrigins ?? ["http://localhost:8100", "http://localhost:4200"])
             .AllowAnyHeader().AllowAnyMethod();
    }));

var app = builder.Build();

// ── Migrate & Seed ────────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TsKidsDbContext>();
    db.Database.Migrate();
}

// ── Middleware ────────────────────────────────────────────────────
// Swagger disponível também em produção para facilitar testes
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TsKids API v1"));

app.UseCors("TsKidsPolicy");

// Railway usa HTTP internamente (HTTPS é terminado no proxy deles)
if (!app.Environment.IsProduction())
    app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// Lê PORT em runtime (Railway injeta essa variável)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://+:{port}");
