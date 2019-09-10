namespace Actuarialvaluations.Models
{
  using System.Collections.Generic;

  public class EntityList<T>
  {
    /// <summary>
    /// Gets or sets the total
    /// </summary>
    public int Total { get; set; }


    /// <summary>
    /// Gets or sets the entities
    /// </summary>
    public List<T> Entities { get; set; }
  }
}
