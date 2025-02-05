using System;
using Crews.Education.SequenceDecks.Models;

namespace Crews.Education.SequenceDecks.Services;

public interface IStateService
{
	ApplicationState State { get; set; }
	event Action OnStateChange;
}
