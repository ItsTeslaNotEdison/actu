namespace Actuarialvaluations.Models.API
{
  using System;
  using Newtonsoft.Json;

  /// <summary>
  /// The Markov state class
  /// </summary>
  public class MarkovStateDropdown : Entity
  {
    /// <summary>
    /// Gets or sets StateId
    /// </summary>
    [JsonProperty("StateId")]
    public int StateId { get; set; }

    /// <summary>
    /// Gets or sets StateName
    /// </summary>
    [JsonProperty("StateName")]
    public string StateName { get; set; }

    /// <summary>
    /// Gets or sets StateCode
    /// </summary>
    [JsonProperty("StateCode")]
    public string StateCode { get; set; }

    /// <summary>
    /// Gets or sets StartDate
    /// </summary>
    [JsonProperty("StartDate")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets EndDate
    /// </summary>
    [JsonProperty("EndDate")]
    public DateTime EndDate { get; set; }
  }
}
