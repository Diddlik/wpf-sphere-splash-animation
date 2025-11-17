# WPF Sphere Splash Animation

Eine animierte Splash-Screen-Anwendung für WPF mit pulsierenden Kreisen, die sich zu einer Sphäre formieren.

## Features

- ✨ 25 animierte Kreise fliegen von zufälligen Positionen zur Sphäre
- 🎯 Pulsierende Easing-Effekte beim Einfliegen
- 💚 Grüne Akzent-Kreise auf dunklem Hintergrund
- 🫁 Kontinuierliche "Atmungs"-Animation nach Formierung
- 🔄 Wiederholende Animation
- 🎨 Moderne, flüssige Animationen mit WPF Storyboards

## Technologie

- .NET 6.0
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

In `SplashScreen.xaml.cs` kannst du folgende Konstanten anpassen:

- `CircleCount`: Anzahl der Kreise (Standard: 25)
- `SphereRadius`: Radius der Sphäre (Standard: 150)
- `CircleSize`: Größe der einzelnen Kreise (Standard: 40)

## Lizenz

MIT License

## Autor

Diddlik
