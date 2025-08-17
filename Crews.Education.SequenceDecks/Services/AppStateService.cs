using Crews.Education.SequenceDecks.Models;

namespace Crews.Education.SequenceDecks.Services;

public class AppStateService
{
	private bool _backgroundReady;
	private bool _started;
	private HashSet<string> _selectedDeckSlugs = new();

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

	public IReadOnlySet<string> SelectedDeckSlugs => _selectedDeckSlugs;

	public bool IsViewingCards => Started && _selectedDeckSlugs.Count > 0;

	public bool HasSelectedDecks => _selectedDeckSlugs.Count > 0;

	public void ToggleDeckSelection(string deckSlug)
	{
		if (_selectedDeckSlugs.Contains(deckSlug))
		{
			_selectedDeckSlugs.Remove(deckSlug);
		}
		else
		{
			_selectedDeckSlugs.Add(deckSlug);
		}
		OnChange?.Invoke();
	}

	public bool IsDeckSelected(string deckSlug) => _selectedDeckSlugs.Contains(deckSlug);

	public void ClearSelection()
	{
		_selectedDeckSlugs.Clear();
		OnChange?.Invoke();
	}

  public event Action? OnChange;
}
