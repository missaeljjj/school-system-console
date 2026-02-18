# School System Console

Academic school management system built with C# and PostgreSQL.

## Features
- Student management
- Teacher management
- Data validation
- Console menu navigation
- PostgreSQL database connection

## Technologies
- C#
- .NET
- PostgreSQL

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
├── Base de datos
│   └── PgSql.cs
├── Datos
│   └── Datos.cs
├── Extra
│   ├── Menu.cs
│   ├── Utiles.cs
│   └── Validacion.cs
├── Gestion
│   ├── Agregar.cs
│   └── Mostrar.cs
├── Menus
│   ├── Consultas.cs
│   ├── Elecciones.cs
│   ├── GestionMenuEstudiantes.cs
│   └── MenuGestionMaestroscs.cs
└── Program.cs
```

## Status
Project created for learning purposes. Future versions will include:
- Grade history system
- Improved database design
- Graphical interface

## Author
Missael — Systems Engineering Student from Nicaragua 
