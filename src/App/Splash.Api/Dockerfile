FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/App/Splash.Api/Splash.Api.csproj", "src/App/Splash.Api/"]
RUN dotnet restore "src/App/Splash.Api/Splash.Api.csproj"
COPY . .
WORKDIR "/src/src/App/Splash.Api"
RUN dotnet build "Splash.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Splash.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Splash.Api.dll"]
