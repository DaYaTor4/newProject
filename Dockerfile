# Используем базовый образ для ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Используем образ для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Копируем файлы проекта
COPY ["SoftwareStoreAPI.csproj", "./"]
RUN dotnet restore "./SoftwareStoreAPI.csproj"

# Копируем все файлы проекта
COPY . .
WORKDIR "/src/."

# Собираем проект
RUN dotnet build "SoftwareStoreAPI.csproj" -c Release -o /app/build

# Публикуем проект
FROM build AS publish
RUN dotnet publish "SoftwareStoreAPI.csproj" -c Release -o /app/publish

# Создаём финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoftwareStoreAPI.dll"]
