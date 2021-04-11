using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

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

                    AppUserId = "testId",
                    FirstName = "First",
                    LastName = "Admin",
                    EmailAddress = "ItsaDummyDataField",
                    Email = "admin@test.com",
                    UserName = "FirstAdmin",
                    title = "Admin"


                };

                await userManager.CreateAsync(user, "Pa$$w0rd");

            }
        }

    }
}