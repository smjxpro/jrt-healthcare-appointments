# Architecture

The architecture of the project is based on the following components:

- [Healthcare.Appointments.API](../backend/Healthcare.Appointments/src/Healthcare.Appointments.API/)
- [Healthcare.Appointments.Domain](../backend/Healthcare.Appointments/src/Healthcare.Appointments.Domain/)
- [Healthcare.Appointments.Application](../backend/Healthcare.Appointments/src/Healthcare.Appointments.Application/)
- [Healthcare.Appointments.Infrastructure](../backend/Healthcare.Appointments/src/Healthcare.Appointments.Infrastructure/)

## Healthcare.Appointments.API

This project is the entry point of the application. It is responsible for handling the HTTP requests and responses. It uses the `Healthcare.Appointments.Application` project to process the requests and return the responses.

## Healthcare.Appointments.Domain

This project contains the domain model for the application. It is responsible for defining the entities and the relationships between them.

## Healthcare.Appointments.Application

This project contains the application logic for the application. It is responsible for processing the requests and returning the responses.

## Healthcare.Appointments.Infrastructure

This project contains the infrastructure for the application. It is responsible for connecting to the database and storing the data.