FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["VinylCollection.Web/VinylCollection.Web.csproj", "VinylCollection.Web/"]
COPY ["VinylCollection.Domain/VinylCollection.Domain.csproj", "VinylCollection.Domain/"]
COPY ["VinylCollection.Service/VinylCollection.Service.csproj", "VinylCollection.Service/"]
COPY ["VinylCollection.Data/VinylCollection.Data.csproj", "VinylCollection.Data/"]
RUN dotnet restore "VinylCollection.Web/VinylCollection.Web.csproj"

COPY . .
WORKDIR "/src/VinylCollection.Web"
RUN dotnet build "VinylCollection.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VinylCollection.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apt-get update && apt-get -y install libxml2 libgdiplus libc6-dev
ENTRYPOINT ["dotnet", "VinylCollection.Web.dll"]

