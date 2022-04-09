#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OperacionFuego.Quasar.Api/OperacionFuego.Quasar.Api.csproj", "OperacionFuego.Quasar.Api/"]
RUN dotnet restore "OperacionFuego.Quasar.Api/OperacionFuego.Quasar.Api.csproj"
COPY . .
WORKDIR "/src/OperacionFuego.Quasar.Api"
RUN dotnet build "OperacionFuego.Quasar.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OperacionFuego.Quasar.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OperacionFuego.Quasar.Api.dll"]