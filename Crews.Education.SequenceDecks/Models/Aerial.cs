namespace Crews.Education.SequenceDecks.Models;

public record AerialGroup
{
  public required string Location { get; set; }
  public IEnumerable<Aerial> Videos { get; set; } = [];
}

public record Aerial
{
  public required Guid ID { get; set; }
  public required string Author { get; set; }
  public IEnumerable<Variant> Variants { get; set; } = [];
  public IEnumerable<Caption> Captions { get; set; } = [];

  public record Caption
  {
    public required int Seconds { get; set; }
    public required string Text { get; set; }
  }

  public record Variant
  {
    public required Resolution Resolution { get; set; }
    public required ColorRange ColorRange { get; set; }
    public required Uri Uri { get; set; }
  }

  public enum Resolution
  {
    HD,
    Uhd
  }

  public enum ColorRange
  {
    Sdr,
    Hdr
  }
}
