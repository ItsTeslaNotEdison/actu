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
  public class YieldController : Controller
  {
    private readonly AIValuationsContext aIValuationsContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="YieldController"/> class.
    /// </summary>
    /// <param name="context">The AIValuations DB context</param>
    public YieldController(AIValuationsContext context)
    {
      this.aIValuationsContext = context;
    }

    /// <summary>
    ///  GET: api/Yield
    /// </summary>
    /// <param name="skip">The number of records to skip</param>
    /// <param name="take">The number of records to take</param>
    /// <param name="sortBy">The field to sort by</param>
    /// <param name="sortDescending">Sort descending</param>
    /// <returns>The result</returns>
    [HttpGet]
    public async Task<IActionResult> GetYield([FromQuery(Name = "skip")] int skip = 0, [FromQuery(Name = "take")] int take = 10, [FromQuery(Name = "sortBy")] string sortBy = "Applicable_Model_ID", [FromQuery(Name = "sortDescending")] bool sortDescending = false)
    {
      var str = new string[] { "value1", "value2" };

      try
      {
        IQueryable<Yield> query = this.aIValuationsContext.Yield;
        var result = new EntityList<Yield>
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
    ///  GET: api/Yield/id
    /// </summary>
    /// <param name="id">The Markov States id</param>
    /// <returns>The result</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMarkovState(int id)
    {
      try
      {
        var yield = await this.aIValuationsContext.Yield.FindAsync(id).ConfigureAwait(false);
        if (yield == null)
        {
          return this.NotFound();
        }
        else
        {
          return this.Ok(yield);
        }
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  POST: api/Yield
    /// </summary>
    /// <param name="yield">The Markov States</param>
    /// <returns>The result</returns>
    [HttpPost]

    public async Task<IActionResult> Post([FromBody]Yield yield)
    {
      try
      {
        this.aIValuationsContext.Yield.Add(yield);
        await this.aIValuationsContext.SaveChangesAsync().ConfigureAwait(false);
        return this.CreatedAtAction("GetMarkovState", new { id = yield.ID }, yield);
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  POST: api/Yield/BulkInsert
    /// </summary>
    /// <param name="lstYield">The list Markov States</param>
    /// <returns>The result</returns>
    [Route("BulkInsert")]
    [HttpPost]
    public async Task<IActionResult> BulkInsert([FromBody]List<Yield> lstYield)
    {
      try
      {
        foreach (var yield in lstYield)
        {
          this.aIValuationsContext.Yield.Add(yield);
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
    ///  POST: api/Yield/id
    /// </summary>
    /// <param name="id">The Markov States id</param>
    /// <param name="value">The Markov States</param>
    /// <returns>The result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]Yield value)
    {
      return this.Ok();
    }

    /// <summary>
    ///  DELETE: api/Yield/id
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
