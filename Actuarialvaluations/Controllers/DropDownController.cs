namespace Actuarialvaluations.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Actuarialvaluations.API;
  using Actuarialvaluations.Models;
  using Actuarialvaluations.Models.API;
  using Microsoft.AspNetCore.Mvc;

  [Route("api/[controller]")]
  public class DropDownController : Controller
  {
    public DropDownController(APIManager apiManager)
    {
      this.APIManager = apiManager;
    }

    private APIManager APIManager { get; }

    // GET: api/<controller>
    [Route("GetMarkovStates")]
    [HttpGet]
    public async Task<IActionResult> GetMarkovStates()
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
