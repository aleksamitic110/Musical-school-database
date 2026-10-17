# Musical School Database

A team project for the Database Systems course at the Faculty of Electronic Engineering, University of Niš. It models the information system of a music school (students, guardians, teachers, courses, classes, exams and exam boards) in three stages.

## Stages

1. **Data model and database:** EER and relational model, and SQL scripts that create and populate the Oracle database (`1. Projekat/`)
2. **Desktop application:** a Windows Forms app (.NET Framework 4.8) for managing the data, using NHibernate with Fluent NHibernate mappings and DTOs (`2. Projekat/`)
3. **Web API:** an ASP.NET Core (.NET 8) REST API over the same data model, with one controller per entity and Swagger documentation (`3. Projekat/`)

`Njihov primer/` contains the example project provided with the course.

## Tech stack

- C#, Windows Forms, ASP.NET Core
- NHibernate, Fluent NHibernate
- Oracle Database

## Note

The applications connect to the faculty's Oracle server, so they can't be run as-is outside the faculty network. The SQL scripts in `1. Projekat/` can be used to recreate the schema on another Oracle instance.
