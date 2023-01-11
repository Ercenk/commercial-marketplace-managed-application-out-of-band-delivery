using Azure.Core;

using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using Microsoft.CodeAnalysis.Elfie.Serialization;

using System;
using System.Text.Json;

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

    private static string managementApiUrlBase = "https://management.azure.com";

    public async Task<IEnumerable<SubscriptionSummary>> EnumerateSubscriptionsAsync(string accessToken)
    {

        var subscriptions = await this.GetArmResultsAsync<Subscriptions>(() => { return ArmListSubscriptions; }, accessToken);
        return subscriptions.value.Select(s => new SubscriptionSummary {SubscriptionId = s.subscriptionId, DisplayName = s.displayName });
    }

    public async Task<ManagedApplication> GetManagedApplicationAsync(string accessToken, string applicationId)
    {
        var managedApplication = await this.GetArmResultsAsync<ManagedApplication>(
            () =>
            {
                return $"{managementApiUrlBase}{applicationId}?api-version=2019-07-01";
            }, accessToken);

        return managedApplication;
    }

    private async Task<T> GetArmResultsAsync<T>( Func<string> resourceUrl, string accessToken)
    {
        if (httpClient.DefaultRequestHeaders.Any(h => h.Key == "Authorization"))
        {
            var authHeader = httpClient.DefaultRequestHeaders.Remove("Authorization");
        }
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

        var httpResult = await httpClient.GetAsync(resourceUrl());
        var resultJson = await httpResult.Content.ReadAsStringAsync();
        this.logger.LogInformation($"subscriptions:{resultJson}");
        return JsonSerializer.Deserialize<T>(resultJson);
    }

    private async Task<T> PostArmResultsAsync<T>(Func<string> resourceUrl, string accessToken)
    {
        if (httpClient.DefaultRequestHeaders.Any(h => h.Key == "Authorization"))
        {
            var authHeader = httpClient.DefaultRequestHeaders.Remove("Authorization");
        }
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        

        var httpResult = await httpClient.PostAsync(resourceUrl(), null);
        var resultJson = await httpResult.Content.ReadAsStringAsync();
        this.logger.LogInformation($"subscriptions:{resultJson}");
        return JsonSerializer.Deserialize<T>(resultJson);
    }

    public async Task<IEnumerable<StorageAccountKey>> GetStorageAccountKeys(string accessToken, string resourceId)
    {
        var storageAccountKeys = await this.PostArmResultsAsync<StorageKeys>(
             () =>
             {
                 return $"{managementApiUrlBase}{resourceId}/listKeys?api-version=2022-09-01";
             }, accessToken);

        return storageAccountKeys.Keys;
    }

    public async Task<IEnumerable<Resource>> GetResourcesAsync(string accessToken, string managedResourceGroupId)
    {
        var managedResources = await this.GetArmResultsAsync<ResourceGroupResources>(
                    () =>
                    {
                        return $"{managementApiUrlBase}{managedResourceGroupId}/resources?api-version=2021-04-01";
                    }, accessToken);

        return managedResources.Resources;
    }
}