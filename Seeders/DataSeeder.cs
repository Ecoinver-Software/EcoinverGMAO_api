﻿using EcoinverGMAO_api.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace EcoinverGMAO_api.Seeders
{
    public class DataSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            // Crear un scope para obtener los servicios necesarios
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            // Nombre del rol y datos del usuario administrador
            string superAdminRoleName = "SuperAdmin";
            string adminRoleName = "Admin";
            string reporterRoleName = "Reportador";
            string technicalRoleName = "Tecnico";
            string adminUserName = "admin";
            string tecnicoUserName = "tecnico";
            string reporterUserName = "reportador";

            //Crear el rol de SuperAdministrador si no existe
            if (!await roleManager.RoleExistsAsync(superAdminRoleName))
            {
                var Role = new Role
                {
                    Name = superAdminRoleName,
                    Description = "Rol de SuperAdministrador con permisos completos para desarrolladores",
                    Level = 1
                };

                var roleResult = await roleManager.CreateAsync(Role);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Error al crear el rol de SuperAdministrador: " +
                        string.Join(", ", roleResult.Errors));
                }
            }

            //Crear el rol de administrador si no existe
            if (!await roleManager.RoleExistsAsync(adminRoleName))
            {
                var Role = new Role
                {
                    Name = adminRoleName,
                    Description = "Rol de administrador con permisos completos",
                    Level = 2
                };

                var roleResult = await roleManager.CreateAsync(Role);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Error al crear el rol de administrador: " +
                        string.Join(", ", roleResult.Errors));
                }
            }

            //Crear el rol de reportador si no existe
            if (!await roleManager.RoleExistsAsync(reporterRoleName))
            {
                var Role = new Role
                {
                    Name = reporterRoleName,
                    Description = "Rol de reportador con permisos limitados solo para reportar incidencias.",
                    Level = 20
                };

                var roleResult = await roleManager.CreateAsync(Role);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Error al crear el rol de reportador: " +
                        string.Join(", ", roleResult.Errors));
                }
            }

            //Crear el rol de tecnico si no existe
            if (!await roleManager.RoleExistsAsync(technicalRoleName))
            {
                var Role = new Role
                {
                    Name = technicalRoleName,
                    Description = "Rol de tecnico con permisos limitados para tecnicos.",
                    Level = 20
                };

                var roleResult = await roleManager.CreateAsync(Role);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Error al crear el rol de reportador: " +
                        string.Join(", ", roleResult.Errors));
                }
            }

            //  Crear el usuario administrador si no existe
            var adminUser = await userManager.FindByNameAsync(adminUserName);
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = adminUserName,
                    Email = "admin@example.com",
                    NombreCompleto = "Administrador del Sistema",
                    EmailConfirmed = true
                };

                // Crea el usuario con la contraseña "1234"
                var userResult = await userManager.CreateAsync(adminUser, "1234");
                if (!userResult.Succeeded)
                {
                    throw new Exception("Error al crear el usuario administrador: " +
                        string.Join(", ", userResult.Errors));
                }

                // Asigna el rol de administrador al usuario creado
                var addToRoleResult = await userManager.AddToRoleAsync(adminUser, adminRoleName);
                if (!addToRoleResult.Succeeded)
                {
                    throw new Exception("Error al asignar el rol de administrador: " +
                        string.Join(", ", addToRoleResult.Errors));
                }
            }
            var tecnicoUser = await userManager.FindByNameAsync(tecnicoUserName);
            if (tecnicoUser == null)
            {
                tecnicoUser = new User
                {
                    UserName = tecnicoUserName,
                    Email = "tecnico@example.com",
                    NombreCompleto = "Tecnico",
                    EmailConfirmed = true
                };

                // Crea el usuario con la contraseña "1234"
                var userResult = await userManager.CreateAsync(tecnicoUser, "1234");
                if (!userResult.Succeeded)
                {
                    throw new Exception("Error al crear el usuario tecnico: " +
                        string.Join(", ", userResult.Errors));
                }

                // Asigna el rol de administrador al usuario creado
                var addToRoleResult = await userManager.AddToRoleAsync(tecnicoUser, technicalRoleName);
                if (!addToRoleResult.Succeeded)
                {
                    throw new Exception("Error al asignar el rol de administrador: " +
                        string.Join(", ", addToRoleResult.Errors));
                }
            }
            var reporterUser = await userManager.FindByNameAsync(reporterUserName);
            if (reporterUser == null)
            {
                reporterUser = new User
                {
                    UserName = reporterUserName,
                    Email = "reporter@example.com",
                    NombreCompleto = "Reporter",
                    EmailConfirmed = true
                };

                // Crea el usuario con la contraseña "1234"
                var userResult = await userManager.CreateAsync(reporterUser, "1234");
                if (!userResult.Succeeded)
                {
                    throw new Exception("Error al crear el usuario reporter: " +
                        string.Join(", ", userResult.Errors));
                }

                // Asigna el rol de reporter al usuario creado
                var addToRoleResult = await userManager.AddToRoleAsync(reporterUser, reporterRoleName);
                if (!addToRoleResult.Succeeded)
                {
                    throw new Exception("Error al asignar el rol de reporter: " +
                        string.Join(", ", addToRoleResult.Errors));
                }
            }

        }
    }
}
