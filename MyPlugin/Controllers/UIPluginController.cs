using System.Collections.Generic;
using System.Threading.Tasks;
using BTCPayServer.Abstractions.Constants;
using BTCPayServer.Client;
using BTCPayServer.Plugins.MyPlugin.Data;
using BTCPayServer.Plugins.MyPlugin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTCPayServer.Plugins.MyPlugin.Controllers;

[Route("~/plugins/MyPlugin")]
[Authorize(AuthenticationSchemes = AuthenticationSchemes.Cookie, Policy = Policies.CanViewProfile)]
public class UIPluginController : Controller
{
    private readonly MyPluginPluginService _pluginService;

    public UIPluginController(MyPluginPluginService pluginService)
    {
        _pluginService = pluginService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        return View(new PluginPageViewModel { Data = await _pluginService.Get() });
    }
}

public class PluginPageViewModel
{
    public List<PluginData> Data { get; set; }
}
