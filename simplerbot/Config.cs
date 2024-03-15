using Newtonsoft.Json;

namespace simplerbot;

public class Config
{
    [JsonProperty("token")] public string Token { get; set; }
    [JsonProperty("prefix")] public string Prefix { get; set; }

    public static Config LoadConfig()
    {
        var path = File.ReadAllText("config.json");
        var data = JsonConvert.DeserializeObject<Config>(path);

        return data;
    }
}