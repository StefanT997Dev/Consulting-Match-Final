using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users=new List<AppUser>
                {
                    new AppUser{
                        DisplayName="Bob", UserName="bob",Email="bob@test.com",Bio="I am Bob and I'm a software engineer"
                    },
                    new AppUser{
                        DisplayName="Tom", UserName="tom",Email="tom@test.com",Bio="I am Tom and I'm a software engineer"
                    },
                    new AppUser{
                        DisplayName="John", UserName="john",Email="john@test.com",Bio="I am John and I'm a software engineer"
                    }
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user,"Pa$$w0rd");
                }
            }

            if (context.Categories.Any()) return;
            
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Depression Consulting",
                    NumberOfConsultants = 0
                },
                new Category
                {
                    Name = "UI/UX Consulting",
                    NumberOfConsultants = 0
                },
                new Category
                {
                    Name = "Business Consulting",
                    NumberOfConsultants = 0
                }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }
    }
}