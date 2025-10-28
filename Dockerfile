FROM mcr.microsoft.com/dotnet/aspnet:9.0.10 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0.306 AS build
WORKDIR /src
COPY ["Catalog-Microservice.csproj", "."]
RUN dotnet restore "Catalog-Microservice.csproj"
COPY . .
RUN dotnet build "Catalog-Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog-Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog-Microservice.dll"]

