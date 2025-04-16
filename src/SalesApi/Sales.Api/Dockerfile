FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ProductsApi/Products.Api/Products.Api.csproj", "src/ProductsApi/Products.Api/"]
COPY ["src/ProductsApi/Products.Application/Products.Application.csproj", "src/ProductsApi/Products.Application/"]
COPY ["src/ProductsApi/Products.Domain/Products.Domain.csproj", "src/ProductsApi/Products.Domain/"]
COPY ["src/ProductsApi/Products.Infrastructure/Products.Infrastructure.csproj", "src/ProductsApi/Products.Infrastructure/"]
RUN dotnet restore "src/ProductsApi/Products.Api/Products.Api.csproj"
COPY . .
WORKDIR "/src/src/ProductsApi/Products.Api"
RUN dotnet build "Products.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Products.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products.Api.dll"]
