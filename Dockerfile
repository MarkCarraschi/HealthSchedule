# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["HealthSchedule.sln", "."]
COPY ["HealthSchedule.WebApi/HealthSchedule.WebApi.csproj", "HealthSchedule.WebApi/"]
COPY ["HealthSchedule.Application/HealthSchedule.Application.csproj", "HealthSchedule.Application/"]
COPY ["HealthSchedule.Domain/HealthSchedule.Domain.csproj", "HealthSchedule.Domain/"]
COPY ["HealthSchedule.Infra/HealthSchedule.Infra.csproj", "HealthSchedule.Infra/"]
COPY ["HealthSchedule.Tests/HealthSchedule.Tests.csproj", "HealthSchedule.Tests/"]

# Restore dependencies
RUN dotnet restore "HealthSchedule.sln"

# Copy source code
COPY . .

# Build the WebApi project
RUN dotnet build "HealthSchedule.WebApi/HealthSchedule.WebApi.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "HealthSchedule.WebApi/HealthSchedule.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Set environment variables for production
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

# Expose port 8080 (Render default)
EXPOSE 8080

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=40s --retries=3 \
    CMD dotnet-trace ps > /dev/null 2>&1 || exit 1

# Run the application
ENTRYPOINT ["dotnet", "HealthSchedule.WebApi.dll"]
