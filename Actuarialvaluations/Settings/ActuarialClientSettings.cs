using System;

namespace Actuarialvaluations.Settings
{
  /// <summary>
  /// The Client Settings Class
  /// </summary>
  public class ActuarialClientSettings
  {
    /// <summary>
    /// Gets or sets the date and time format
    /// </summary>
    public string DateTimeFormat { get; set; }

    /// <summary>
    /// Gets or sets the External API
    /// </summary>
    public Uri API { get; set; }
  }
}
