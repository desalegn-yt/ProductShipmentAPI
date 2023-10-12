Project Title: Product Shipment Management API 

Description:

This project is an API developed on .NET Core 6 that provides functionality for managing product shipments. It is designed to be integrated into existing systems or used as a standalone service. The API is built on the principles of RESTful architecture and includes features such as product management, payment integration with Stripe, and authentication using Auth0. The project utilizes PostgreSQL as the database for efficient data storage and retrieval.

Features:

  Product Management: The API allows clients to perform CRUD operations on products, including creating, updating, retrieving, and deleting product information.
  
  Shipment Management: Clients can track shipment details, update shipment status, and retrieve shipment information using the provided endpoints.
  
  Payment Integration: The API is integrated with Stripe to facilitate secure payment processing for product orders.
  
  Authentication and Authorization: Auth0 is implemented to handle user authentication and authorization, ensuring secure access to the API's endpoints.
  
  Database: PostgreSQL is used as the database management system to store and retrieve product and shipment data efficiently.

Usage:

Clone the repository: git clone https://github.com/desalegn-yt/ProductShipmentAPI.git

Install dependencies: dotnet restore

Set up PostgreSQL: Create a PostgreSQL database and update the connection string in the project's configuration files.

Set up Stripe: Obtain the necessary API keys from Stripe and update the configuration files with the appropriate values.

Set up Auth0: Create an Auth0 account, obtain the client ID and secret, and configure the respective settings in the project.

Build and run the API: dotnet run

API Documentation:

The API documentation is provided using Swagger, which offers a user-friendly interface to explore the available endpoints, input parameters, and expected responses. After running the API, navigate to http://localhost:<port>/swagger to access the Swagger documentation.

Contributing:

This project serves as a showcase of my coding skills and is not currently open for contributions. However, feedback and suggestions for improvement are welcome.
