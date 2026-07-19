#!/bin/bash
set -e

# Crear roles necesarios para el backup (postgres y cruduser)
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" -d postgres <<-EOSQL
    DO \$\$
    BEGIN
        IF NOT EXISTS (SELECT FROM pg_roles WHERE rolname = 'postgres') THEN
            CREATE ROLE postgres WITH SUPERUSER LOGIN;
        END IF;
        IF NOT EXISTS (SELECT FROM pg_roles WHERE rolname = 'cruduser') THEN
            CREATE ROLE cruduser WITH SUPERUSER LOGIN;
        END IF;
    END
    \$\$;
EOSQL

# Crear base sakila si no existe
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" -d postgres <<-EOSQL
    SELECT 'CREATE DATABASE sakila'
    WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'sakila')\gexec
EOSQL

# Restaurar backup en sakila (ignorando errores de owners que ya existen)
psql -v ON_ERROR_STOP=0 --username "$POSTGRES_USER" -d sakila -f /docker-entrypoint-initdb.d/sakila_backup.sql
