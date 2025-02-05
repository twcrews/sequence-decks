using System.Net.Http.Json;
using Crews.Education.SequenceDecks.Models;
using Crews.Education.SequenceDecks.Services.Configuration;
using Microsoft.Extensions.Options;

namespace Crews.Education.SequenceDecks.Services;

public class JsonDeckService(HttpClient httpClient, IOptions<JsonDeckOptions> options) : IDeckService
{
	public Task<IEnumerable<Deck>?> GetDecksAsync()
		=> httpClient.GetFromJsonAsync<IEnumerable<Deck>>(options.Value.JsonUri);
}
