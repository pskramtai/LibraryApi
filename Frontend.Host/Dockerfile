FROM nginx AS base

USER $APP_UID
WORKDIR /app
EXPOSE 5295
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Frontend.Host/Frontend.Host.csproj", "Frontend.Host/"]
RUN dotnet restore "Frontend.Host/Frontend.Host.csproj"
COPY . .
WORKDIR "/src/Frontend.Host"
RUN dotnet build "Frontend.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Frontend.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Frontend.Host/nginx.conf /etc/nginx/nginx.conf
ENV ASPNETCORE_URLS=http://0.0.0.0:5295