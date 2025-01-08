FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Healthcare.Appointments.API/Healthcare.Appointments.API.csproj", "src/Healthcare.Appointments.API/"]
COPY ["src/Healthcare.Appointments.Application/Healthcare.Appointments.Application.csproj", "src/Healthcare.Appointments.Application/"]
COPY ["src/Healthcare.Appointments.Domain/Healthcare.Appointments.Domain.csproj", "src/Healthcare.Appointments.Domain/"]
COPY ["src/Healthcare.Appointments.Infrastructure/Healthcare.Appointments.Infrastructure.csproj", "src/Healthcare.Appointments.Infrastructure/"]
RUN dotnet restore "src/Healthcare.Appointments.API/Healthcare.Appointments.API.csproj"
COPY . .
WORKDIR "/src/src/Healthcare.Appointments.API"
RUN dotnet build "Healthcare.Appointments.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Healthcare.Appointments.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Healthcare.Appointments.API.dll"]
