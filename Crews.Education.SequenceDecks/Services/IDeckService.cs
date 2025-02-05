using Crews.Education.SequenceDecks.Models;

namespace Crews.Education.SequenceDecks.Services;

public interface IDeckService
{
	Task<IEnumerable<Deck>?> GetDecksAsync();
}
