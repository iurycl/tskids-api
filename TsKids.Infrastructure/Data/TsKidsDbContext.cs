using Microsoft.EntityFrameworkCore;
using TsKids.Domain.Entities;

namespace TsKids.Infrastructure.Data;

public class TsKidsDbContext(DbContextOptions<TsKidsDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        // ── Category ─────────────────────────────────────────────
        mb.Entity<Category>(e =>
        {
            e.ToTable("categories");
            e.HasKey(c => c.Id);
            e.Property(c => c.Name).HasMaxLength(100).IsRequired();
            e.Property(c => c.Description).HasMaxLength(500);
            e.Property(c => c.ImageUrl).HasMaxLength(500);
        });

        // ── Product ───────────────────────────────────────────────
        mb.Entity<Product>(e =>
        {
            e.ToTable("products");
            e.HasKey(p => p.Id);
            e.Property(p => p.Name).HasMaxLength(200).IsRequired();
            e.Property(p => p.Description).HasMaxLength(2000);
            e.Property(p => p.Price).HasColumnType("numeric(18,2)");
            e.Property(p => p.ImageUrl).HasMaxLength(500);
            e.Property(p => p.Brand).HasMaxLength(100);

            e.HasOne(p => p.Category)
             .WithMany(c => c.Products)
             .HasForeignKey(p => p.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // ── Seed Data ─────────────────────────────────────────────
        SeedData(mb);
    }

    private static void SeedData(ModelBuilder mb)
    {
        // ── Categorias: tipos de carrinhos elétricos infantis ─────
        var cat1 = new Category
        {
            Id = Guid.Parse("11111111-0000-0000-0000-000000000001"),
            Name = "Supercars",
            Description = "Réplicas de Ferrari, Lamborghini, McLaren e outras supercars lendárias",
            ImageUrl = "https://picsum.photos/seed/supercar/400/300"
        };
        var cat2 = new Category
        {
            Id = Guid.Parse("11111111-0000-0000-0000-000000000002"),
            Name = "SUVs e 4x4",
            Description = "Réplicas de Land Rover, Range Rover, Mercedes GLE e outros SUVs",
            ImageUrl = "https://picsum.photos/seed/suv4x4/400/300"
        };
        var cat3 = new Category
        {
            Id = Guid.Parse("11111111-0000-0000-0000-000000000003"),
            Name = "Clássicos",
            Description = "Réplicas de Porsche 911, Volkswagen Fusca, Mini Cooper e ícones clássicos",
            ImageUrl = "https://picsum.photos/seed/classic/400/300"
        };
        var cat4 = new Category
        {
            Id = Guid.Parse("11111111-0000-0000-0000-000000000004"),
            Name = "Motos Elétricas",
            Description = "Réplicas de BMW, Honda e Harley-Davidson para os pequenos pilotos",
            ImageUrl = "https://picsum.photos/seed/moto/400/300"
        };
        var cat5 = new Category
        {
            Id = Guid.Parse("11111111-0000-0000-0000-000000000005"),
            Name = "Acessórios",
            Description = "Capacetes, coletes de segurança, pistas e acessórios para carrinhos elétricos",
            ImageUrl = "https://picsum.photos/seed/acessorio/400/300"
        };

        mb.Entity<Category>().HasData(cat1, cat2, cat3, cat4, cat5);

        // ── Produtos: réplicas de carros famosos ──────────────────
        var products = new[]
        {
            // Supercars
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000001"),
                Name = "Ferrari SF90 Elétrico Infantil",
                Description = "Réplica oficial licenciada da Ferrari SF90 Stradale em versão infantil. Motor elétrico 12V com velocidade máxima de 5 km/h. Controle remoto parental incluso, faróis de LED, som do motor real gravado, assento em couro ecológico e cinto de segurança. Indicado para crianças de 3 a 8 anos.",
                Price = 3499.90m, Brand = "Ferrari Kids", Stock = 7,
                CategoryId = cat1.Id, ImageUrl = "https://picsum.photos/seed/ferrari/400/500"
            },
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000002"),
                Name = "Lamborghini Huracán 12V",
                Description = "Réplica do Lamborghini Huracán com pintura exclusiva amarela. Duas velocidades (3 e 5 km/h), abertura de portas no estilo tesoura, painel digital funcional, conexão Bluetooth para música e controle remoto 2.4GHz para os pais. Suporta até 35 kg.",
                Price = 4199.00m, Brand = "Lamborghini Junior", Stock = 4,
                CategoryId = cat1.Id, ImageUrl = "https://picsum.photos/seed/lambo/400/500"
            },
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000003"),
                Name = "McLaren 720S Spider Kids",
                Description = "Réplica do McLaren 720S com capota retrátil elétrica. Motor 12V duplo (tração nas 4 rodas), velocidade até 6 km/h, suspensão real, pneus de borracha e carregador incluso. O presente favorito da temporada para crianças de 4 a 9 anos.",
                Price = 4899.00m, Brand = "McLaren Junior", Stock = 3,
                CategoryId = cat1.Id, ImageUrl = "https://picsum.photos/seed/mclaren/400/500"
            },

            // SUVs e 4x4
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000004"),
                Name = "Range Rover Evoque Infantil 12V",
                Description = "Réplica do Range Rover Evoque com tração 4x4 real. Motor duplo 12V, 3 marchas para frente e 1 ré, suspensão amortecida, tela MP3 com Bluetooth, faróis e lanternas de LED e controle remoto parental. Até 40 kg. Ideal para 3 a 10 anos.",
                Price = 2999.90m, Brand = "Range Rover Kids", Stock = 9,
                CategoryId = cat2.Id, ImageUrl = "https://picsum.photos/seed/rangerover/400/500"
            },
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000005"),
                Name = "Mercedes-Benz GLE AMG 4x4",
                Description = "O queridinho das crianças! Réplica do Mercedes GLE AMG com dois assentos (leva dois pequenos pilotos). Bateria 24V, velocidade até 8 km/h, câmera de ré, tela touch, som do motor V8 AMG e pneus com perfil off-road.",
                Price = 5499.00m, Brand = "Mercedes Kids", Stock = 5,
                CategoryId = cat2.Id, ImageUrl = "https://picsum.photos/seed/mercedesgle/400/500"
            },

            // Clássicos
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000006"),
                Name = "Porsche 911 Clássico 6V",
                Description = "Réplica do icônico Porsche 911 anos 70 em versão elétrica infantil. Design clássico fiel ao original, motor 6V, velocidade suave de 3 km/h ideal para os menores, rodas de liga, faróis retrô e buzina. Para crianças de 2 a 5 anos.",
                Price = 1899.00m, Brand = "Porsche Kids", Stock = 11,
                CategoryId = cat3.Id, ImageUrl = "https://picsum.photos/seed/porsche911/400/500"
            },
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000007"),
                Name = "Mini Cooper S Elétrico Retrô",
                Description = "Réplica do Mini Cooper S com visual retrô e personalizações exclusivas. Motor 12V, velocidade de 4 km/h, tejadilho com union jack, rodas cromadas e banco de couro ecológico. Umas das réplicas mais charmosas do mercado.",
                Price = 2299.00m, Brand = "Mini Kids", Stock = 8,
                CategoryId = cat3.Id, ImageUrl = "https://picsum.photos/seed/minicooper/400/500"
            },

            // Motos
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000008"),
                Name = "BMW S1000RR Moto Infantil 6V",
                Description = "Réplica da BMW S1000RR, a moto esportiva mais famosa do mundo em miniatura elétrica. Motor 6V, rodas de treinamento removíveis, faróis de LED, sons da BMW e velocidade até 4 km/h. Para crianças de 3 a 7 anos.",
                Price = 1299.00m, Brand = "BMW Motorrad Kids", Stock = 14,
                CategoryId = cat4.Id, ImageUrl = "https://picsum.photos/seed/bmwmoto/400/500"
            },
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000009"),
                Name = "Harley-Davidson Fat Boy Elétrica",
                Description = "Réplica da lendária Harley-Davidson Fat Boy em versão infantil. Estilo chopper autêntico, motor 12V, banco duplo, rodas largas cromadas, som do motor Harley original e velocidade de 3 km/h. Para os pequenos que já nasceram com DNA de liberdade.",
                Price = 1799.00m, Brand = "Harley Kids", Stock = 6,
                CategoryId = cat4.Id, ImageUrl = "https://picsum.photos/seed/harley/400/500"
            },

            // Acessórios
            new Product
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000010"),
                Name = "Capacete Infantil Piloto Pro",
                Description = "Capacete homologado para uso em carrinhos elétricos infantis. Material ABS resistente, viseira anti-risco, interior acolchoado lavável e regulagem de tamanho. Disponível em vermelho, amarelo, azul e preto. Tamanhos P, M e G.",
                Price = 189.90m, Brand = "TsKids Gear", Stock = 40,
                CategoryId = cat5.Id, ImageUrl = "https://picsum.photos/seed/capacete/400/500"
            },
        };

        mb.Entity<Product>().HasData(products);
    }
}
