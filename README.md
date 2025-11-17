# WPF Sphere Splash Animation

Eine animierte Splash-Screen-Anwendung für WPF mit einer spektakulären Zerfall- und Sammel-Animation.

## Features

- ✨ Logo-Zerfall-Effekt: Das Logo zerfällt in einzelne Kreise
- 🎯 Sammel-Animation: Die Kreise fliegen zurück und formen das Logo neu
- 💫 Elastische Rückprall-Effekte beim Zusammenfügen
- 💚 Grüne Akzent-Kreise auf dunklem Hintergrund
- 🫁 Kontinuierliche "Atmungs"-Animation nach Formierung
- 🎨 Moderne, flüssige Animationen mit WPF Storyboards
- ⚡ Gestaffelte Timing-Effekte für dynamische Wellenanimation

## Animationsphasen

1. **Anfang**: Logo ist in zusammengesetztem Zustand sichtbar
2. **Zerfall**: Kreise fliegen auseinander zu zufälligen Positionen
3. **Sammeln**: Kreise kehren zurück und formen das Logo neu
4. **Atmung**: Subtile pulsieren Breathing-Animation
5. **Finale**: Vollständiges Logo wird eingeblendet

## Technologie

- .NET 10.0
- WPF (Windows Presentation Foundation)
- C# 10
- XAML

## Installation

```bash
git clone https://github.com/Diddlik/wpf-sphere-splash-animation.git
cd wpf-sphere-splash-animation
dotnet restore
dotnet run
```

## Verwendung

Die Anwendung startet automatisch mit dem animierten Splash Screen. Nach 8 Sekunden wird das Hauptfenster angezeigt.

### Anpassungen

In `SplashScreen.xaml.cs` kannst du folgende Parameter anpassen:

- Timing der Zerfall-Animation (Phase 2)
- Timing der Sammel-Animation (Phase 3)
- Elastizität des Rückprall-Effekts
- Anzahl der Oszillationen beim Bounce-Effekt

## Lizenz

MIT License

## Autor

Diddlik
