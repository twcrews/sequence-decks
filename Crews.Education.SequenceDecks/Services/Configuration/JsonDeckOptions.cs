namespace Crews.Education.SequenceDecks.Services.Configuration;

public class JsonDeckOptions
{
	public const string ConfigurationSectionName = "JsonDecks";
	public required Uri JsonUri { get; set; }
}
