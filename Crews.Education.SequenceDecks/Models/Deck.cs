namespace Crews.Education.SequenceDecks.Models;

public record Deck
{
	public required string Name { get; init; }
	public required string Color { get; init; }
  public required string Slug { get; init; }
  public required IEnumerable<string> Content { get; init; }

	public IEnumerable<Card> GetCards() => Content
		.Select(value => new Card() { Color = Color, Value = value });

  public class Card
  {
    public required string Color { get; init; }
    public required string Value { get; init; }
  }
}
