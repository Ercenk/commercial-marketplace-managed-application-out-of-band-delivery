public class Subscriptions
{
    public List<Value> value { get; set; }
    public Count count { get; set; }
}

public class Count
{
    public string type { get; set; }
    public int value { get; set; }
}

public class ManagedByTenant
{
    public string tenantId { get; set; }
}



public class SubscriptionPolicies
{
    public string locationPlacementId { get; set; }
    public string quotaId { get; set; }
    public string spendingLimit { get; set; }
}

public class Tags
{
    public string Environment { get; set; }
}

public class Value
{
    public string id { get; set; }
    public string authorizationSource { get; set; }
    public List<ManagedByTenant> managedByTenants { get; set; }
    public Tags tags { get; set; }
    public string subscriptionId { get; set; }
    public string tenantId { get; set; }
    public string displayName { get; set; }
    public string state { get; set; }
    public SubscriptionPolicies subscriptionPolicies { get; set; }
}

