# Documentation

## Get Started

### Prerequisites

- [Docker](https://www.docker.com/)
- [dotnet 9](https://dotnet.microsoft.com/en-us/download/dotnet/9)

### Setup

1. Clone the repository: `git clone https://github.com/smjxpro/healthcare-appointment.git`
2. Navigate to the project directory: `cd healthcare-appointment`
3. Run the script: `./scripts/docker.sh` and follow the instructions
4. Open the application: `http://localhost:7001`

## Architecture

See [ARCHITECTURE.md](./ARCHITECTURE.md)

## API Documentation

- [API Reference](http://localhost:7001/openapi/v1.json)
- [Swagger UI](http://localhost:7001/)

## Usage

1. Register a user: `http://localhost:7001/user/register`
2. Login and obtain a token: `http://localhost:7001/user/login`
3. Use the token to make authenticated requests to the API endpoints (e.g., `Bearer <token>`)
4. Get a list of doctors: `http://localhost:7001/doctor`
5. Get a specific doctor by ID: `http://localhost:7001/doctor/{id}`
6. Book an appointment: `http://localhost:7001/appointment/book`
7. Get a list of appointments: `http://localhost:7001/appointment`