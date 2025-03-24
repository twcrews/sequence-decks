namespace Crews.Education.SequenceDecks.Models;

public record AerialGroup
{
    public required string Name { get; set; }
    public IEnumerable<Aerial> Videos { get; set; } = [];
}

public record Aerial
{
    public required Uri Uri { get; set; }
    public IEnumerable<Caption> Captions { get; set; } = [];

    public record Caption
    {
        public required int Seconds { get; set; }
        public required int Text { get; set; }
    }
}
