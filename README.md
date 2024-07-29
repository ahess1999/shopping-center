## Shopping Center

### About

This is simple shopping center that utilizes Kafka in order to ensure purchased products get shipped after purchasing.

### Setup

#### DB

To setup the db we want to create a .env file at the root of the project. This is where you will add your DB credentials and DB name:

```
DB_USER=enter-username-here
DB_PASSWORD=enter-password-here
DB_NAME=enter-db-name-here
```

Next you will need to create a `appsettings.Development.json` file in all .Net projects and put your postgres connection string inside of there. To ensure that you are able to connect to the DB.

```json
{
  "ConnectionStrings": {
    "DatabaseConnection": "Host=host;Port=port;Database=database;User Id=user;Password=password;"
  }
}
```

### Running the project

To run the project follow the steps below.

1. `docker compose build`
2. `docker compose up`

Next you should be able to go to `http://localhost:5173` and start interacting with the project.

### Debugging in VSCode

Go to the `Run and Debug` tab and you should see a `Debug Api` run that and attach the debugger to `ShoppingCenter`.
This should start the debugger and ensure that you can debug all endpoints in the Api.
