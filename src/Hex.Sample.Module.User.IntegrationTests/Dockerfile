#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Hex.Sample.Host/Hex.Sample.Host.csproj", "src/Hex.Sample.Host/"]
COPY ["src/Hex.Sample.Module.User/Hex.Sample.Module.User.csproj", "src/Hex.Sample.Module.User/"]
COPY ["src/Hex.Sample.Sdk.Contracts/Hex.Sample.Sdk.Contracts.csproj", "src/Hex.Sample.Sdk.Contracts/"]
COPY ["src/Hex.Sample.Module.User.IntegrationTests/Hex.Sample.Module.User.IntegrationTests.csproj", "src/Hex.Sample.Module.User.IntegrationTests/"]
RUN dotnet restore "src/Hex.Sample.Module.User.IntegrationTests/Hex.Sample.Module.User.IntegrationTests.csproj"
COPY . .
WORKDIR "/src/src/Hex.Sample.Module.User.IntegrationTests"
RUN dotnet build "Hex.Sample.Module.User.IntegrationTests.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "Hex.Sample.Module.User.IntegrationTests.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Hex.Sample.Host.dll"]



FROM build as integrationtests
WORKDIR /src/src/Hex.Sample.Module.User.IntegrationTests