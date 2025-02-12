using Microsoft.AspNetCore.Identity;
using Infrastructure.Persistence.Contexts;
using UnitTests.Models;

namespace UnitTests.Fixtures.Seeders;

public static class IdentityDataSeeder
{
    public static async Task SeedAsync(UserManager<IdentityUser> userManager)
    {
        var testData = new UserTestData();
        var testUserInfo1 = testData.GetUser1();
        var testUserInfo2 = testData.GetUser2();
        var testUser1 = new IdentityUser
        {
            Id = testUserInfo1.Id,
            UserName = testUserInfo1.UserName,
            NormalizedUserName = testUserInfo1.NormalizedUserName,
            Email = testUserInfo1.Email,
            NormalizedEmail = testUserInfo1.NormalizedEmail,
        };
        var testUser2 = new IdentityUser
        {
            Id = testUserInfo2.Id,
            UserName = testUserInfo2.UserName,
            NormalizedUserName = testUserInfo2.NormalizedUserName,
            Email = testUserInfo2.Email,
            NormalizedEmail = testUserInfo2.NormalizedEmail,
        };

        await userManager.CreateAsync(testUser1, testUserInfo1.Password);
        await userManager.CreateAsync(testUser2, testUserInfo2.Password);
    }
}
