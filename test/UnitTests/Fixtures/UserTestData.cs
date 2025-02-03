using Microsoft.AspNetCore.Identity;
using UnitTests.Models;

namespace UnitTests.Fixtures;

public class UserTestData
{
    private static readonly UserInfo testUser1 = new UserInfo
    {
        Id = "1f44a098-1451-a4b0-ac49b01166d0",
        UserName = "test1@test.com",
        NormalizedUserName = "TEST1@TEST.COM",
        Email = "test1@test.com",
        NormalizedEmail = "TEST1@TEST.COM",
        Password = "Test123@"
    };

    private static readonly UserInfo testUser2 = new UserInfo
    {
        Id = "2f44a098-1451-a4b0-ac49b01166d0",
        UserName = "test2@test.com",
        NormalizedUserName = "TEST2@TEST.COM",
        Email = "test2@test.com",
        NormalizedEmail = "TEST2@TEST.COM",
        Password = "Test123@"
    };

    public UserInfo GetUser1()
    {
        return testUser1;
    }

    public UserInfo GetUser2()
    {
        return testUser2;
    }
}
