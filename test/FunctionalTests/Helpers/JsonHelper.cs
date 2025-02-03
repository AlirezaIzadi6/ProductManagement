using System.Text;
using Newtonsoft.Json;

namespace FunctionalTests.Helpers;

public static class JsonHelper
{
    public static StringContent GetJsonRequest(object content)
    {
        return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
    }

    public static async Task<T?> ParseResponse<T>(HttpContent content)
    {
        var contentString = await content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<T>(contentString);
        return obj;
    }
}
