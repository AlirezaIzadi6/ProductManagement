using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity.Data;
using UnitTests.Fixtures;
using UnitTests.Helpers;
using UnitTests.Models;

namespace FunctionalTests.Helpers;

public static class Login
{
    public static async Task<string> GetBearerToken(HttpClient client, UserInfo user)
    {
        var loginRequest = new LoginRequest
        {
            Email = user.Email,
            Password = user.Password,
        };

        var content = JsonHelper.GetJsonRequest(loginRequest);
        string url = "/login";

        var response = await client.PostAsync(url, content);

        var accessTokenResponse = await JsonHelper.ParseResponse<AccessTokenResponse>(response.Content);
        var accessToken = accessTokenResponse.AccessToken;

        return accessToken;
    }
}
