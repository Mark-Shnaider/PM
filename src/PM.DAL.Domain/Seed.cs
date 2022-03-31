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
                              UserName = "User1",
                              Email = "testuserfirst@test.com"
                            },
                        new User
                            {
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
