#!/bin/bash
# Script para generar el backup de la base de datos Sakila
# Requiere PostgreSQL instalado y pg_dump en el PATH

echo "Generando backup de la base de datos sakila..."

pg_dump -U postgres -d sakila --clean --if-exists --format=custom -f sakila_backup.backup

echo "Backup generado: sakila_backup.backup"
echo ""
echo "Para restaurar:"
echo "pg_restore -U postgres -d sakila --clean --if-exists sakila_backup.backup"
