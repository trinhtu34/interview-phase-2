#!/bin/bash

echo "🚀 Starting SQL Server..."
docker-compose up -d

echo "⏳ Waiting 30 seconds for SQL Server to start..."
sleep 30

echo "📝 Running database initialization..."
docker exec -i mssql-local /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Password123! < ./init-scripts/01-create-database.sql

echo "✅ Done! Database is ready at localhost:1433"