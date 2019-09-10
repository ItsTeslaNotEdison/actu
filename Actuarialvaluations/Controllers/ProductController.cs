// <copyright file="ProductController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Actuarialvaluations.Controllers
{
  using System.Collections.Generic;
  using Actuarialvaluations.Settings;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Options;

  [Route("api/[controller]")]
  public class ProductController : Controller
  {
    private readonly ActuarialClientSettings actuarialClientSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientSettingsController"/> class.
    /// </summary>
    /// <param name="actuarialClientSettings">The Actuarial Client Settings</param>
    public ProductController(IOptions<ActuarialClientSettings> actuarialClientSettings)
    {
      this.actuarialClientSettings = actuarialClientSettings.Value;
    }

    // GET: api/<controller>
    [HttpGet]
    public IEnumerable<string> Get()
    {

      return new string[] { "value1", "value2" };
    }
  }
}
