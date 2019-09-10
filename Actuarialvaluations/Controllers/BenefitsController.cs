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
  public class BenefitsController : Controller
  {
    private readonly AIValuationsContext aIValuationsContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="BenefitsController"/> class.
    /// </summary>
    /// <param name="context">The AIValuations DB context</param>
    public BenefitsController(AIValuationsContext context)
    {
      this.aIValuationsContext = context;
    }

    /// <summary>
    ///  GET: api/Benefits
    /// </summary>
    /// <param name="skip">The number of records to skip</param>
    /// <param name="take">The number of records to take</param>
    /// <param name="sortBy">The field to sort by</param>
    /// <param name="sortDescending">Sort descending</param>
    /// <returns>The result</returns>
    [HttpGet]
    public async Task<IActionResult> GetBenefits([FromQuery(Name = "skip")] int skip = 0, [FromQuery(Name = "take")] int take = 10, [FromQuery(Name = "sortBy")] string sortBy = "Applicable_Model_ID", [FromQuery(Name = "sortDescending")] bool sortDescending = false)
    {
      var str = new string[] { "value1", "value2" };

      try
      {
        IQueryable<Benefits> query = this.aIValuationsContext.Benefits;
        var result = new EntityList<Benefits>
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
    ///  GET: api/Benefits/id
    /// </summary>
    /// <param name="id">The Markov States id</param>
    /// <returns>The result</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMarkovState(int id)
    {
      try
      {
        var benefits = await this.aIValuationsContext.Benefits.FindAsync(id).ConfigureAwait(false);
        if (benefits == null)
        {
          return this.NotFound();
        }
        else
        {
          return this.Ok(benefits);
        }
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  POST: api/Benefits
    /// </summary>
    /// <param name="benefits">The Markov States</param>
    /// <returns>The result</returns>
    [HttpPost]

    public async Task<IActionResult> Post([FromBody]Benefits benefits)
    {
      try
      {
        this.aIValuationsContext.Benefits.Add(benefits);
        await this.aIValuationsContext.SaveChangesAsync().ConfigureAwait(false);
        return this.CreatedAtAction("GetMarkovState", new { id = benefits.ID }, benefits);
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  POST: api/Benefits/BulkInsert
    /// </summary>
    /// <param name="lstBenefits">The list Markov States</param>
    /// <returns>The result</returns>
    [Route("BulkInsert")]
    [HttpPost]
    public async Task<IActionResult> BulkInsert([FromBody]List<Benefits> lstBenefits)
    {
      try
      {
        foreach (var benefits in lstBenefits)
        {
          this.aIValuationsContext.Benefits.Add(benefits);
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
    ///  POST: api/Benefits/id
    /// </summary>
    /// <param name="id">The Markov States id</param>
    /// <param name="value">The Markov States</param>
    /// <returns>The result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]Benefits value)
    {
      return this.Ok();
    }

    /// <summary>
    ///  DELETE: api/Benefits/id
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
