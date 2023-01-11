using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Internal;
using NotificationListener.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationListener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ResourceController : ControllerBase
    {
        private readonly ILogger<ResourceController> logger;
        private readonly DataContext dataContext;

        public ResourceController(ILogger<ResourceController> logger, DataContext dataContext)
        {
            this.logger = logger;
            this.dataContext = dataContext;
        }
        // POST api/<ResourceController>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var payload = await reader.ReadToEndAsync();
                var notificationDetails = JsonSerializer.Deserialize<AMADeploymentNotificationDTO>(payload, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

                await this.dataContext.AddOrUpdate(new DeployedApp
                {
                    ApplicationId = notificationDetails.ApplicationId,
                    EventTime = notificationDetails.EventTime,
                    EventType = notificationDetails.EventType,
                    ProvisioningState = notificationDetails.ProvisioningState
                });

                this.logger.LogInformation($"Received: {payload}");
            }

            return this.Ok();
        }

    }
}
