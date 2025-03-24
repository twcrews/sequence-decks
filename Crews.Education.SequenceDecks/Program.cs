using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Crews.Education.SequenceDecks;
using Crews.Education.SequenceDecks.Services;
using Crews.Education.SequenceDecks.Services.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.Configure<JsonDeckOptions>(options => options.JsonUri = new("/decks.json", UriKind.Relative));
builder.Services.AddScoped<IDeckService, JsonDeckService>();

await builder.Build().RunAsync();
