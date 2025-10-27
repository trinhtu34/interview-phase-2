# MS SQL Server Local Development

## Cách sử dụng

### 1. Chạy SQL Server
```bash
docker-compose up -d
```

### 2. Kết nối database
- **Server**: localhost,1433
- **Username**: sa
- **Password**: Password123!

### 3. Connection String cho .NET
```csharp
"Server=localhost,1433;Database=YourDatabase;User Id=sa;Password=Password123!;TrustServerCertificate=true;"
```

### 4. Tạo database mới
```sql
CREATE DATABASE YourDatabase;
```

### 5. Dừng SQL Server
```bash
docker-compose down
```

### 6. Xóa data (nếu cần reset)
```bash
docker-compose down -v
```

## Lưu ý
- Data được lưu trong Docker volume `mssql_data`
- Port 1433 được expose ra localhost
- Sử dụng SQL Server Express (miễn phí)