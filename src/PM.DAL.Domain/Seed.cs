using Microsoft.AspNetCore.Identity;
using PM.DAL.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Domain
{
    public class Seed
    {
        public static async Task SeedDataAsync(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                      {
                        new User
                            {
                              Id = Guid.Parse("86c0f8da-997f-409d-b6ea-23ed1390b5ec"),
                              UserName = "User1",
                              Email = "testuserfirst@test.com"
                            },
                        new User
                            {
                              Id = Guid.Parse("00ad55f1-8820-4354-9785-e9c137c9296c"),
                              UserName = "User2",
                              Email = "testusersecond@test.com"
                             }
                         };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "123456");
                }
            }
        }
    }
}
