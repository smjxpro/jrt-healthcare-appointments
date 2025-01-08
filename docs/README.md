# Documentation

## Get Started

### Prerequisites

- [dotnet 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [PostgreSQL](https://www.postgresql.org/download/) (If you want to run the application locally)
- [Docker](https://www.docker.com/) (If you want to run the application with Docker)

### Setup

1. Clone the repository: `git clone https://github.com/smjxpro/jrt-healthcare-appointments/.git`
2. Navigate to the project directory: `cd jrt-healthcare-appointments`

### Run the Application

1. Navigate to the `./backend/src/Healthcare.Appointments.API` directory: `cd src/Healthcare.Appointments.API`
2. Change the connection string in the `appsettings.json` or `appsettings.Development.json` file to match your database configuration
2. Run the command: `dotnet run`
3. Open the application: `http://localhost:5146`

### Run the Application with Docker
1. Run the script: `./scripts/docker.sh` and follow the instructions
2. Open the application: `http://localhost:7001`

## Architecture

See [ARCHITECTURE.md](./ARCHITECTURE.md)

## API Documentation

- [API Reference](http://localhost:5146/openapi/v1.json or http://localhost:7001/openapi/v1.json)
- [Swagger UI](http://localhost:5146/ or http://localhost:7001/)

## Usage

1. Register a user: `http://localhost:5146/user/register` or `http://localhost:7001/user/register` 
2. Login and obtain a token: `http://localhost:5146/user/login` or `http://localhost:7001/user/login`
3. Use the token to make authenticated requests to the API endpoints (e.g., `Bearer <token>`)
4. Get a list of doctors: `http://localhost:5146/doctor` or `http://localhost:7001/doctor`
5. Get a specific doctor by ID: `http://localhost:5146/doctor/{id}` or `http://localhost:7001/doctor/{id}`
6. Book an appointment: `http://localhost:5146/appointment/book` or `http://localhost:7001/appointment/book`
7. Get a list of appointments: `http://localhost:5146/appointment` or `http://localhost:7001/appointment`