# BlazorAuth Project

This repository contains three projects aimed at learning about authentication and authorization in Blazor, as well as utilizing a minimal API in ASP.NET Core 8.

## Projects Overview

### 1. BlazorAuth.Api

**Purpose:**  
BlazorAuth.Api is a minimal API project built using ASP.NET Core 8. The primary purpose of this project is to demonstrate the creation and usage of a minimal API in ASP.NET Core. The API will serve as a backend service that the BlazorAuth.Client project interacts with.

**Key Features:**
- Implements basic API endpoints for authentication and authorization purposes.
- Provides a simple and lightweight backend for the BlazorAuth.Client project.

### 2. BlazorAuth.Client

**Purpose:**  
BlazorAuth.Client is a Blazor WebAssembly project designed to showcase authentication and authorization techniques within a Blazor application. This project communicates with the BlazorAuth.Api backend to perform authentication operations.

**Key Features:**
- Demonstrates user authentication and authorization using Blazor.
- Utilizes features like routing, components, and services in a Blazor WebAssembly app.
- Integrates with the BlazorAuth.Api to interact with the backend services.

### 3. BlazorAuth.Shared

**Purpose:**  
BlazorAuth.Shared is a class library shared between the BlazorAuth.Api and BlazorAuth.Client projects. It contains common data models, interfaces, and constants used by both the frontend and backend projects.

**Key Features:**
- Centralizes shared data structures and interfaces to ensure consistency across projects.
- Reduces duplication of code and definitions between the API and client.

## Getting Started

To get started with these projects, follow these steps:

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/BlazorAuth.git
2. **Navigate to Project Directories:**
   cd BlazorAuth.Api
   cd BlazorAuth.Client
3. **Restore Dependencies:**
   dotnet restore
4. **Run the Projects:**
    - For BlazorAuth.Api:
      dotnet run
      The API will start running at https://localhost:5010.
    - For BlazorAuth.Client:
      dotnet run
      Access the client application in your web browser at https://localhost:6010.

### Additional Notes
Ensure you have the necessary prerequisites installed for .NET 8 and Blazor development.
Customize and extend these projects as per your learning objectives regarding authentication and Blazor usage.
