# Online Space RPG

## Requirements

- nodejs
- Unity
- C# mono
- psql

## Set up

- cd to server dir and install the dependency: `npm install`
- create a `rpg_future` table in postgress
- update the server/knexfile.js file with psql username and password

```
connection: {
      database: 'rpg_future',
      user: 'your psql user name',
      password: 'psql password',
    },
```

- run the migrations to create the db structure `knex migrate:latest`

## Starting the game

Start the backend server

```
cd backend
npm install
node index.js
```

Open the unity project in the game dir and press start
