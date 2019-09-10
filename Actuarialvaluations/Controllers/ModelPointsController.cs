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
  public class ModelPointsController : Controller
  {
    private readonly AIValuationsContext aIValuationsContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="ModelPointsController"/> class.
    /// </summary>
    /// <param name="context">The AIValuations DB context</param>
    public ModelPointsController(AIValuationsContext context)
    {
      this.aIValuationsContext = context;
    }

    /// <summary>
    ///  GET: api/ModelPoints
    /// </summary>
    /// <param name="skip">The number of records to skip</param>
    /// <param name="take">The number of records to take</param>
    /// <param name="sortBy">The field to sort by</param>
    /// <param name="sortDescending">Sort descending</param>
    /// <returns>The result</returns>
    [HttpGet]
    public async Task<IActionResult> GetModelPoints([FromQuery(Name = "skip")] int skip = 0, [FromQuery(Name = "take")] int take = 10, [FromQuery(Name = "sortBy")] string sortBy = "Applicable_Model_ID", [FromQuery(Name = "sortDescending")] bool sortDescending = false)
    {
      var str = new string[] { "value1", "value2" };

      try
      {
        IQueryable<ModelPoints> query = this.aIValuationsContext.ModelPoints;
        var result = new EntityList<ModelPoints>
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
    ///  GET: api/ModelPoints/id
    /// </summary>
    /// <param name="id">The Markov States id</param>
    /// <returns>The result</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMarkovState(int id)
    {
      try
      {
        var modelPoints = await this.aIValuationsContext.ModelPoints.FindAsync(id).ConfigureAwait(false);
        if (modelPoints == null)
        {
          return this.NotFound();
        }
        else
        {
          return this.Ok(modelPoints);
        }
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  POST: api/ModelPoints
    /// </summary>
    /// <param name="modelPoints">The Markov States</param>
    /// <returns>The result</returns>
    [HttpPost]

    public async Task<IActionResult> Post([FromBody]ModelPoints modelPoints)
    {
      try
      {
        this.aIValuationsContext.ModelPoints.Add(modelPoints);
        await this.aIValuationsContext.SaveChangesAsync().ConfigureAwait(false);
        return this.CreatedAtAction("GetMarkovState", new { id = modelPoints.ID }, modelPoints);
      }
      catch (Exception ex)
      {
        return this.BadRequest(ex.Message);
      }
    }

    /// <summary>
    ///  POST: api/ModelPoints/BulkInsert
    /// </summary>
    /// <param name="lstModelPoints">The list Markov States</param>
    /// <returns>The result</returns>
    [Route("BulkInsert")]
    [HttpPost]
    public async Task<IActionResult> BulkInsert([FromBody]List<ModelPoints> lstModelPoints)
    {
      try
      {
        foreach (var modelPoints in lstModelPoints)
        {
          this.aIValuationsContext.ModelPoints.Add(modelPoints);
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
    ///  POST: api/ModelPoints/id
    /// </summary>
    /// <param name="id">The Markov States id</param>
    /// <param name="value">The Markov States</param>
    /// <returns>The result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]ModelPoints value)
    {
      return this.Ok();
    }

    /// <summary>
    ///  DELETE: api/ModelPoints/id
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
