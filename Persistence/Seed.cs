using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role{
                        Name="Client"
                    },
                    new Role{
                        Name="Potential Mentor"
                    },
                    new Role{ 
                        Name="Mentor"
                    },
                    new Role{
                        Name="Admin"
                    }
                };

                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }

            if(!userManager.Users.Any())
            {
                var mentorRole = await context.Roles.FirstOrDefaultAsync(x => x.Name == "Potential Mentor");
                var clientRole = await context.Roles.FirstOrDefaultAsync(x => x.Name == "Client");
                var adminRole = await context.Roles.FirstOrDefaultAsync(x => x.Name == "Admin");

                var users=new List<AppUser>
                {
                    new AppUser{
                        DisplayName="Bob", 
                        UserName="bob",
                        Email="bob@test.com",
                        Bio="I am Bob and I'm a software engineer", 
                        Role=mentorRole
                    },
                    new AppUser{
                        DisplayName="Tom",
                        UserName="tom",
                        Email="tom@test.com",
                        Bio="I am Tom and I'm a software engineer",
                        Role=mentorRole
                    },
                    new AppUser{
                        DisplayName="John",
                        UserName="john",
                        Email="john@test.com",
                        Bio="I am John and I'm a software engineer",
                        Role=mentorRole
                    },
                    new AppUser{
                        DisplayName="Stefan",
                        UserName="stefan",
                        Email="stefan@test.com",
                        Bio="I am Stefan and I'm a software engineer",
                        Role=clientRole
                    },
                    new AppUser{
                        DisplayName="Miljan",
                        UserName="miljan",
                        Email="miljan@test.com",
                        Bio="I am Miljan and I'm a software engineer",
                        Role=clientRole
                    },
                    new AppUser{ 
                        DisplayName="Adminčina",
                        UserName="adminčina",
                        Email="admin@test.com",
                        Bio="Ja sam admin i upravljam svime i svačim",
                        Role=adminRole
                    }
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user,"Pa$$w0rd");
                }
            }

            if (!context.Mentorships.Any())
            {
                var client1 = await userManager.FindByEmailAsync("stefan@test.com");
                var client2 = await userManager.FindByEmailAsync("miljan@test.com");
                var mentor = await userManager.FindByEmailAsync("bob@test.com");

                var mentorships = new List<Mentorship>()
                {
                    new Mentorship
                    {
                        ClientId = client1.Id,
                        MentorId = mentor.Id,
                        NumberOfSessions = 40
                    },
                    new Mentorship
                    {
                        ClientId = client2.Id,
                        MentorId = mentor.Id,
                        NumberOfSessions = 40
                    }
                };

                context.Mentorships.AddRange(mentorships);
                
                await context.SaveChangesAsync();
            }

            if (!context.Categories.Any())
            {
                var categories = new List<Category>
            {
                new Category
                {
                    Name = "Web Development"
                },
                new Category
                {
                    Name = "Mobile Development"
                },
                new Category
                {
                    Name = "Game Development"
                },
                new Category
                {
                    Name = "Blockchain Development"
                },
                new Category
                {
                    Name = "Data Science/Machine Learning"
                }
            };
                context.Categories.AddRange(categories);
                
                await context.SaveChangesAsync();
            }

            if (!context.Skills.Any())
            {
                var skills = new List<Skill>
            {
                new Skill
                {
                    Name = "Backend"
                },
                new Skill
                {
                    Name = ".NET Core"
                },
                new Skill
                {
                    Name = "Vue"
                },
                new Skill
                {
                    Name = "Java"
                },
                new Skill
                {
                    Name = "C#"
                },
                new Skill
                {
                    Name = "Laravel"
                },
                new Skill
                {
                    Name = "Axios"
                },
                new Skill
                {
                    Name = "Redux"
                },
                new Skill
                {
                    Name = "React"
                },
                new Skill
                {
                    Name = "Spring"
                },
                new Skill
                {
                    Name = "PHP"
                },
                new Skill
                {
                    Name = "CSS"
                },
                new Skill
                {
                    Name = "HTML"
                },
                new Skill
                {
                    Name = "WEB Api"
                },
                new Skill
                {
                    Name = "Angular"
                },
                new Skill
                {
                    Name = "Javascript"
                }
            };
                context.Skills.AddRange(skills);

                await context.SaveChangesAsync();
            }

            if (!context.AppUserSkills.Any())
            {
                var mentor1 = await userManager.FindByEmailAsync("bob@test.com");
                var mentor2 = await userManager.FindByEmailAsync("tom@test.com");
                var skill1 = await context.Skills.FirstOrDefaultAsync(x => x.Name == "C#");
                var skill2 = await context.Skills.FirstOrDefaultAsync(x => x.Name == "Java");
                var skill3 = await context.Skills.FirstOrDefaultAsync(x => x.Name == "PHP");

                var appUserSkills = new List<AppUserSkill>
                {
                    new AppUserSkill
                    {
                        MentorId = mentor1.Id,
                        SkillId = skill1.Id
                    },
                    new AppUserSkill
                    {
                        MentorId = mentor1.Id,
                        SkillId = skill2.Id
                    },
                    new AppUserSkill
                    {
                        MentorId = mentor1.Id,
                        SkillId = skill3.Id
                    },
                    new AppUserSkill
                    {
                        MentorId = mentor2.Id,
                        SkillId = skill2.Id
                    },
                    new AppUserSkill
                    {
                        MentorId = mentor2.Id,
                        SkillId = skill3.Id
                    }
                };

                context.AppUserSkills.AddRange(appUserSkills);

                await context.SaveChangesAsync();
            }
                await context.SaveChangesAsync();
        }
    }
}