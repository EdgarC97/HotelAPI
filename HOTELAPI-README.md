# Hotel API

A RESTful API for managing hotel operations, including bookings, guests, employees, and room types.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the API](#running-the-api)
- [API Endpoints](#api-endpoints)
  - [Authentication](#authentication)
  - [Guests](#guests)
  - [Rooms](#rooms)
  - [Bookings](#bookings)

## Features

- User authentication with JWT
- CRUD operations for guests, rooms, and bookings
- Room availability checking
- Easy integration with MySQL database

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- MySQL
- JWT for authentication
- Swagger for API documentation

## Getting Started

### Prerequisites

- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/hotel-api.git
   cd hotel-api
2.Restore the NuGet packages:
  
  dotnet restore

## Configuration
Create a .env file in the root directory with the following environment variables:
DB_HOST=your_database_host
DB_PORT=your_database_port
DB_DATABASE=your_database_name
DB_USERNAME=your_database_username
DB_PASSWORD=your_database_password
JWT_ISSUER=your_jwt_issuer
JWT_AUDIENCE=your_jwt_audience
JWT_KEY=your_jwt_secret_key


API Endpoints
Authentication
POST /api/v1/auth/register - Register a new employee.
POST /api/v1/auth/login - Log in an employee and retrieve a JWT token.
Guests
GET /api/v1/guests - Retrieve all guests.
GET /api/v1/guests/{id} - Retrieve a guest by ID.
DELETE /api/v1/guests/{id} - Delete a guest by ID.
Rooms
GET /api/v1/rooms - Retrieve all rooms.
GET /api/v1/rooms/available - Retrieve available rooms.
GET /api/v1/rooms/{id} - Retrieve a room by ID.
Bookings
POST /api/v1/bookings - Create a new booking.
GET /api/v1/bookings/{id} - Retrieve a booking by ID.
DELETE /api/v1/bookings/{id} - Delete a booking by ID.
