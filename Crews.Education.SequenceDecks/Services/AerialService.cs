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
  public Uri? BlacklistUri { get; set; }
}

public class JsonAerialService(
  HttpClient httpClient, 
  IOptions<JsonAerialOptions> serviceOptions, 
  IOptions<JsonSerializerOptions> jsonOptions) 
  : IAerialService
{
  public async Task<IEnumerable<AerialGroup>?> GetAerialGroupsAsync()
  {
    IEnumerable<AerialGroup>? groups = await httpClient.GetFromJsonAsync<IEnumerable<AerialGroup>>(
      serviceOptions.Value.JsonUri, jsonOptions.Value);

    if (serviceOptions.Value.BlacklistUri != null)
    {
      string blacklistText = await httpClient.GetStringAsync(serviceOptions.Value.BlacklistUri);
      string[] blacklist = blacklistText.Split("\n");
      return groups?.Where(group => !blacklist.Any(item => group.Videos.Select(video => video.ID).ToString()?.Contains(item) ?? false));
    }

    return groups;
  }
}
