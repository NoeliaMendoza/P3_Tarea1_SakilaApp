# Respaldo de Base de Datos - SakilaApp

## Descripción breve

Desarrollar una integración completa de las funcionalidades nativas de ASP.NET Core Identity dentro del proyecto desarrollado durante las clases. La implementación debe demostrar cómo trabajan juntas múltiples tecnologías, incluyendo Google Authentication, confirmación de correo electrónico, recuperación de contraseña, autenticación multifactor (MFA), roles de usuario y rutas protegidas.

## Objetivo general

Integrar múltiples tecnologías de autenticación y seguridad en la aplicación ASP.NET Core MVC, demostrando la interacción entre:

- Identity
- Google OAuth
- Gmail SMTP
- Entity Framework Core
- PostgreSQL
- Mecanismos de seguridad nativos

## Cómo se generó el respaldo

El respaldo se generó utilizando `pg_dump` con el siguiente comando:

```bash
pg_dump -U cruduser -d sakila --clean --if-exists -f sakila_backup.sql
```

## Cómo restaurar

```bash
psql -U postgres -c "CREATE DATABASE sakila;"
psql -U postgres -d sakila -f sakila_backup.sql
```

O bien:

```bash
createdb -U postgres sakila
psql -U postgres -d sakila -f sakila_backup.sql
```

## Tablas de Identity incluidas

El respaldo contiene las tablas del sistema ASP.NET Core Identity almacenadas en PostgreSQL:

- `AspNetUsers` - Usuarios registrados
- `AspNetRoles` - Roles definidos (Administrador, Supervisor, Operador, Consulta)
- `AspNetUserRoles` - Asignación de roles a usuarios
- `AspNetUserClaims` - Claims de usuarios
- `AspNetRoleClaims` - Claims de roles
- `AspNetUserLogins` - Inicios de sesión externos (Google OAuth)
- `AspNetUserTokens` - Tokens de autenticación (MFA, recuperación)
- `AspNetUserSessions` - Sesiones de usuario
- `__EFMigrationsHistory` - Historial de migraciones de Entity Framework Core

## Archivos

| Archivo | Descripción |
|---|---|
| `sakila_backup.sql` | Respaldo completo de la base de datos Sakila (formato SQL) |
