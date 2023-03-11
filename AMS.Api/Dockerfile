#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AMS.Api/AMS.Api.csproj", "AMS.Api/"]
COPY ["AMS.Application/AMS.Application.csproj", "AMS.Application/"]
COPY ["AMS.Domain/AMS.Domain.csproj", "AMS.Domain/"]
COPY ["AMS.Infrastructure/AMS.Infrastructure.csproj", "AMS.Infrastructure/"]
RUN dotnet restore "AMS.Api/AMS.Api.csproj"
COPY . .
WORKDIR "/src/AMS.Api"
RUN dotnet build "AMS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AMS.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AMS.Api.dll"]