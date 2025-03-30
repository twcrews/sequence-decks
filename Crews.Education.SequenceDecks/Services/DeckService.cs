using Crews.Education.SequenceDecks.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Crews.Education.SequenceDecks.Services;

public interface IDeckService
{
  Task<IEnumerable<Deck>?> GetDecksAsync();
}

public class JsonDeckOptions
{
  public const string ConfigurationSection = "Decks";
  public required Uri JsonUri { get; set; }
}

public class JsonDeckService(HttpClient httpClient, IOptions<JsonDeckOptions> options) : IDeckService
{
  public Task<IEnumerable<Deck>?> GetDecksAsync()
    => httpClient.GetFromJsonAsync<IEnumerable<Deck>>(options.Value.JsonUri);
}
