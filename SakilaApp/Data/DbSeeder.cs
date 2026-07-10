using Microsoft.AspNetCore.Identity;

namespace SakilaApp.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Crear roles
            string[] roles = { "Administrador", "Supervisor", "Operador", "Consulta" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Crear usuarios
            var usuarios = new[]
            {
                ("admin@espe.edu.ec", "Admin123!", "Administrador"),
                ("supervisor@espe.edu.ec", "Super123!", "Supervisor"),
                ("operador@espe.edu.ec", "Operador123!", "Operador"),
                ("consulta@espe.edu.ec", "Consulta123!","Consulta"),
            };

            foreach (var (email, password, role) in usuarios)
            {
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}