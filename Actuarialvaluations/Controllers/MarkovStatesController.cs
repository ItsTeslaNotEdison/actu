namespace Actuarialvaluations.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Linq.Dynamic.Core;
  using System.Threading.Tasks;
  using Actuarialvaluations.Models;
  using Actuarialvaluations.Models.AIValuations;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.EntityFrameworkCore;

  [Route("api/[controller]")]
  public class MarkovStatesController : Controller
  {
    private readonly AIValuationsContext aIValuationsContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="MarkovStatesController"/> class.
    /// </summary>
    /// <param name="context">The AIValuations DB context</param>
    public MarkovStatesController(AIValuationsContext context)
    {
      this.aIValuationsContext = context;
    }

    /// <summary>
    ///  GET: api/MarkovStates
    /// </summary>
    /// <param name="skip">The number of records to skip</param>
    /// <param name="take">The number of records to take</param>
    /// <param name="sortBy">The field to sort by</param>
    /// <param name="sortDescending">Sort descending</param>
    /// <returns>The result</returns>
    [HttpGet]
    public async Task<IActionResult> GetMarkovStates([FromQuery(Name = "skip")] int skip = 0, [FromQuery(Name = "take")] int take = 10, [FromQuery(Name = "sortBy")] string sortBy = "Applicable_Model_ID", [FromQuery(Name = "sortDescending")] bool sortDescending = false)
    {
      var str = new string[] { "value1", "value2" };

      try
      {
        IQueryable<MarkovStates> query = this.aIValuationsContext.MarkovStates;
        var result = new EntityList<MarkovStates>
        {
          Total = await query.CountAsync().ConfigureAwait(false),
          Entities = await query.OrderBy($"{sortBy} {(sortDescending ? "DESC" : "ASC")}").Skip(skip).Take(take).ToListAsync().ConfigureAwait(false)
        };
        return this.Ok(result);
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  GET: api/MarkovStates/id
    /// </summary>
    /// <param name="id">The Markov States id</param>
    /// <returns>The result</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMarkovState(int id)
    {
      try
      {
        var markovStates = await this.aIValuationsContext.MarkovStates.FindAsync(id).ConfigureAwait(false);
        if (markovStates == null)
        {
          return this.NotFound();
        }
        else
        {
          return this.Ok(markovStates);
        }
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  POST: api/MarkovStates
    /// </summary>
    /// <param name="markovStates">The Markov States</param>
    /// <returns>The result</returns>
    [HttpPost]

    public async Task<IActionResult> Post([FromBody]MarkovStates markovStates)
    {
      try
      {
          this.aIValuationsContext.MarkovStates.Add(markovStates);
          await this.aIValuationsContext.SaveChangesAsync().ConfigureAwait(false);
          return this.CreatedAtAction("GetMarkovState", new { id = markovStates.ID }, markovStates);
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  POST: api/MarkovStates/BulkInsert
    /// </summary>
    /// <param name="lstMarkovStates">The list Markov States</param>
    /// <returns>The result</returns>
    [Route("BulkInsert")]
    [HttpPost]
    public async Task<IActionResult> BulkInsert([FromBody]List<MarkovStates> lstMarkovStates)
    {
      try
      {
        foreach (var markovStates in lstMarkovStates)
        {
          this.aIValuationsContext.MarkovStates.Add(markovStates);
        }

        await this.aIValuationsContext.SaveChangesAsync().ConfigureAwait(false);
        return this.Ok();
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  POST: api/MarkovStates/id
    /// </summary>
    /// <param name="id">The Markov States id</param>
    /// <param name="value">The Markov States</param>
    /// <returns>The result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]MarkovStates value)
    {
      return this.Ok();
    }

    /// <summary>
    ///  DELETE: api/MarkovStates/id
    /// </summary>
    /// <param name="id">The Markov States id</param>
    /// <returns>The result</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      return this.Ok();
    }
  }
}
