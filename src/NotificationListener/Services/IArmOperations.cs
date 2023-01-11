public interface IArmOperations
{
    Task<IEnumerable<SubscriptionSummary>> EnumerateSubscriptionsAsync(string accessToken);

    Task<ManagedApplication> GetManagedApplicationAsync(string accessToken, string applicationId);
    Task<IEnumerable<Resource>> GetResourcesAsync(string accessToken, string managedResourceGroupId);
    Task<IEnumerable<StorageAccountKey>> GetStorageAccountKeys(string accessToken, string resourceId);
}