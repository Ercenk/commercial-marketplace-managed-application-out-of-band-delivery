using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationListener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ResourceController : ControllerBase
    {
        private readonly ILogger<ResourceController> logger;

        public ResourceController(ILogger<ResourceController> logger)
        {
            this.logger = logger;
        }
        // POST api/<ResourceController>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var payload = await reader.ReadToEndAsync();
                this.logger.LogInformation($"Received: {payload}");
            }

            return this.Ok();
        }

    }
}
