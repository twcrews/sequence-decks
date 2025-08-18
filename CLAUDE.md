# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a Blazor WebAssembly single-page application that replaces a WPF predecessor for educational sequence/sight word cards. The app displays different card decks loaded from JSON data with animated backgrounds.

## Development Commands

**Build and run the application:**
```bash
dotnet run --project Crews.Education.SequenceDecks
```

**Run tests:**
```bash
dotnet test
```

**Build for production:**
```bash
dotnet publish Crews.Education.SequenceDecks -c Release
```

**Run tests in watch mode:**
```bash
dotnet watch test --project Crews.Education.SequenceDecks.Tests
```

**Run application in watch mode:**
```bash
dotnet watch --project Crews.Education.SequenceDecks
```

## Architecture

### Core Structure
- **Blazor WebAssembly App**: Client-side SPA targeting .NET 9.0
- **Service-based architecture**: Data access through dependency-injected services
- **JSON data sources**: Decks and aerials loaded from static JSON files in wwwroot
- **Local storage**: Uses Blazored.LocalStorage for client-side persistence

### Key Services
- `AppStateService`: Singleton service managing application state (background ready, started status, multiple deck selection)
- `IDeckService/JsonDeckService`: Handles loading card deck data from `/decks.json`
- `IAerialService/JsonAerialService`: Manages background aerial data from `/aerials.json` with blacklist support
- `WindowService`: Browser window interaction utilities

### Data Models
- `Deck`: Represents a card deck with name, color, slug, and content
- `Deck.Card`: Individual cards with color and value properties
- `Aerial`: Background animations/videos

### Component Structure
- `DeckSelector`: Main component displaying available decks with checkbox selection and Start button (formerly Home.razor)
  - Reads selected decks from URL query string on load
  - Updates URL with query string when Start is clicked
- `DeckCards`: Interactive card sequence component with stack layout and fall-away animations (formerly Cards.razor)
  - Displays cards in a stack similar to deck buttons
  - Click top card to reveal next card with fall-away animation
  - Progress indicator shows current position in sequence
  - Completion screen when all cards are viewed
  - Reads selected decks from URL query string `?decks=deck1,deck2`
- Navigation managed through URL query strings for shareable deck combinations
- Multi-deck selection allows users to choose multiple decks and combines their cards randomly
- URLs can be saved and shared for specific deck combinations

### Static Assets
- `/wwwroot/decks.json`: Card deck definitions
- `/wwwroot/aerials.json`: Background animation data
- `/wwwroot/aerialsBlacklist.txt`: Excluded aerials
- Custom CSS with component-scoped styles

### Azure Static Web Apps
The project includes `staticwebapp.config.json` for Azure SWA deployment with SPA fallback configuration that routes all requests to index.html.

## Testing
Uses xUnit testing framework with the main test project in `Crews.Education.SequenceDecks.Tests/`.

## Code Style Guidelines
- **No comments**: Do not add code comments unless they are critical to understanding complex or non-obvious logic
- Follow existing C# and Blazor conventions in the codebase
- Use component-scoped CSS for styling