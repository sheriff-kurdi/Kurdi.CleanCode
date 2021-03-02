#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CleanCode.Web/CleanCode.Web.csproj", "CleanCode.Web/"]
RUN dotnet restore "CleanCode.Web/CleanCode.Web.csproj"
COPY . .
WORKDIR "/src/CleanCode.Web"
RUN dotnet build "CleanCode.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanCode.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanCode.Web.dll"]