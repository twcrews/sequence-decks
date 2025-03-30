using Crews.Education.SequenceDecks.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

JsonSerializerOptions options = new();
options.Converters.Add(new JsonStringEnumConverter());

IEnumerable<AerialGroup> aerialGroups = JsonSerializer.Deserialize<IEnumerable<AerialGroup>>(
  File.ReadAllText(@"D:\source\repos\twcrews\aerials\manifest.json"), options) ?? [];

IEnumerable<Aerial> aerials = aerialGroups.SelectMany(group => group.Videos);
IEnumerable<Aerial.Variant> variants = aerials.SelectMany(aerial => aerial.Variants);

File.WriteAllLines(@"D:\source\repos\twcrews\aerials\urls.txt", variants.Select(variant => variant.Uri.OriginalString));
