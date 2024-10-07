CRUD API для управления сотрудниками
API для управления данными сотрудников, разработанное с использованием .NET 8, Entity Framework Core (EF Core) и Dapper. API взаимодействует с базой данных PostgreSQL и использует асинхронное программирование.

Используемые технологии
.NET 8 (ASP.NET Core Web API)
Entity Framework Core для операций создания, обновления и удаления
Dapper для выполнения SELECT-запросов
PostgreSQL
Внедрение зависимостей (Dependency Injection)
Fluent API для конфигурации EF Core
Middleware
Паттерн MVC
API Conventions и Model Binding
Структура базы данных

Таблица Employees содержит следующие поля:
Id (UUID) - первичный ключ
FirstName (VARCHAR 100) - имя сотрудника
LastName (VARCHAR 100) - фамилия сотрудника
Email (VARCHAR 255) - уникальный email
Phone (VARCHAR 20) - телефон (минимум 10 символов)
DateOfBirth (DATE) - дата рождения
HireDate (DATE) - дата найма
Position (VARCHAR 100) - должность
Salary (DECIMAL 18, 2) - зарплата
DepartmentId (UUID) - идентификатор департамента (внешний ключ)
ManagerId (UUID) - идентификатор руководителя (nullable, внешний ключ)
IsActive (BOOLEAN) - активность (по умолчанию TRUE)
Address (VARCHAR 255) - адрес
City (VARCHAR 100) - город
Country (VARCHAR 100) - страна
CreatedAt (TIMESTAMP) - дата создания
UpdatedAt (TIMESTAMP) - дата обновления

Маршруты API:
GET Запросы
Получить всех сотрудников: GET /api/employees
Получить сотрудника по Id: GET /api/employees/{id}
Получить сотрудников по статусу активности: GET /api/employees?isActive={isActive}
Получить сотрудников по департаменту: GET /api/employees/department/{departmentId}
Получить статистику по зарплатам: GET /api/employees/salary-statistics
Получить сотрудников, рожденных в определенный период: GET /api/employees/birthdays?startDate={startDate}&endDate={endDate}

CRUD Операции:
Create: Добавление нового сотрудника.
Read: Получение информации о сотрудниках.
Update: Обновление данных сотрудника.
Delete: Удаление сотрудника.

Настройка проекта:
Склонируйте репозиторий.
Настройте PostgreSQL и обновите строку подключения.
Выполните миграции для создания схемы базы данных.

Асинхронное программирование
Все методы API реализованы с использованием async/await для повышения производительности.

Репозиторий GitHub
git clone  https://github.com/rustamovy9/Employee_Managment.git
