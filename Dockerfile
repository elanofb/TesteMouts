
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Order.WebApi/Order.WebApi.csproj", "src/Order.WebApi/"]
COPY ["src/Order.Application/Order.Application.csproj", "src/Order.Application/"]
COPY ["src/Order.Common/Order.Common.csproj", "src/Order.Common/"]
COPY ["src/Order.Domain/Order.Domain.csproj", "src/Order.Domain/"]
COPY ["src/Order.IoC/Order.IoC.csproj", "src/Order.IoC/"]
COPY ["src/Order.ORM/Order.ORM.csproj", "src/Order.ORM/"]
RUN dotnet restore "./src/Order.WebApi/Order.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Order.WebApi"
RUN dotnet build "./Order.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Order.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.WebApi.dll"]
