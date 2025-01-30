# Project setup

## Start Containers

```sh
docker-compose up --build
```

## Run Migrations

If starting for the first time, run migrations after starting containers:

```sh
cd Api.Host
dotnet ef database update
```

