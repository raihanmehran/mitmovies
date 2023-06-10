using System.Text.Json;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;

namespace Infrastructure.v1.Utils
{
    public static class Seed
    {
        public static async void ReadData(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            DataContext context
        )
        {
            // using csv files to read data from
            // using (TextFieldParser parser = new TextFieldParser(@"C:\Users\SCS\Desktop\IMDB\movies_metadata.csv"))
            // {
            //     string[] fields;
            //     parser.Delimiters = new string[] { "," };
            //     while (!parser.EndOfData)
            //     {
            //         fields = parser.ReadFields();
            //         System.Console.WriteLine(fields[0] + " " + fields[1]);
            //     }
            // }

            // reading data from json file:
            if (await userManager.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("../Infrastructure/v1/Contexts/Data/UserSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            var roles = new List<AppRole>{
                new AppRole { Name = "Member" },
                new AppRole { Name = "Admin" },
                new AppRole { Name = "Moderator" }
            };

            roles.ForEach(async role => await roleManager.CreateAsync(role: role));

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                user.Created = DateTime.SpecifyKind(user.Created, DateTimeKind.Utc);
                user.LastActive = DateTime.SpecifyKind(user.LastActive, DateTimeKind.Utc);
                await userManager.CreateAsync(user: user, password: "Pass");
                await userManager.AddToRoleAsync(user: user, role: "Member");
            }

            var genres = new List<Genre>{
                new Genre {Name= "Action"},
                new Genre {Name= "Adventure"},
                new Genre {Name= "Animation"},
                new Genre {Name= "Comedy"},
                new Genre {Name= "Crime"},
                new Genre {Name= "Documentary"},
                new Genre {Name= "Drama"},
                new Genre {Name= "Family"},
                new Genre {Name= "Fantasy"},
                new Genre {Name= "History"},
                new Genre {Name= "Horror"},
                new Genre {Name= "Music"},
                new Genre {Name= "Mystery"},
                new Genre {Name= "Romance"},
                new Genre {Name= "Science Fiction"},
                new Genre {Name= "TV Movie"},
                new Genre {Name= "Thriller"},
                new Genre {Name= "War"},
                new Genre {Name= "Western"}
            };

            genres.ForEach(async genre => await context.Genres.AddAsync(genre));

            var admin = new AppUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FirstName = "Nik",
                LastName = "Mehran",
                Created = DateTime.UtcNow,
                LastActive = DateTime.UtcNow,
            };

            await userManager.CreateAsync(user: admin, password: "admin");
            await userManager.AddToRolesAsync(user: admin, new[] { "Admin", "Moderator" });
        }
    }
}