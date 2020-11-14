using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "sample",
                    Email = "sample@test.com",
                    UserName = "sample@test.com",
                    Address = new Address
                    {
                        FirstName = "sample",
                        LastName = "test",
                        Street = "100 N street",
                        City = "New York",
                        State = "NY",
                        ZipCode = "12345"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
