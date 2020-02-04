using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace FamilyScoreboard.Infrastructure {
    public static class DatabaseInitializer {
        public static IHost MigrateDatabase<T>(this IHost webHost) where T : DbContext {
            using (var scope = webHost.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                try {
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                } catch (Exception ex) {
                    services.GetRequiredService<ILogger<Program>>()
                        .LogError(ex, "Failed to migrate database");
                }
            }
            return webHost;
        }
    }
}
