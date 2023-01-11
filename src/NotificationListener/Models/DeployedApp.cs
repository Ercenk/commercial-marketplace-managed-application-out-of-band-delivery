using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

namespace NotificationListener.Models
{
    [PrimaryKey(nameof(ApplicationId), nameof(EventTime), nameof(ProvisioningState))]
    public class DeployedApp
    {
        public string EventType { get; set; }

        public string ProvisioningState { get; set; }

        [Key]
        public string ApplicationId { get; set; }

        public DateTime EventTime { get; set; }
    }
}