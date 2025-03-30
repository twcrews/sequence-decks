using Crews.Education.SequenceDecks.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace Crews.Education.SequenceDecks.Services;

public interface IAerialService
{
  Task<IEnumerable<AerialGroup>?> GetAerialGroupsAsync();
}

public class JsonAerialOptions
{
  public const string ConfigurationSection = "Aerials";
  public required Uri JsonUri { get; set; }
}

public class JsonAerialService(HttpClient httpClient, IOptions<JsonAerialOptions> serviceOptions, IOptions<JsonSerializerOptions> jsonOptions) : IAerialService
{
  public Task<IEnumerable<AerialGroup>?> GetAerialGroupsAsync() 
    => httpClient.GetFromJsonAsync<IEnumerable<AerialGroup>>(serviceOptions.Value.JsonUri, jsonOptions.Value);
}
