# Rajasthan Royals E-Commerce Backend

This is the backend system for the Rajasthan Royals e-commerce platform. It powers product listings, cart management, order placement, and user interactions using a combination of **ASP.NET Core Web API**, **MongoDB**, and **SQL Server**.

---

##  Tech Stack

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **SQL Server** – for user authentication and relational data
- **MongoDB** – for inventory, product, and order storage
- **Swagger** – for API testing/documentation

---

##  Features

- ✅ Get all products, product details
- ✅ Manage inventory and product categories
- ✅ Cart (Add / Remove / Clear items)
- ✅ Place orders with total amount and payment method
- ✅ Order history by user
- ✅ Search by product name and category
- ✅ API-first backend (clean RESTful endpoints)

---

##  Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/)
- [MongoDB](https://www.mongodb.com/) (Local or Atlas)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Postman or Swagger for API testing

---
## Setup Instructions
1. Clone the repo
2. Update your MongoDB and SQL connection strings in `appsettings.json`
3. Make sure instance of SQL Sever and Mongo are both running.
4. Run the project using:
```bash
dotnet run

## 📂 Project Structure
Controllers/ # API controllers
 Models/ # Entity and DTO classes
 Services/ # Business logic
 Data/ # MongoDB and EF DBContext
 appsettings.json # Configuration (connection strings, etc.)
Program.cs # Main application entry


👤 Author
Kanishk Gupta
