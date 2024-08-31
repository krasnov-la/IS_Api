# Апи системы учета достижений КБ ДВФУ.
ASP.NET апи, разработанное с использованием принципов DDD и Clean Architecture, а также ORM Entity Framework Core и БД PostgreSQL.
# Развертка (Все файлы указаны относительно папки IS_Api, все команды выполнять из нее же)
## В контейнере:

1. Добавить файл `dotnet_secrets.json` вида:

```
    {
    "ConnectionStrings" :
    {
        "Postgre" : "<Строка подключения Postgre>"
    },
    "JwtOptions" : 
    {
        "Key" : "<Как минимум 32 символьная строка>",
        "Issuer" : "<Издатель Jwt токена>",
        "Audience" : "<Получатель Jwt токена>"
    },
    "AllowedOrigins": [
        <Разрешенные для CORS источники>
      ]
}
```

2. Добавить файл `Database/dbpassword.txt` вида (Пароль здесь должен совпадать с указанным в ConnectionStrings:Postgre):

```
    <Пароль БД>
```

4. Выполнить `docker compose up`, по умолчанию api будет работать на 5001 порте.

## Вне контейнера

1. Добавить файл `dotnet_secrets.json` как при развертке в контейнере, с соответствующей строкой подключения БД. 

2. Инициализировать и заполнить хранилище секретов dotnet
2.1 `dotnet user-secrets init --project Api\`
2.2 Linux / MacOS : `cat ./dotnet_secrets.json | dotnet user-secrets set`
2.3 Windows : `type ./dotnet_secrets.json | dotnet user-secrets set`

3. Выполнить `dotnet ef database update`
   
5. Выполнить `dotnet run`, api будет работать на 5114 порте
