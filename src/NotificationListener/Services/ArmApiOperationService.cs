using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ArmApiOperationService : IArmOperations
{
    private readonly HttpClient httpClient;
    private readonly ILogger<ArmApiOperationService> logger;

    public ArmApiOperationService(HttpClient httpClient, ILogger<ArmApiOperationService> logger)
    {
        this.httpClient = httpClient;
        this.logger = logger;
    }

    public static string ArmResource { get; } = "https://management.core.windows.net/";

    private static string? ArmListSubscriptions { get; } = "https://management.azure.com/subscriptions?api-version=2020-01-01";

    public async Task<Subscriptions> EnumerateSubscriptionsAsync(string accessToken)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

        var httpResult = await httpClient.GetAsync(ArmListSubscriptions);
        var resultJson  = await httpResult.Content.ReadAsStringAsync();
        var subscriptions = JsonSerializer.Deserialize<Subscriptions>(resultJson);
        this.logger.LogInformation($"subscriptions:{resultJson}");
        return subscriptions;
    }
}