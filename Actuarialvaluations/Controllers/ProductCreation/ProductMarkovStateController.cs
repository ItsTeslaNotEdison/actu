using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actuarialvaluations.API;
using Actuarialvaluations.Models;
using Actuarialvaluations.Models.API;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Actuarialvaluations.Controllers.ProductCreation
{
  [Route("api/[controller]")]
  public class ProductMarkovStateController : Controller
  {
    public ProductMarkovStateController(APIManager apiManager)
    {
      this.APIManager = apiManager;
    }

    private APIManager APIManager { get; }

    // GET: api/<controller>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery(Name = "skip")] int skip = 0, [FromQuery(Name = "take")] int take = 10, [FromQuery(Name = "sortBy")] string sortBy = "StateName", [FromQuery(Name = "sortDescending")] bool sortDescending = false)
    {
      try
      {
        List<MarkovStateDropdown> lstMarkovState = await this.APIManager.RetrieveMultiple<MarkovStateDropdown>("markovstate").ConfigureAwait(false);
        var result = new EntityList<MarkovStateDropdown>
        {
          Total = lstMarkovState.Count(),
          Entities = lstMarkovState,
        };
        return this.Ok(result);
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }
  }
}
