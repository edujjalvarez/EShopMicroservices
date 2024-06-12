using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task ApplyDatabaseMigrationsAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //context.Database.MigrateAsync().GetAwaiter().GetResult();
        await context.Database.MigrateAsync();
    }

    public static async Task ApplyDatabaseSeedAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await SeedCustomersAsync(context);
        await SeedProductsAsync(context);
        await SeedOrdersWithItemsAsync(context);
    }

    public static async Task SeedCustomersAsync(ApplicationDbContext context)
    {
        if (await context.Customers.AnyAsync()) return;
        await context.Customers.AddRangeAsync(InitialData.Customers);
        await context.SaveChangesAsync();
    }

    public static async Task SeedProductsAsync(ApplicationDbContext context)
    {
        if (await context.Products.AnyAsync()) return;
        await context.Products.AddRangeAsync(InitialData.Products);
        await context.SaveChangesAsync();
    }

    public static async Task SeedOrdersWithItemsAsync(ApplicationDbContext context)
    {
        if (await context.Orders.AnyAsync()) return;
        await context.Orders.AddRangeAsync(InitialData.OrdersWithItems);
        await context.SaveChangesAsync();
    }

    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}
