# 👥 Customer Management System

Hệ thống quản lý khách hàng được xây dựng với Clean Architecture và CQRS pattern, sử dụng ASP.NET Core 8.0.

## 🎯 Tổng quan

Hệ thống quản lý khách hàng cung cấp các chức năng CRUD cơ bản:
- ✅ Xem danh sách khách hàng
- ✅ Thêm khách hàng mới
- ✅ Cập nhật thông tin khách hàng
- ✅ Xóa khách hàng

## 🌐 Link demo sản phẩm 

🔗 Link demo tại : http://54.251.211.116/

## 📁 Cây thư mục

```
interview-phase-2/
├── Main_Project/
│   ├── Customer_Management_Backend/          # Backend API
│   │   ├── Domain/                          # Domain Layer
│   │   │   ├── Entities/                    # Domain Entities
│   │   │   ├── Repositories/                # Repository Interfaces
│   │   │   └── Common/                      # Base Classes
│   │   ├── Application/                     # Application Layer
│   │   │   ├── Feature/Customer/            # CQRS Features
│   │   │   │   ├── Commands/                # Command Handlers
│   │   │   │   └── Queries/                 # Query Handlers
│   │   │   ├── DTOs/                        # Data Transfer Objects
│   │   │   └── Common/                      # Common Interfaces
│   │   ├── Infrastructure/                  # Infrastructure Layer
│   │   │   ├── Data/                        # DbContext
│   │   │   └── Repositories/                # Repository Implementations
│   │   ├── Presentation/                    # Presentation Layer
│   │   │   ├── Controllers/                 # API Controllers
│   │   │   ├── Program.cs                   # Application Entry Point
│   │   │   └── .env                         # Environment Variables
│   │   └── Dockerfile                       # Docker Configuration
│   ├── Customer_Management_Frontend/        # Frontend MVC
│   │   └── Customer_Management_Frontend/
│   │       ├── Controllers/                 # MVC Controllers
│   │       ├── Views/Customer/              # Razor Views
│   │       ├── Models/                      # View Models
│   │       ├── Services/                    # HTTP Services
│   │       ├── wwwroot/                     # Static Files
│   │       ├── Program.cs                   # Application Entry Point
│   │       └── .env                         # Environment Variables
│   ├── docker-compose.yaml                 # Docker Compose Configuration
│   └── README.md                           # Project Documentation
└── Setup-db-to-running-on-local/          # Database Setup Scripts
    ├── docker-compose.yml                  # Local Database Setup
    ├── init-scripts/                       # Database Initialization
    └── .env                                # Database Environment Variables
```

## 🚀 Cài đặt và chạy thử ở local

### 📋 Yêu cầu hệ thống
- 🔧 .NET 8.0 SDK
- 🐳 Docker & Docker Compose
- 🗄️ SQL Server ở local hoặc có thể dùng SQL Server chạy trên Docker hoặc AWS RDS 

### 🐳 Chạy với Docker Compose

1. **📥 Clone repository**
   ```bash
   git clone https://github.com/trinhtu34/interview-phase-2.git
   cd interview-phase-2/Main_Project
   ```
2. **🗄️ Khởi tạo SQL Server với Docker compose**
- 📝 Tạo file .env nằm tại vị trí : `interview-phase-2/Setup-db-to-running-on-local`
- 📄 Nội dung : 
```bash
ACCEPT_EULA=Y
SA_PASSWORD=Password123!
MSSQL_PID=Express
MSSQL_PORT=1433
```

3. **⚙️ Cấu hình environment variables**

🔧 **Tạo .env cho Backend** : 
- 📍 Vị trí nằm tại : `interview-phase-2/Main_Project/Customer_Management_Backend/Presentation`
- 📄 Nội dung : 
```bash
DefaultConnection=Server=localhost;Database=customerdb;User Id=sa;Password=Password123!;TrustServerCertificate=true
```

🎨 **Tạo .env cho Frontend** :
- 📍 Vị trí nằm tại : `interview-phase-2/Main_Project/Customer_Management_Frontend/Customer_Management_Frontend`
- 📄 Nội dung : 
```bash
API_BASE_URL=http://backend:8080/api
```

4. **🔨 Build và chạy**

📍 Đảm bảo vị trí của bạn nằm tại : `interview-phase-2/Main_Project`

   ```bash
   # 🔨 Build images
   cd Customer_Management_Backend
   docker build -t crm-backend-img -f Dockerfile .
   cd ..
   cd Customer_Management_Frontend
   docker build -t crm-frontend-img -f Dockerfile .
   cd ..
   # 🚀 Chạy containers
   docker compose up -d
   ```

5. **🌐 Truy cập ứng dụng**
   - 🎨 Frontend: http://localhost:3000
   - 🔧 Backend API: http://localhost:5000/api/Customer

## 📚 API Documentation

### 🌐 Base URL
```
http://localhost:5000/api
```

### 🔗 Endpoints

| Method | Endpoint | Description | Request Body |
|--------|----------|-------------|--------------|
| 📋 GET    | `/Customer` | Lấy danh sách khách hàng | - |
| ➕ POST   | `/Customer` | Tạo khách hàng mới | CreateCustomerDTO |
| ✏️ PUT    | `/Customer/{id}` | Cập nhật khách hàng | UpdateCustomerDTO |
| 🗑️ DELETE | `/Customer/{id}` | Xóa khách hàng | - |

## 🔍 Troubleshooting

### ⚠️ Một số vấn đề thường gặp

#### 🗄️ 1. Không kết nối được database
```bash
# 🔍 Kiểm tra connection string
cat Customer_Management_Backend/Presentation/.env
```

#### 🌐 2. Frontend không gọi được Backend
```bash
# 🔍 Kiểm tra API URL trong frontend
cat Customer_Management_Frontend/Customer_Management_Frontend/.env
```

---

## 🛠️ Công nghệ sử dụng

### 🔧 Backend
- **Framework**: ASP.NET Core 8.0 Web API
- **Architecture**: Clean Architecture + CQRS
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Documentation**: Swagger/OpenAPI

### 🎨 Frontend
- **Framework**: ASP.NET Core 8.0 MVC
- **UI**: Bootstrap 5
- **HTTP Client**: HttpClient with IHttpClientFactory

### 🐳 DevOps
- **Containerization**: Docker & Docker Compose
- **Database**: SQL Server (Docker/AWS RDS)

---

## 📞 Hỗ trợ

Nếu gặp vấn đề, hãy:
1. 📋 Kiểm tra logs: `docker compose logs -f`
2. 📖 Xem documentation: `/swagger` endpoint
3. 🌐 Kiểm tra network connectivity
4. ⚙️ Verify environment variables

---

## 📝 License

This project is licensed under the MIT License.

---

<div align="center">
  <p>Made with ❤️ by <strong>Trinh Tu</strong></p>
  <p>🚀 <em>Happy Coding!</em> 🚀</p>
</div>

