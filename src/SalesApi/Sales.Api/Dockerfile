FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SalesApi/Sales.Api/Sales.Api.csproj", "src/SalesApi/Sales.Api/"]
COPY ["src/SalesApi/Sales.Application/Sales.Application.csproj", "src/SalesApi/Sales.Application/"]
COPY ["src/SalesApi/Sales.Domain/Sales.Domain.csproj", "src/SalesApi/Sales.Domain/"]
COPY ["src/SalesApi/Sales.Infrastructure/Sales.Infrastructure.csproj", "src/SalesApi/Sales.Infrastructure/"]
RUN dotnet restore "src/SalesApi/Sales.Api/Sales.Api.csproj"
COPY . .
WORKDIR "/src/src/SalesApi/Sales.Api"
RUN dotnet build "Sales.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sales.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.Api.dll"]
