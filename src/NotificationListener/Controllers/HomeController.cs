using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

using NotificationListener.Models;

namespace NotificationListener.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ITokenAcquisition tokenAcquisition;
    private readonly IArmOperations armOperations;
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext dataContext;

    public HomeController(ITokenAcquisition tokenAcquisition, IArmOperations armOperations, ILogger<HomeController> logger, DataContext dataContext)
    {
        this.tokenAcquisition = tokenAcquisition;
        this.armOperations = armOperations;
        _logger = logger;
        this.dataContext = dataContext;
    }

    public async Task<IActionResult> Index()
    {
        var notifications = await this.dataContext.DeployedApplications.OrderByDescending(n => n.EventTime).ToListAsync();
        return View(notifications);
    }

    [HttpGet]
    [AuthorizeForScopes(Scopes = new[] { "https://management.core.windows.net/user_impersonation" })]
    public async Task<IActionResult> Subscriptions()
    {
        var accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { $"{ArmApiOperationService.ArmResource}user_impersonation" });

        var subscriptions = await this.armOperations.EnumerateSubscriptionsAsync(accessToken);

        return View(subscriptions);
    }


    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
