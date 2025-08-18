using Crews.Education.SequenceDecks.Models;

namespace Crews.Education.SequenceDecks.Services;

public class AppStateService
{
	private bool _backgroundStarted;

	public bool BackgroundStartRequested => _backgroundStarted;

  public void StartBackground()
  {
    if (_backgroundStarted) return;
    _backgroundStarted = true;
    OnChange?.Invoke();
  }

  public event Action? OnChange;
}
