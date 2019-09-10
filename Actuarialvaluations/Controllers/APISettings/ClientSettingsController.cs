namespace Actuarialvaluations.Controllers.APISettings
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Actuarialvaluations.Settings;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Options;

  /// <summary>
  /// The Client Settings controller
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class ClientSettingsController : Controller
  {
    private readonly ActuarialClientSettings actuarialClientSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientSettingsController"/> class.
    /// </summary>
    /// <param name="actuarialClientSettings">The Actuarial Client Settings</param>
    public ClientSettingsController(IOptions<ActuarialClientSettings> actuarialClientSettings)
    {
      this.actuarialClientSettings = actuarialClientSettings.Value;
    }

    /// <summary>
    /// GET: api/ClientSettings
    /// </summary>
    /// <returns>The client settings</returns>
    [HttpGet]
    public async Task<IActionResult> GetClientSettings()
    {
      try
      {
        if (this.actuarialClientSettings == null)
        {
          return this.NotFound();
        }
        else
        {
          return this.Ok(this.actuarialClientSettings);
        }
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }
  }
}
