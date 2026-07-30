# RealEstateApp - Real Estate Management System

**RealEstateApp** is a complete real estate management system developed with **ASP.NET Core 8** using **Onion Architecture**, offering a secure and robust solution for clients, agents, and administrators.

##  About the Project

This project is divided into two parts:

- **Web Application** (MVC + Identity): For clients, agents, and administrators.
- **RESTful API** (JWT Secured): For administrators and developers.

###  Roles

- **Administrator**
- **Agent**
- **Client**
- **Developer** (API access only)

---

##  Web Application Features

###  Authentication

- Role-based login (Client, Agent, Admin)
- Registration with activation logic (Email for Clients, Admin approval for Agents)
- Unauthorized access is redirected or blocked via `[Authorize]` filters

###  Public Home

- Lists all available properties (latest first)
- Filters by:
  - Property Type
  - Price Range
  - Number of Bedrooms / Bathrooms
  - Property Code search

###  Client Features

- Mark/unmark properties as favorites
- View agent details
- View list of favorite properties
- Session-based navigation menu

###  Agent Features

- Manage own properties (CRUD, with images)
- Edit profile information

###  Admin Features

- Dashboard with key statistics:
  - Users: Active / Inactive
- Full user management:
  - Agents
  - Admins
  - Developers
- Master data maintenance:
  - Property Types
  - Sales Types (e.g., Rent, Sale)
  - Property Improvements

---

##  API Features (JWT Protected)

Accessible only to **Admins and Developers**

- **Authentication with JWT**
- Account Management:
  - Login (JWT generation)
  - Register Developer
  - Register Admin (Admin-only access)
- Property Management (CRUD + filter by ID or Code)
- Agent Management (CRUD + get agent properties)
- Maintenance Endpoints:
  - Property Types
  - Sales Types
  - Improvements
- Role-based access enforcement with `[Authorize]` and JWT
- Responses include proper status codes (401 Unauthorized, 403 Forbidden, 204 No Content, etc.)

---

##  Technologies Used

- **ASP.NET Core 8**
- **Entity Framework Core (Code First)**
- **Identity** for WebApp authentication
- **JWT** for API authentication
- **CQRS** + **MediatR** pattern
- **AutoMapper** for DTO/ViewModel mapping
- **FluentValidation** for command/query validation (via Behaviors)
- **Swagger** for API documentation
- **Bootstrap** for UI
- **Onion Architecture**
- **Generic Repository & Service Pattern**

---

##  Project Images

### Public Home
![Public Home](https://github.com/Jaqz23/Real-Estate-App/blob/7bf88d5f5d1ffea496ca2b7cfd94a6b048138711/images/home.png)

### Property Details
![Property Details](https://github.com/Jaqz23/Real-Estate-App/blob/7bf88d5f5d1ffea496ca2b7cfd94a6b048138711/images/Property%20Detail.png)

### Client Home 
![Client Home](https://github.com/Jaqz23/Real-Estate-App/blob/7bf88d5f5d1ffea496ca2b7cfd94a6b048138711/images/client%20home.png)

### Agent Home 
![Agent Home](https://github.com/Jaqz23/Real-Estate-App/blob/7bf88d5f5d1ffea496ca2b7cfd94a6b048138711/images/agent%20home.png)

### Agent List
![Agent List](https://github.com/Jaqz23/Real-Estate-App/blob/7bf88d5f5d1ffea496ca2b7cfd94a6b048138711/images/agent%20list.png)

### Admin Dashboard
![Admin Dashboard](https://github.com/Jaqz23/Real-Estate-App/blob/7bf88d5f5d1ffea496ca2b7cfd94a6b048138711/images/Admin%20Dashboard.png)


##  Prerequisites

- Visual Studio 2022 or later
- ASP.NET Core 8
- SQL Server

---

### Installation
1. Clone the repository or download the project.
2. Open the project in Visual Studio.
3. Update the database connection string in `appsettings.json` to match your SQL Server setup.
4. Update the mail settings in `appsettings.json` with your SMTP server details for email functionalities:
   ```json
   "MailSettings": {
    "EmailFrom": "your-email@example.com",
    "SmtpHost": "smtp.gmail.com",
    "SmtpPort": 587,
    "SmtpUser": "your-email@example.com",
    "SmtpPass": "your-smtp-password",
    "DisplayName": "Social Network mail"
   }
5. Open **Package Manager Console**.

6. This solution contains **two DbContext classes**:

   - `ApplicationContext` (main application database)
   - `IdentityContext` (ASP.NET Core Identity)

   Run the migrations in the following order:

```powershell
Update-Database -Context ApplicationContext
```

```powershell
Update-Database -Context IdentityContext
```

7. Set the Web project as the startup project (if it is not already).

8. Run the application.
