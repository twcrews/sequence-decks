using Crews.Education.SequenceDecks.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;

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
    if (groups == null)
    {
      return null;
    }

    if (serviceOptions.Value.BlacklistUri != null)
    {
      string blacklistText = await httpClient.GetStringAsync(serviceOptions.Value.BlacklistUri);
      string[] blacklist = blacklistText.Split("\n");

      List<AerialGroup> filteredGroups = [];
      foreach (AerialGroup group in groups)
      {
        AerialGroup filtered = group;
        filtered.Videos = filtered.Videos.Where(video => !blacklist.Contains(video.ID.ToString()));
        filteredGroups.Add(filtered);
      }
      return filteredGroups;
    }

    return groups;
  }
}
