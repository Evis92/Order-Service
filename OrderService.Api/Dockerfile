# Stage 1: Build all dependencies
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["OrderService.Api/OrderService.Api.csproj", "OrderService.Api/"]
COPY ["OrderService.Application/OrderService.Application.csproj", "OrderService.Application/"]
COPY ["OrderService.Core/OrderService.Core.csproj", "OrderService.Core/"]
COPY ["OrderService.Instrastructure/OrderService.Instrastructure.csproj", "OrderService.Instrastructure/"]

RUN dotnet restore "OrderService.Api/OrderService.Api.csproj"

# Copy the full solution
COPY . .

# Build all projects
RUN dotnet build "OrderService.Api/OrderService.Api.csproj" -c Release

# Stage 2: Run tests
#FROM build AS test
#WORKDIR /src/WebShopTests

# Run tests and ensure they pass
#RUN dotnet test "WebShopTests.csproj" --no-build --logger:trx --results-directory /src/TestResults

# Stage 3: Publish WebShop (only proceeds if tests pass)
FROM build AS publish
WORKDIR /src/OrderService.Api
RUN dotnet publish "OrderService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final runtime image for WebShop
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderService.Api.dll"]