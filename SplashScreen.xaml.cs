using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WpfSphereSplash
{
    public partial class SplashScreen : Window
    {
        private const int CircleCount = 25; // Anzahl der Kreise
        private const double SphereRadius = 150; // Radius der finalen Sphäre
        private const double CircleSize = 40; // Größe der einzelnen Kreise
        private readonly Random random = new Random();

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateAndAnimateCircles();
            AnimateLoadingText();
        }

        private void CreateAndAnimateCircles()
        {
            double centerX = AnimationCanvas.Width / 2;
            double centerY = AnimationCanvas.Height / 2;

            for (int i = 0; i < CircleCount; i++)
            {
                // Kreis erstellen
                Ellipse circle = new Ellipse
                {
                    Width = CircleSize,
                    Height = CircleSize,
                    Fill = GetCircleColor(i),
                    Opacity = 0
                };

                // Zufällige Startposition (außerhalb des sichtbaren Bereichs)
                double startX = random.NextDouble() * AnimationCanvas.Width;
                double startY = random.NextDouble() * AnimationCanvas.Height;

                // Endposition auf der Sphäre berechnen
                double angle = (2 * Math.PI / CircleCount) * i;
                double targetX = centerX + Math.Cos(angle) * SphereRadius - CircleSize / 2;
                double targetY = centerY + Math.Sin(angle) * SphereRadius - CircleSize / 2;

                // Kreis zum Canvas hinzufügen
                Canvas.SetLeft(circle, startX);
                Canvas.SetTop(circle, startY);
                AnimationCanvas.Children.Add(circle);

                // Animation erstellen
                AnimateCircle(circle, startX, startY, targetX, targetY, i);
            }
        }

        private Brush GetCircleColor(int index)
        {
            // Einige Kreise in Grün (Akzent), die meisten in Grau
            if (index % 8 == 0 || index % 13 == 0)
            {
                return new SolidColorBrush(Color.FromRgb(139, 195, 74)); // Grün
            }
            else
            {
                // Verschiedene Grautöne
                byte grayValue = (byte)random.Next(100, 180);
                return new SolidColorBrush(Color.FromRgb(grayValue, grayValue, grayValue));
            }
        }

        private void AnimateCircle(Ellipse circle, double startX, double startY, 
                                   double targetX, double targetY, int index)
        {
            // Verzögerung für gestaffelten Start
            double delay = index * 0.08;

            // Storyboard für alle Animationen
            Storyboard storyboard = new Storyboard();
            storyboard.BeginTime = TimeSpan.FromSeconds(delay);

            // 1. Fade In Animation
            DoubleAnimation fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            Storyboard.SetTarget(fadeIn, circle);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeIn);

            // 2. X-Position Animation
            DoubleAnimation moveX = new DoubleAnimation
            {
                From = startX,
                To = targetX,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(moveX, circle);
            Storyboard.SetTargetProperty(moveX, new PropertyPath(Canvas.LeftProperty));
            storyboard.Children.Add(moveX);

            // 3. Y-Position Animation
            DoubleAnimation moveY = new DoubleAnimation
            {
                From = startY,
                To = targetY,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(moveY, circle);
            Storyboard.SetTargetProperty(moveY, new PropertyPath(Canvas.TopProperty));
            storyboard.Children.Add(moveY);

            // 4. Pulsier-Animation (Scale)
            ScaleTransform scaleTransform = new ScaleTransform(1, 1);
            circle.RenderTransform = scaleTransform;
            circle.RenderTransformOrigin = new Point(0.5, 0.5);

            DoubleAnimation pulseX = new DoubleAnimation
            {
                From = 0.3,
                To = 1,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new ElasticEase { EasingMode = EasingMode.EaseOut, Oscillations = 2 }
            };
            Storyboard.SetTarget(pulseX, circle);
            Storyboard.SetTargetProperty(pulseX, new PropertyPath("RenderTransform.ScaleX"));
            storyboard.Children.Add(pulseX);

            DoubleAnimation pulseY = new DoubleAnimation
            {
                From = 0.3,
                To = 1,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new ElasticEase { EasingMode = EasingMode.EaseOut, Oscillations = 2 }
            };
            Storyboard.SetTarget(pulseY, circle);
            Storyboard.SetTargetProperty(pulseY, new PropertyPath("RenderTransform.ScaleY"));
            storyboard.Children.Add(pulseY);

            // Animation starten
            storyboard.Begin();

            // Nach Abschluss: Atmungs-Animation starten
            storyboard.Completed += (s, e) => StartBreathingAnimation(circle);
        }

        private void StartBreathingAnimation(Ellipse circle)
        {
            // Kontinuierliche Atmungs-Animation
            Storyboard breathingStoryboard = new Storyboard
            {
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = true
            };

            DoubleAnimation breatheScale = new DoubleAnimation
            {
                From = 1,
                To = 1.15,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard.SetTarget(breatheScale, circle);
            Storyboard.SetTargetProperty(breatheScale, new PropertyPath("RenderTransform.ScaleX"));
            breathingStoryboard.Children.Add(breatheScale);

            DoubleAnimation breatheScaleY = new DoubleAnimation
            {
                From = 1,
                To = 1.15,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard.SetTarget(breatheScaleY, circle);
            Storyboard.SetTargetProperty(breatheScaleY, new PropertyPath("RenderTransform.ScaleY"));
            breathingStoryboard.Children.Add(breatheScaleY);

            breathingStoryboard.Begin();
        }

        private void AnimateLoadingText()
        {
            Storyboard storyboard = new Storyboard();
            storyboard.BeginTime = TimeSpan.FromSeconds(0.5);

            DoubleAnimation fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1)
            };
            Storyboard.SetTarget(fadeIn, LoadingText);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeIn);

            storyboard.Begin();
        }

        public void CloseAfterDelay(int seconds)
        {
            var timer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(seconds)
            };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                this.Close();
            };
            timer.Start();
        }
    }
}