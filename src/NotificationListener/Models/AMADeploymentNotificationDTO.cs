using Newtonsoft.Json;

namespace NotificationListener.Controllers
{

    public class AMADeploymentNotificationDTO
    {
        public string EventType { get; set; }

        public string ProvisioningState { get; set; }

        public Plan Plan { get; set; }
        
        public string ApplicationId { get; set; }
        
        public DateTime EventTime { get; set; }
    }

    public class Plan
    {
        public string Name { get; set; }
        
        public string Product { get; set; }
        
        public string Publisher { get; set; }
        
        public string Version { get; set; }
    }
}