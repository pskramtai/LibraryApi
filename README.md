# Project setup

## Start Containers

```sh
docker-compose up --build
```

## Run Migrations

If starting for the first time, run migrations after starting containers:

```sh
cd Api.Host
dotnet ef database update --connection "Host=localhost;Port=5433;Database=main;Username=postgres;Password=postgres"
```

## Run Migrations

PostgreSQL is exposed on 5433 port in Docker container (as opposed to default 5432 port) to avoid conflicts with locally hosted db.
