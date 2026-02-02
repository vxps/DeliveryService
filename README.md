- ASP.NET 9 
- ASP.NET MVC 
- Entity Framework
- Postgresql

1. Запуск контейнера

   docker compose up -d

3. Восстановление зависимостей nuget

   dotnet restore

5. Применение миграций к бд

   dotnet ef migrations add InitialCreate

   dotnet ef database update

7. Запуск через терминал

   dotnet run

Приложение будет доступно по адресу: http://localhost:5299/Order
