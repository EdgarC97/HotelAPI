# Product and Order Management API

A RESTful API for managing products, categories, and orders in an e-commerce system.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the API](#running-the-api)
- [API Endpoints](#api-endpoints)
  - [Products](#products)
  - [Categories](#categories)
  - [Orders](#orders)
  - [Special Endpoints](#special-endpoints)
- [Authentication](#authentication)
- [Additional Considerations](#additional-considerations)

## Features

- CRUD operations for products, categories, and orders
- JWT authentication for sensitive endpoints
- Advanced search and filtering capabilities
- Stock management integrated with order creation
- Relationship management between products, categories, and orders

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- MySQL
- JWT for authentication
- Swagger for API documentation

## Getting Started

### Prerequisites

- [.NET SDK 8.0]
- [MySQL Server]
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/product-order-api.git
   cd product-order-api
   ```

2. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```


### Running the API

To start the API, run the following command:

```bash
dotnet run
```

The API will be available at `https://localhost:5007` by default.

## API Endpoints

### Products

- `GET /api/v1/products` - Retrieve all products
- `GET /api/v1/products/{id}` - Retrieve a specific product
- `POST /api/v1/products` - Create a new product
- `PUT /api/v1/products/{id}` - Update a product
- `DELETE /api/v1/products/{id}` - Delete a product

### Categories

- `GET /api/v1/categories` - Retrieve all categories
- `GET /api/v1/categories/{id}` - Retrieve a specific category
- `POST /api/v1/categories` - Create a new category
- `PUT /api/v1/categories/{id}` - Update a category
- `DELETE /api/v1/categories/{id}` - Delete a category

### Orders

- `GET /api/v1/orders` - Retrieve all orders
- `GET /api/v1/orders/{id}` - Retrieve a specific order
- `POST /api/v1/orders` - Create a new order
- `PUT /api/v1/orders/{id}` - Update an order
- `DELETE /api/v1/orders/{id}` - Delete an order

### Special Endpoints

- `GET /api/v1/products/search/{keyword}` - Search products by keyword
- `GET /api/v1/orders/customer/{customerName}` - Retrieve orders by customer name
- `GET /api/v1/products/low-stock` - List products with low stock
- `GET /api/v1/orders/date/{date}` - List orders on a specific date
- `GET /api/v1/categories/{id}/products` - List products in a specific category

## Authentication

JWT authentication is implemented to protect sensitive endpoints. Ensure you include the JWT token in the Authorization header for protected requests.

## Additional Considerations

- **Validation**: Input validation is implemented for all endpoints to ensure data integrity.
- **DTOs**: Data Transfer Objects are used to shape API responses and protect domain entities.
- **Swagger**: API documentation is available via Swagger at the `/swagger` endpoint.
- **Repository Pattern**: The project follows the repository pattern for better separation of concerns.
- **SOLID Principles**: The Single Responsibility Principle is applied throughout the project structure.

For more details on the endpoints and their parameters, please refer to the Swagger documentation available at `/swagger` when the API is running.