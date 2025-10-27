FROM mcr.microsoft.com/dotnet/aspnet:8.0.19 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0.413 AS build
WORKDIR /src
COPY ["Catalog-Microservice/Catalog-Microservice.csproj", "Catalog-Microservice/"]
RUN dotnet restore "Catalog-Microservice/Catalog-Microservice.csproj"
COPY . .
WORKDIR "/src/Catalog-Microservice"
RUN dotnet build "Catalog-Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog-Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog-Microservice.dll"]

