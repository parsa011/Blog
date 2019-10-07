using Microsoft.Extensions.DependencyInjection;
using Portal.Data.DataBaseContext;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Data.DataInitializer
{
    public class DataInitializer
    {
        public static async void InitializeDataAsync(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<BlogDbContext>())
            {
                if (!context.Roles.Any())
                {
                    context.Roles.Add(new Role {Name = "Admin", Title = "مدیر سایت" });
                    context.Roles.Add(new Role {Name = "User", Title = "کاربر سایت" });
                }
                if (!context.Roles.Any())
                {
                    context.Users.Add(new Users
                    {
                        Email = "parsa@gmail.com",
                        FullName = "parsa mahmoudi",
                        RoleId = 1,
                        UserName = "parsa",
                        ActiveCode = Guid.NewGuid().ToString().Substring(0, 5).Replace("-", ""),
                        CreatedBy = "",
                        CreatedTime = DateTime.Now,
                        LastModifyBy ="",
                        LastModifyTime = DateTime.Now,
                        PasswordHash = PasswordHash.HashWithMD5("1234")
                    });
                }
                await context.SaveChangesAsync();
            }
        }
    }
}