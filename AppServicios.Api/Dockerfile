FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["AppServicios.Api/AppServicios.Api.csproj", "AppServicios.Api/"]
RUN dotnet restore "AppServicios.Api/AppServicios.Api.csproj"

COPY . .
WORKDIR /src/AppServicios.Api
RUN dotnet publish "AppServicios.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production \
    DOTNET_RUNNING_IN_CONTAINER=true

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://+:${PORT:-8080} dotnet AppServicios.Api.dll"]
