using Microsoft.JSInterop;

namespace Crews.Education.SequenceDecks.Services;

public class WindowService(IJSRuntime jsRuntime)
{
	public async Task EnterFullscreenAsync(string? elementId = null)
		=> await jsRuntime.InvokeVoidAsync("fullscreenFunctions.enterFullscreen", elementId);

	public async Task ExitFullscreenAsync()
		=> await jsRuntime.InvokeVoidAsync("fullscreenFunctions.exitFullscreen");

	public async Task<bool> IsFullscreenAsync()
		=> await jsRuntime.InvokeAsync<bool>("fullscreenFunctions.isFullscreen");

	public async Task ToggleFullscreenAsync(string? elementId = null)
	{
		bool isFullscreen = await IsFullscreenAsync();
		if (isFullscreen)
			await ExitFullscreenAsync();
		else
			await EnterFullscreenAsync(elementId);
	}
}
