# ── Stage 1: Build ────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj e restaurar dependencias
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

# IMPORTANTE: usar CMD com shell para que ${PORT} seja expandido em RUNTIME.
# ENV no Dockerfile e avaliado em BUILD TIME e nunca captura o PORT do Railway.
CMD ["sh", "-c", "ASPNETCORE_URLS=http://+:${PORT:-8080} dotnet TsKids.API.dll"]
