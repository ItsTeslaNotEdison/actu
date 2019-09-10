namespace Actuarialvaluations.Models.API
{
  using System;
  using System.Collections.Generic;

  public class Entity
  {

    /// <summary>
    /// Gets the properties
    /// </summary>
    protected Dictionary<string, object> Properties { get; private set; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets or sets the id
    /// </summary>
    public Guid? Id { get; set; }


    #region Dynamics

    #endregion

    #region Instance Methods

    /// <summary>
    /// Get the value of a property
    /// </summary>
    /// <typeparam name="T">The type</typeparam>
    /// <param name="key">The key</param>
    /// <returns>The value of the property</returns>
    public T GetProperty<T>(string key)
    {
      if (this.Properties.ContainsKey(key))
      {
        return (T)this.Properties[key];
      }
      else
      {
        return default(T);
      }
    }

    /// <summary>
    /// Set the value of a property
    /// </summary>
    /// <param name="key">The key</param>
    /// <param name="value">The value</param>
    public void SetProperty(string key, object value)
    {
      if (this.Properties.ContainsKey(key))
      {
        this.Properties[key] = value;
      }
      else
      {
        this.Properties.Add(key, value);
      }
    }

    #endregion
  }
}
