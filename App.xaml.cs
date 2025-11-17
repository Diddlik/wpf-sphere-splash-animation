using System.Windows;

namespace WpfSphereSplash
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Splash Screen anzeigen
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();

            // Nach 8 Sekunden Splash Screen schließen und Hauptfenster öffnen
            splashScreen.CloseAfterDelay(8);

            // Hauptfenster erstellen (wird nach Splash angezeigt)
            MainWindow mainWindow = new MainWindow();
            
            splashScreen.Closed += (s, args) => mainWindow.Show();
        }
    }
}