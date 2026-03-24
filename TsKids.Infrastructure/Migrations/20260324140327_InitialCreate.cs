using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TsKids.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-0000-0000-0000-000000000001"), "Réplicas de Ferrari, Lamborghini, McLaren e outras supercars lendárias", "https://picsum.photos/seed/supercar/400/300", "Supercars" },
                    { new Guid("11111111-0000-0000-0000-000000000002"), "Réplicas de Land Rover, Range Rover, Mercedes GLE e outros SUVs", "https://picsum.photos/seed/suv4x4/400/300", "SUVs e 4x4" },
                    { new Guid("11111111-0000-0000-0000-000000000003"), "Réplicas de Porsche 911, Volkswagen Fusca, Mini Cooper e ícones clássicos", "https://picsum.photos/seed/classic/400/300", "Clássicos" },
                    { new Guid("11111111-0000-0000-0000-000000000004"), "Réplicas de BMW, Honda e Harley-Davidson para os pequenos pilotos", "https://picsum.photos/seed/moto/400/300", "Motos Elétricas" },
                    { new Guid("11111111-0000-0000-0000-000000000005"), "Capacetes, coletes de segurança, pistas e acessórios para carrinhos elétricos", "https://picsum.photos/seed/acessorio/400/300", "Acessórios" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("22222222-0000-0000-0000-000000000001"), "Ferrari Kids", new Guid("11111111-0000-0000-0000-000000000001"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3006), "Réplica oficial licenciada da Ferrari SF90 Stradale em versão infantil. Motor elétrico 12V com velocidade máxima de 5 km/h. Controle remoto parental incluso, faróis de LED, som do motor real gravado, assento em couro ecológico e cinto de segurança. Indicado para crianças de 3 a 8 anos.", "https://picsum.photos/seed/ferrari/400/500", "Ferrari SF90 Elétrico Infantil", 3499.90m, 7, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3006) },
                    { new Guid("22222222-0000-0000-0000-000000000002"), "Lamborghini Junior", new Guid("11111111-0000-0000-0000-000000000001"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3017), "Réplica do Lamborghini Huracán com pintura exclusiva amarela. Duas velocidades (3 e 5 km/h), abertura de portas no estilo tesoura, painel digital funcional, conexão Bluetooth para música e controle remoto 2.4GHz para os pais. Suporta até 35 kg.", "https://picsum.photos/seed/lambo/400/500", "Lamborghini Huracán 12V", 4199.00m, 4, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3017) },
                    { new Guid("22222222-0000-0000-0000-000000000003"), "McLaren Junior", new Guid("11111111-0000-0000-0000-000000000001"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3061), "Réplica do McLaren 720S com capota retrátil elétrica. Motor 12V duplo (tração nas 4 rodas), velocidade até 6 km/h, suspensão real, pneus de borracha e carregador incluso. O presente favorito da temporada para crianças de 4 a 9 anos.", "https://picsum.photos/seed/mclaren/400/500", "McLaren 720S Spider Kids", 4899.00m, 3, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3061) },
                    { new Guid("22222222-0000-0000-0000-000000000004"), "Range Rover Kids", new Guid("11111111-0000-0000-0000-000000000002"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3066), "Réplica do Range Rover Evoque com tração 4x4 real. Motor duplo 12V, 3 marchas para frente e 1 ré, suspensão amortecida, tela MP3 com Bluetooth, faróis e lanternas de LED e controle remoto parental. Até 40 kg. Ideal para 3 a 10 anos.", "https://picsum.photos/seed/rangerover/400/500", "Range Rover Evoque Infantil 12V", 2999.90m, 9, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3066) },
                    { new Guid("22222222-0000-0000-0000-000000000005"), "Mercedes Kids", new Guid("11111111-0000-0000-0000-000000000002"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3069), "O queridinho das crianças! Réplica do Mercedes GLE AMG com dois assentos (leva dois pequenos pilotos). Bateria 24V, velocidade até 8 km/h, câmera de ré, tela touch, som do motor V8 AMG e pneus com perfil off-road.", "https://picsum.photos/seed/mercedesgle/400/500", "Mercedes-Benz GLE AMG 4x4", 5499.00m, 5, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3069) },
                    { new Guid("22222222-0000-0000-0000-000000000006"), "Porsche Kids", new Guid("11111111-0000-0000-0000-000000000003"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3073), "Réplica do icônico Porsche 911 anos 70 em versão elétrica infantil. Design clássico fiel ao original, motor 6V, velocidade suave de 3 km/h ideal para os menores, rodas de liga, faróis retrô e buzina. Para crianças de 2 a 5 anos.", "https://picsum.photos/seed/porsche911/400/500", "Porsche 911 Clássico 6V", 1899.00m, 11, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3073) },
                    { new Guid("22222222-0000-0000-0000-000000000007"), "Mini Kids", new Guid("11111111-0000-0000-0000-000000000003"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3076), "Réplica do Mini Cooper S com visual retrô e personalizações exclusivas. Motor 12V, velocidade de 4 km/h, tejadilho com union jack, rodas cromadas e banco de couro ecológico. Umas das réplicas mais charmosas do mercado.", "https://picsum.photos/seed/minicooper/400/500", "Mini Cooper S Elétrico Retrô", 2299.00m, 8, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3076) },
                    { new Guid("22222222-0000-0000-0000-000000000008"), "BMW Motorrad Kids", new Guid("11111111-0000-0000-0000-000000000004"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3079), "Réplica da BMW S1000RR, a moto esportiva mais famosa do mundo em miniatura elétrica. Motor 6V, rodas de treinamento removíveis, faróis de LED, sons da BMW e velocidade até 4 km/h. Para crianças de 3 a 7 anos.", "https://picsum.photos/seed/bmwmoto/400/500", "BMW S1000RR Moto Infantil 6V", 1299.00m, 14, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3080) },
                    { new Guid("22222222-0000-0000-0000-000000000009"), "Harley Kids", new Guid("11111111-0000-0000-0000-000000000004"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3083), "Réplica da lendária Harley-Davidson Fat Boy em versão infantil. Estilo chopper autêntico, motor 12V, banco duplo, rodas largas cromadas, som do motor Harley original e velocidade de 3 km/h. Para os pequenos que já nasceram com DNA de liberdade.", "https://picsum.photos/seed/harley/400/500", "Harley-Davidson Fat Boy Elétrica", 1799.00m, 6, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3084) },
                    { new Guid("22222222-0000-0000-0000-000000000010"), "TsKids Gear", new Guid("11111111-0000-0000-0000-000000000005"), new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3086), "Capacete homologado para uso em carrinhos elétricos infantis. Material ABS resistente, viseira anti-risco, interior acolchoado lavável e regulagem de tamanho. Disponível em vermelho, amarelo, azul e preto. Tamanhos P, M e G.", "https://picsum.photos/seed/capacete/400/500", "Capacete Infantil Piloto Pro", 189.90m, 40, new DateTime(2026, 3, 24, 14, 3, 26, 868, DateTimeKind.Utc).AddTicks(3087) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
