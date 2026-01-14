# 💼 ServiceCompany

ServiceCompany is a full-stack ASP.NET MVC web application designed for **service providers and customers** to interact on a single platform.  
Providers can list services, and users can discover, book, add to cart, and pay for services seamlessly.

---

## 📌 Project Purpose

The goal of this project is to simulate a **real-world service booking system** where:

- Service providers manage their offerings
- Users browse and book services
- Orders are tracked with payment flow
- The system follows clean MVC architecture

---

## 🧑‍💼 User Roles

### 👤 Service Provider
- Add new services
- Manage availability
- View bookings for their services

### 👥 Customer / User
- Browse available services
- View service details
- Add services to cart
- Book services
- Make payments
- Track booking status

---

## ⭐ Core Features

### 🔹 Service Management
- Provider can **add, edit, and delete services**
- Services include:
  - Service Name
  - Description
  - Price
  - Duration
  - Category
  - Location
  - Availability

---

### 🔹 Service Browsing
- Users can:
  - View all available services
  - Filter services by category or location
  - View detailed service information

---

### 🛒 Cart System
- Users can:
  - Add services to cart
  - Remove services from cart
  - View cart summary
  - Proceed to checkout

---

### 📅 Booking System
- Users can:
  - Select service date & time slot
  - Confirm booking
- Booking status includes:
  - Pending
  - Accepted
  - Rejected
  - Completed

---

### 💳 Payment Handling
- Supports payment methods like:
  - UPI
  - Card
  - Cash on Delivery
- Payment status tracked per booking

---

### 📦 Order Management
- Users can:
  - View booking history
  - Check payment status
- Providers can:
  - Accept or reject bookings
  - Mark services as completed

---

## 🧱 Application Architecture

- **MVC Pattern**
  - Model → Business & data logic
  - View → UI (Razor Pages)
  - Controller → Request handling
- **Separation of concerns**
- **Entity Framework Migrations**

---

## 🛠 Technology Stack

- **Backend:** ASP.NET MVC (C#)
- **Frontend:** HTML, CSS, Razor Views
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Configuration:** JSON

---

## ▶️ How to Run the Project

1. Clone the repository
  
2. Open the solution in **Visual Studio**

3. Restore NuGet packages

4. Configure database connection in:

5. Apply migrations and run the project

---

## 🔐 Authentication (Planned / Extendable)

- User login & registration
- Role-based access (Provider / User)
- Secure booking flow

---

## 📄 Notes

- This project is built for real-world scalability.
- Features can be extended with APIs, dashboards, and payment gateways.
- UI and backend logic are kept modular for easy enhancement.

---

