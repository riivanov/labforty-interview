using API.Auth;
using Microsoft.AspNetCore.Identity;

namespace API.Data;

public class DBInitializer
{
    public static async void CreateDbIfNotExists(WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;

            try
            {
                var identityUser = services.GetRequiredService<UserManager<IdentityUser>>();
                var loginContext = services.GetRequiredService<LoginContext>();

                loginContext.Database.EnsureCreated();

                await Initialize(identityUser, loginContext);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }

    public static async Task Initialize(UserManager<IdentityUser> userManager, LoginContext context)
    {
        // Look for any users.
        if (context.Users.Any())
        {
            return; // DB has been seeded
        }

        var users = new IdentityUser[]
        {
            new IdentityUser { UserName = "inna", Email = "inna@example.com" },
            new IdentityUser { UserName = "ivan", Email = "ivan@example.com" },
            new IdentityUser { UserName = "alex", Email = "alex@example.com" }
        };

        foreach (IdentityUser u in users)
        {
            await userManager.CreateAsync(u);
        }

        context.SaveChanges();
    }
}
