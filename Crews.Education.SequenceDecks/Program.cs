using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Crews.Education.SequenceDecks;
using Crews.Education.SequenceDecks.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.Configure<JsonSerializerOptions>(options =>
{
  options.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.Configure<JsonAerialOptions>(options =>
{
  options.JsonUri = new("https://raw.githubusercontent.com/twcrews/aerials/refs/heads/master/manifest.json", UriKind.Absolute);
  options.BlacklistUri = new("/aerialsBlacklist.txt", UriKind.Relative);
});
builder.Services.Configure<JsonDeckOptions>(options => options.JsonUri = new("/decks.json", UriKind.Relative));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAerialService, JsonAerialService>();
builder.Services.AddScoped<IDeckService, JsonDeckService>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
