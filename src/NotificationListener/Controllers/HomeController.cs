using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

using NotificationListener.Models;

namespace NotificationListener.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ITokenAcquisition tokenAcquisition;
    private readonly IArmOperations armOperations;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ITokenAcquisition tokenAcquisition, IArmOperations armOperations, ILogger<HomeController> logger)
    {
        this.tokenAcquisition = tokenAcquisition;
        this.armOperations = armOperations;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {        
        return View();
    }

    [HttpGet]
    [AuthorizeForScopes(Scopes = new[] { "https://management.core.windows.net/user_impersonation" })]
    public async Task<IActionResult> Subscriptions()
    {
        var accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { $"{ArmApiOperationService.ArmResource}user_impersonation" });

        var subscriptions = await this.armOperations.EnumerateSubscriptionsAsync(accessToken);

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
