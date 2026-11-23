# EcommerceApp

## Web API and Swagger

The existing ASP.NET Core MVC application and Razor Pages remain available. A separate, read-only REST API is exposed under `/api/v1`.

When running in the Development environment, open `/swagger` to explore and test the API.

### Endpoints

| Method | Endpoint | Description |
| --- | --- | --- |
| GET | `/api/v1/products` | List products |
| GET | `/api/v1/products/{id}` | Get a product |
| GET | `/api/v1/categories` | List categories |
| GET | `/api/v1/categories/{id}` | Get a category |

The products list supports `page` (default `1`), `pageSize` (default `10`, maximum `50`) and optional `categoryId` query parameters.

Swagger UI is enabled only in the Development environment. The API currently exposes read-only product and category operations; the MVC application's existing workflows are unchanged.
