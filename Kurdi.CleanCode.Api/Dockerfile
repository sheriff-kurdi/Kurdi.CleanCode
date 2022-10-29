FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Kurdi.CleanCode.Api/Kurdi.CleanCode.Api/Kurdi.CleanCode.Api.csproj", "Kurdi.CleanCode.Api/"]
RUN dotnet restore "Kurdi.CleanCode.Api/Kurdi.CleanCode.Api/Kurdi.CleanCode.Api.csproj"
COPY . .
WORKDIR "/src/Kurdi.CleanCode.Api"
RUN dotnet build "Kurdi.CleanCode.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kurdi.CleanCode.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kurdi.CleanCode.Api.dll"]
