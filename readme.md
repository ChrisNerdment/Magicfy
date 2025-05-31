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

## CI/CD Pipeline

This project uses GitHub Actions to automatically build and push Docker images to GitHub Container Registry (ghcr.io).

### Automatic Builds

- **On Push to main/master**: Builds and pushes image with `latest` tag
- **On Tags**: Builds and pushes image with semantic version tags (e.g., `v1.0.0`)
- **On Pull Requests**: Builds image for testing (no push to registry)

### Docker Registry

The Docker images are automatically published to:

```
ghcr.io/your-username/magicfy/magicfy-web:latest
```

### Pull and Run from Registry

```bash
# Pull from GitHub Container Registry
docker pull ghcr.io/your-username/magicfy/magicfy-web:latest

# Run the pulled image
docker run -p 5000:8080 ghcr.io/your-username/magicfy/magicfy-web:latest
```

### Setup

No additional setup required! The workflow uses the automatic `GITHUB_TOKEN` with the necessary permissions.
