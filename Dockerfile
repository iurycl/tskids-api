# ── Stage 1: Build ────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj e restaurar dependências
COPY TsKids.Domain/TsKids.Domain.csproj             TsKids.Domain/
COPY TsKids.Application/TsKids.Application.csproj   TsKids.Application/
COPY TsKids.Infrastructure/TsKids.Infrastructure.csproj TsKids.Infrastructure/
COPY TsKids.API/TsKids.API.csproj                   TsKids.API/
RUN dotnet restore TsKids.API/TsKids.API.csproj

# Copiar tudo e publicar
COPY . .
RUN dotnet publish TsKids.API/TsKids.API.csproj -c Release -o /app/publish

# ── Stage 2: Runtime ───────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Railway injeta a variável PORT automaticamente
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

ENTRYPOINT ["dotnet", "TsKids.API.dll"]
