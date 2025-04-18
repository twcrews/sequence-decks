namespace Crews.Education.SequenceDecks.Services;

public class AppStateService
{
	private bool _backgroundReady;
	private bool _started;

	public bool BackgroundReady 
	{ 
		get => _backgroundReady; 
		set
		{
			_backgroundReady = value;
			OnChange?.Invoke();
		} 
	}

	public bool Started
	{
		get => _started;
		set
		{
			_started = value;
			OnChange?.Invoke();
		}
	}

  public event Action? OnChange;
}
