# SakilaApp - ASP.NET Core MVC con PostgreSQL

Aplicación web ASP.NET Core 10 MVC para la gestión de la base de datos **Sakila** (tienda de alquiler de DVDs) con autenticación de usuarios mediante ASP.NET Core Identity y roles de autorización.

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL](https://www.postgresql.org/download/) (14 o superior)
- Base de datos **Sakila** para PostgreSQL

## Configuración de la base de datos

1. **Restaurar la base de datos Sakila:**
   ```bash
   psql -U postgres -c "CREATE DATABASE sakila;"
   psql -U postgres -d sakila -f Database/sakila_backup.sql
   ```

2. **Crear el usuario de la aplicación:**
   ```bash
   psql -U postgres -c "CREATE USER cruduser WITH PASSWORD 'crud123';"
   psql -U postgres -c "GRANT ALL PRIVILEGES ON DATABASE sakila TO cruduser;"
   psql -U postgres -d sakila -c "GRANT ALL ON SCHEMA public TO cruduser;"
   ```

3. **Configurar credenciales (elige una opcion):**

   **Opcion A - Copiar el archivo de ejemplo:**
   ```bash
   cd SakilaApp
   cp appsettings.example.json appsettings.json
   ```
   Luego edita `appsettings.json` con tus credenciales reales.

   **Opcion B - User Secrets (recomendado):**
   ```bash
   cd SakilaApp
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=sakila;Username=cruduser;Password=crud123"
   dotnet user-secrets set "ConnectionStrings:IdentityConnection" "Host=localhost;Port=5432;Database=sakila;Username=cruduser;Password=crud123"
   ```

4. **Aplicar migraciones de Identity:**
   ```bash
   cd SakilaApp
   dotnet ef database update --context ApplicationDbContext
   ```

## Ejecución

```bash
cd SakilaApp
dotnet run
```

La aplicación estará disponible en:
- HTTP: `http://localhost:5164`
- HTTPS: `https://localhost:7063`

## Usuarios predefinidos

| Email | Contraseña | Rol |
|---|---|---|
| admin@espe.edu.ec | Admin123! | Administrador |
| supervisor@espe.edu.ec | Super123! | Supervisor |
| operador@espe.edu.ec | Operador123! | Operador |
| consulta@espe.edu.ec | Consulta123! | Consulta |

## Roles y permisos

| Controlador | Ver (Lectura) | Crear | Editar | Eliminar |
|---|---|---|---|---|
| Actores | Autenticados | Admin, Operador | Admin | Admin |
| Películas | Autenticados | Admin, Supervisor | Admin, Supervisor | Admin |
| Categorías | Autenticados | Admin, Supervisor | Admin | Admin |
| Idiomas | Autenticados | Admin | Admin | Admin |
| Film-Actores | Autenticados | Admin, Supervisor | Admin, Supervisor | Admin |
| Film-Categorías | Autenticados | Admin, Supervisor | Admin, Supervisor | Admin |
| Panel Admin | - | Solo Administrador | - | - |

## Características

- CRUD completo para Actores, Películas, Categorías, Idiomas y relaciones
- Autenticación con ASP.NET Core Identity
- Autorización basada en roles (4 niveles)
- Inicio de sesión con Google OAuth
- Confirmación de email con Gmail SMTP
- Bootstrap 5 para interfaz responsive
- Base de datos Sakila (PostgreSQL)

## Estructura del proyecto

```
SakilaApp/
  Controllers/     # Controladores MVC
  Models/          # Entidades de EF Core
  Views/           # Vistas Razor
  Data/            # DbContext, migraciones, seed de datos
  Services/        # Servicios (email)
  Settings/        # Configuración (email)
  wwwroot/         # Archivos estáticos (CSS, JS, libs)
```

## Base de datos

El respaldo de la base de datos se encuentra en `Database/sakila_backup.sql`.  
Ver `Database/README.md` para más detalles.
