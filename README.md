# LinuxAdminExamApi

Простое веб-приложение для зачёта по предмету «Администрирование ОС Linux».

Проект представляет собой ASP.NET Core Web API без подключения к базе данных. Данные хранятся в памяти приложения.

## Состав проекта

- 2 сущности модели:
  - `Book`
  - `Reader`
- 2 контроллера для моделей:
  - `BooksController`
  - `ReadersController`
- 1 контроллер для проверки сервиса:
  - `HealthController`

## Локальный запуск

```bash
dotnet restore
dotnet build
dotnet run
```

Приложение запускается по адресу:

```text
http://localhost:5000
```

## Проверка API

```bash
curl http://localhost:5000/api/health
curl http://localhost:5000/api/books
curl http://localhost:5000/api/readers
```

Создание книги:

```bash
curl -X POST http://localhost:5000/api/books \
  -H "Content-Type: application/json" \
  -d '{"title":"New Book","author":"Test Author","year":2024,"isAvailable":true}'
```

Создание читателя:

```bash
curl -X POST http://localhost:5000/api/readers \
  -H "Content-Type: application/json" \
  -d '{"fullName":"Test User","groupName":"IS-23","email":"test@example.com"}'
```
