public interface IArmOperations
{
    Task<Subscriptions> EnumerateSubscriptionsAsync(string accessToken);
}