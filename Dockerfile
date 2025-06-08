# Этап 1: Сборка
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем остальной код
COPY . ./

# Публикация (сборка проекта в релизе)
RUN dotnet publish -c Release -o /app/publish

# Этап 2: Рантайм
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Запуск DLL
ENTRYPOINT ["dotnet", "AllergyBotBotNew.dll"]
