# Magicfy

A minimal ASP.NET Core web application.

## Project Structure

- `Magicfy.Web` - ASP.NET Core minimal web application

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Docker (optional)

### Running locally

```bash
# Build the solution
dotnet build

# Run the web application
dotnet run --project Magicfy.Web
```

The application will be available at:

- HTTP: <http://localhost:5000>
- HTTPS: <https://localhost:5001>

### Endpoints

- `GET /` - Returns "Hello World from Magicfy.Web!"
- `GET /api/hello` - Returns JSON with message, application name, and timestamp

### Docker

```bash
# Build the Docker image
cd Magicfy.Web
docker build -t magicfy-web .

# Run the container
docker run -p 5000:8080 magicfy-web
```

The application will be available at:

- HTTP: <http://localhost:5000>
