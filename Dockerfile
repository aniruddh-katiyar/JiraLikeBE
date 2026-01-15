# ===============================
# Base runtime image
# ===============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Install native dependencies required for SQLite
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        sqlite3 \
        libsqlite3-dev && \
    rm -rf /var/lib/apt/lists/*

# ===============================
# Build stage
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files for restore (better Docker cache)
COPY ["JiraLike.Api/JiraLike.Api.csproj", "JiraLike.Api/"]
COPY ["JiraLike.Application/JiraLike.Application.csproj", "JiraLike.Application/"]
COPY ["JiraLike.Domain/JiraLike.Domain.csproj", "JiraLike.Domain/"]
COPY ["JiraLike.Infrastructure/JiraLike.Infrastructure.csproj", "JiraLike.Infrastructure/"]

RUN dotnet restore "JiraLike.Api/JiraLike.Api.csproj"

# Copy full source
COPY . .

WORKDIR "/src/JiraLike.Api"
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ===============================
# Final runtime stage
# ===============================
FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

# Production environment → SQLite
ENV ASPNETCORE_ENVIRONMENT=Production

# SQLite persistence directory (mapped to Docker volume)
RUN mkdir -p /app/data

ENTRYPOINT ["dotnet", "JiraLike.Api.dll"]
