# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj file and restore dependencies
COPY ["Customer_Management_Frontend/Customer_Management_Frontend.csproj", "Customer_Management_Frontend/"]
RUN dotnet restore "Customer_Management_Frontend/Customer_Management_Frontend.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/Customer_Management_Frontend"
RUN dotnet build "Customer_Management_Frontend.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "Customer_Management_Frontend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port
EXPOSE 8080

ENTRYPOINT ["dotnet", "Customer_Management_Frontend.dll"]