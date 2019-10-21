using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KVSolution.PIM.Domain.Entities;

namespace KVSolution.PIM.Persistence
{
    public class KVInitializer
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            try
            {
                Policy.Handle<Exception>()
               .WaitAndRetry(new[] {
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(10)
               }, (exception, timeSpan, retryCount, context) =>
               {

               }).Execute(() =>
               {
                   var kVDbContext = serviceProvider.GetRequiredService<KVDbContext>();

                   kVDbContext.Database.Migrate();
                   //SeedUserAsync(kVDbContext).Wait();
                   //SeedCustomerAsync(kVDbContext).Wait();
               });
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<KVInitializer>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

        #region Seed User
        private static async Task SeedUserAsync(KVDbContext context)
        {
            if (context.Users.Any())
                return;

            var users = new List<User>()
            {
                 new User
                {
                    UserName= "admin",
                    Password = "Aa123456",
                    Id = new Guid("76af5bea-6af1-4a18-b38e-1396875518e5"),
                    FirstName = "Administrator",
                    LastName = "",
                    Email = "Administrator@gmail.com",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy=new Guid("76af5bea-6af1-4a18-b38e-1396875518e6"),
                    DoB=DateTime.UtcNow,
                    UpdatedBy= Guid.Empty,
                    UpdatedDate=null,
                }
            };
            context.AddRange(users);
            await context.SaveChangesAsync();
        }
        #endregion

        #region Seed Customer
        private static async Task SeedCustomerAsync(KVDbContext context)
        {
            if (context.Customers.Any())
                return;

            var customers = new List<Customer>()
            {
                 new Customer
                {
                    Name="Thai An",
                    Address="HCM City",
                    IsDelete = false,
                    Phone = "096 999 888",
                    POCode ="123456",
                    Id = new Guid("76af5bea-6af1-4a18-b38e-1396875518e5"),
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy=new Guid("76af5bea-6af1-4a18-b38e-1396875518e6"),
                    UpdatedBy= Guid.Empty,
                    UpdatedDate=null,
                }
            };
            context.AddRange(customers);
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
