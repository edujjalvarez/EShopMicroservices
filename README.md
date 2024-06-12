# EShopMicroservices

## EF Core Commands

    1. Create migration command: Add-Migration Initial -StartupProject Ordering.API -Project Ordering.Infrastructure -Context ApplicationDbContext -OutputDir Data/Migrations
    2. Update database command: Update-Database -StartupProject Ordering.API -Project Ordering.Infrastructure -Context ApplicationDbContext
