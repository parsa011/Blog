﻿using Microsoft.Extensions.DependencyInjection;
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
                    await context.SaveChangesAsync();
                }
                if (!context.Roles.Any())
                {
                    context.Users.Add(new Users
                    {
                        Email = "parsa@gmail.com",
                        FullName = "parsa mahmoudi",
                        RoleId = context.Roles.Where(r => r.Name == "Admin").FirstOrDefault().Id,
                        UserName = "parsa",
                        ActiveCode = Guid.NewGuid().ToString().Substring(0, 5).Replace("-", ""),
                        CreatedBy = "",
                        CreatedTime = DateTime.Now,
                        LastModifyBy ="",
                        LastModifyTime = DateTime.Now,
                        PasswordHash = PasswordHash.HashWithMD5("1234")
                    });
                    await context.SaveChangesAsync();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.Add(new Category { CreatedTime = DateTime.Now, Title = "دسته بندی نشده" });
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}