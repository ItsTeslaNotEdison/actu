

namespace Actuarialvaluations.API
{
  using System;
  using System.Collections.Generic;
  using System.Net;
  using System.Net.Http;
  using System.Threading.Tasks;
  using Actuarialvaluations.Settings;
  using Microsoft.Extensions.Options;
  using Newtonsoft.Json;

  /// <summary>
  /// The API Call Class
  /// </summary>
  public sealed class APIManager
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="APIManager"/> class
    /// </summary>
    /// <param name="actuarialClientSettings">The Actuarial Client Settings</param>
    public APIManager(IOptions<ActuarialClientSettings> actuarialClientSettings)
    {
      this.HttpClient = new HttpClient
      {
        BaseAddress = actuarialClientSettings.Value.API,
        Timeout = new TimeSpan(0, 0, 30),
      };
    }

    /// <summary>
    /// Gets or sets the HTTP client
    /// </summary>
    private HttpClient HttpClient { get; set; }



    /// <summary>
    /// Retrieve the entities
    /// </summary>
    /// <typeparam name="T">The type</typeparam>
    /// <param name="apiURL">The apiURL entity</param>
    /// <param name="headers">The headers entity</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<List<T>> RetrieveMultiple<T>(string apiURL, Dictionary<string, string> headers = null)
      where T : class, new()
    {
      HttpResponseMessage response = await this.Get($"{apiURL}", headers).ConfigureAwait(false);
      return JsonConvert.DeserializeObject<List<T>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
    }

    /// <summary>
    /// Perform a Get operation
    /// </summary>
    /// <param name="query">The query</param>
    /// <param name="headers">The additional headers to set on the request</param>
    /// <returns>The result of the Get</returns>
    public async Task<HttpResponseMessage> Get(string query, Dictionary<string, string> headers = null)
    {
      using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"/{query}"))
      {
        if (headers != null)
        {
          foreach (KeyValuePair<string, string> header in headers)
          {
            request.Headers.Add(header.Key, header.Value);
          }
        }

        HttpResponseMessage response = await this.HttpClient.GetAsync(query).ConfigureAwait(false);
        switch (response.StatusCode)
        {
          case HttpStatusCode.OK: return response;
          default: throw new Exception();
        }
      }
    }
  }
}
