using Crews.Education.SequenceDecks.Models;

namespace Crews.Education.SequenceDecks.Services;

public class GlobalStateService : IStateService
{
	private ApplicationState _state;
	public ApplicationState State { 
		get => _state; 
		set 
		{
			_state = value;
			OnStateChange?.Invoke();
		} 
	}

	public event Action? OnStateChange;

	public GlobalStateService()
	{
		_state = new() { ThemeColor = "#666" };
	}
}
