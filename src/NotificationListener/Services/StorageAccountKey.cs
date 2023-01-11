using System.Text.Json.Serialization;

public class StorageAccountKey
{
    [JsonPropertyName("creationTime")]
    public DateTime CreationTime { get; set; }

    [JsonPropertyName("keyName")]
    public string KeyName { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("permissions")]
    public string Permissions { get; set; }
}

public class StorageKeys
{
    [JsonPropertyName("keys")]
    public List<StorageAccountKey> Keys { get; set; }
}

