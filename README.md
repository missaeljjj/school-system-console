# School System Console -> In development

Console-based academic management system designed with layered architecture principles using C# and PostgreSQL.

## Features
* Student management
  - Add students
  - Show students
  - Search by grade and section
  - Search by name or student ID
- Teacher management
- Data validation
- Console menu navigation
- PostgreSQL database connection

## Technologies
- C#
- .NET
- PostgreSQL

## Architecture
This project follows a layered architecture:

UI + Logic → Interface → Repository → Database

This separation improves:
- Scalability
- Maintainability
- Testability

## Setup
Before running the project, configure your database credentials in:

Base de datos/PgSql.cs

Replace:
- host
- user
- password
- database name

## Run
Compile and run from Visual Studio or using CLI:

```bash
dotnet run
```

## Project Structure
```
SCHOOL-MANAGEMENT-v0.1
│
├── Aplicaciones
│   └── Interfaces.cs
├── Base de datos
│   ├── PgSql.cs
│   └── ComandoSql.cs
├── Entidades
│   ├── Estudiante.cs
│   ├── Maestros.cs
│   └── Usuario.cs
├── Extra
│   ├── Menu.cs
│   ├── Utiles.cs
│   └── Validacion.cs
├── Gestion
│   ├── Busqueda
│   │   └── Buscar
│   ├── Agregar.cs
│   └── Mostrar.cs
├── Infraestructura
│   ├── RepositorioOperaciones.cs
│   └── Repositorios.cs
├── Menus
│   ├── Consultas.cs
│   ├── Elecciones.cs
│   ├── GestionMenuEstudiantes.cs
│   ├── MenuBusqueda.cs
│   └── MenuGestionMaestros.cs
├── GlobalUsing.cs
└── Program.cs
```

## Status
Project created for learning purposes. Future versions will include:
- Grade history system
- Improved database design
- Dependency Injection container
- Logging system
- Graphical interface

## Author
Missael — Systems Engineering Student from Nicaragua
