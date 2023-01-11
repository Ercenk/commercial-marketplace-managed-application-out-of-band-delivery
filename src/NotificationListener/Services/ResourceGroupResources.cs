using System.Text.Json.Serialization;

public class Identity
{
    [JsonPropertyName("principalId")]
    public string PrincipalId { get; set; }

    [JsonPropertyName("tenantId")]
    public string TenantId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class ResourceGroupResources
{
    [JsonPropertyName("value")]
    public IEnumerable<Resource> Resources { get; set; }
}

public class Sku
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("tier")]
    public string Tier { get; set; }
}

public class Resource
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("sku")]
    public Sku Sku { get; set; }

    [JsonPropertyName("identity")]
    public Identity Identity { get; set; }

    [JsonPropertyName("managedBy")]
    public string ManagedBy { get; set; }
}

