using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

using NotificationListener.Models;

namespace NotificationListener.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private readonly ITokenAcquisition tokenAcquisition;
        private readonly IArmOperations armOperations;
        private readonly ILogger<UploadController> logger;

        public UploadController(ITokenAcquisition tokenAcquisition, IArmOperations armOperations, ILogger<UploadController> logger)
        {
            this.tokenAcquisition = tokenAcquisition;
            this.armOperations = armOperations;
            this.logger = logger;
        }

        [AuthorizeForScopes(Scopes = new[] { "https://management.core.windows.net/user_impersonation" })]
        public async Task<IActionResult> Index(string applicationId)
        {
            var accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { $"{ArmApiOperationService.ArmResource}user_impersonation" });

            var managedApplication = await this.armOperations.GetManagedApplicationAsync(accessToken, applicationId);

            var resources = await this.armOperations.GetResourcesAsync(accessToken, managedApplication.Properties.ManagedResourceGroupId);

            var storageAccounts = resources.Where(r => r.Type == "Microsoft.Storage/storageAccounts").Select(r => r.Id);

            if (storageAccounts.Any())
            {
                var storageAccountKeys = await this.armOperations.GetStorageAccountKeys(accessToken, storageAccounts.First());
            }
            

            return View();
        }
    }
}
