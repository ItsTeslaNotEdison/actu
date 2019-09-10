namespace Actuarialvaluations.Models.API.EntityList
{
  using System.Collections.Generic;

  /// <summary>
  /// The Entity Model
  /// </summary>
  /// <typeparam name="T">Generic return</typeparam>
  public class EntityList<T>
  {
    /// <summary>
    /// Gets or sets the value
    /// </summary>
    public List<T> value { get; set; }

  }
}
