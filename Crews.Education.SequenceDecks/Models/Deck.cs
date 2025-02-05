namespace Crews.Education.SequenceDecks.Models;

public record Deck
{
	public required string Name { get; init; }
	public required string Color { get; init; }
	public required IEnumerable<string> Content { get; init; }

	public IEnumerable<CardModel> GetCards() => Content
		.Select(value => new CardModel() { Color = Color, Value = value });
}
