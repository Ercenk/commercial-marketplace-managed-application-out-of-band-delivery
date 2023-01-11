// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using System.Text.Json.Serialization;

public class AdminPassword
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class AdminUsername
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Authorization
{
    [JsonPropertyName("principalId")]
    public string PrincipalId { get; set; }

    [JsonPropertyName("roleDefinitionId")]
    public string RoleDefinitionId { get; set; }
}

public class CreatedBy
{
    [JsonPropertyName("oid")]
    public string Oid { get; set; }

    [JsonPropertyName("puid")]
    public string Puid { get; set; }

    [JsonPropertyName("applicationId")]
    public string ApplicationId { get; set; }
}

public class CustomerSupport
{
    [JsonPropertyName("contactName")]
    public string ContactName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }
}

public class DnsLabelPrefix
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Hostname
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Location
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Outputs
{
    [JsonPropertyName("hostname")]
    public Hostname Hostname { get; set; }
}

public class Parameters
{
    [JsonPropertyName("adminUsername")]
    public AdminUsername AdminUsername { get; set; }

    [JsonPropertyName("adminPassword")]
    public AdminPassword AdminPassword { get; set; }

    [JsonPropertyName("dnsLabelPrefix")]
    public DnsLabelPrefix DnsLabelPrefix { get; set; }

    [JsonPropertyName("windowsOSVersion")]
    public WindowsOSVersion WindowsOSVersion { get; set; }

    [JsonPropertyName("vmSize")]
    public VmSize VmSize { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }
}

public class Plan
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("product")]
    public string Product { get; set; }

    [JsonPropertyName("publisher")]
    public string Publisher { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }
}

public class Properties
{
    [JsonPropertyName("managedResourceGroupId")]
    public string ManagedResourceGroupId { get; set; }

    [JsonPropertyName("parameters")]
    public Parameters Parameters { get; set; }

    [JsonPropertyName("outputs")]
    public Outputs Outputs { get; set; }

    [JsonPropertyName("provisioningState")]
    public string ProvisioningState { get; set; }

    [JsonPropertyName("publisherTenantId")]
    public string PublisherTenantId { get; set; }

    [JsonPropertyName("authorizations")]
    public List<Authorization> Authorizations { get; set; }

    [JsonPropertyName("managementMode")]
    public string ManagementMode { get; set; }

    [JsonPropertyName("customerSupport")]
    public CustomerSupport CustomerSupport { get; set; }

    [JsonPropertyName("supportUrls")]
    public SupportUrls SupportUrls { get; set; }

    [JsonPropertyName("createdBy")]
    public CreatedBy CreatedBy { get; set; }

    [JsonPropertyName("updatedBy")]
    public UpdatedBy UpdatedBy { get; set; }
}

public class ManagedApplication
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }

    [JsonPropertyName("plan")]
    public Plan Plan { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }
}

public class SupportUrls
{
    [JsonPropertyName("publicAzure")]
    public string PublicAzure { get; set; }
}

public class UpdatedBy
{
    [JsonPropertyName("oid")]
    public string Oid { get; set; }

    [JsonPropertyName("puid")]
    public string Puid { get; set; }

    [JsonPropertyName("applicationId")]
    public string ApplicationId { get; set; }
}

public class VmSize
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class WindowsOSVersion
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

