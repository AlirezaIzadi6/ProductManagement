## Project overview
This is an ASP.NET Core Web API project written with Clean architecture, CQRS and mediator patterns. This is to demonstrate and also to build up my experience with using these patterns.
## Tools
* Database: MSSQL for development and in-memory database for testing.
* ORM: EF Core 8.0
* Containerization: Docker & Docker Compose.
* Other tools:
  - AutoMapper to map the data types between layers.
  - FluentValidation to validate client request data.
  - MediatR to deliver requests to application layer.
## Prerequisites
This project requires the following prerequisites:

* [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)
* [Docker Desktop](https://www.docker.com/products/docker-desktop) (Optional, if you want to run the project via Docker).
## Setup the project
There are currently two ways to run the project:
1. Running in development environment with Visual Studio or other tools.
2. Using Docker to run (DockerDevelopment environment).
### Running in development environment
To run tests in this mode, you must copy JSON data files at "tests/UnitTests/Fixtures/SeedData/" to "FunctionalTests/bin/Debug/net8.0/Data/" directory.
### Using Docker
You must create an https certificate to use with docker.
If you do not have dev-certs installed, install it using this command:
```
dotnet install -g dev-certs
```
then to create the certificate file, move to project's root directory and enter this command:
```
dotnet dev-certs https -ep ./web.pfx -p <your-password>
```
Note that if you enter a different password than "Test123@" in the command above, you must change this line in the docker-compose.yml file and insert your password to make it work:
```
      - ASPNETCORE_Kestrel__Certificates__Default__Password=Test123@
```
Then you can run project with this command in project's root directory:
```
docker-compose up --build
```
If this is the first time and you don't have necessary docker images (especially SqlServer) previously installed, it takes several minutes to download and build images.
## Testing
### Automated tests
To run the tests, run this command:
```
dotnet test
```
### Manual
To manually test endpoints, you can use Swagger UI at "https://localhost:8001/swagger/index.html".
