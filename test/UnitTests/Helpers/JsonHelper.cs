using System.Text;
using Newtonsoft.Json;

namespace UnitTests.Helpers;

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

    public static async Task<T> ExtractJsonData<T>(string filePath)
    {
        var fileContent = await File.ReadAllTextAsync(filePath);
        var obj = JsonConvert.DeserializeObject<T>(fileContent);
        return obj;
    }
}
