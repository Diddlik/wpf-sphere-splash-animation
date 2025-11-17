using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace WpfSphereSplash
{
    public partial class SplashScreen : Window
    {
        private readonly Random random = new Random();
        
        // Logo-Kreis-Definitionen (extrahiert aus dem DrawingImage)
        private readonly List<LogoCircle> logoCircles = new List<LogoCircle>
        {
            // Graue Kreise (#FF7E8087)
            new LogoCircle { X = 16.0631, Y = 19.0546, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 22.184, Y = 19.2153, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 18.7387, Y = 10.6694, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 22.6928, Y = 16.7469, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 15.7028, Y = 23.8034, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 11.8122, Y = 16.619, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 24.5228, Y = 19.7088, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 14.6735, Y = 8.53077, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 7.798, Y = 19.1937, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 23.6808, Y = 25.8242, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 25.0285, Y = 17.2431, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 21.1552, Y = 10.218, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 24.7972, Y = 8.8721, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 17.0746, Y = 27.8198, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 13.1293, Y = 25.8567, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 9.83694, Y = 12.2589, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 16.9528, Y = 8.01512, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 28.7536, Y = 14.8667, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 19.2364, Y = 28.2743, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 4.4746, Y = 16.8978, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 31.7939, Y = 19.5529, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 25.955, Y = 26.2041, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 13.6528, Y = 3.49311, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 5.53563, Y = 20.9982, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 23.4719, Y = 6.55986, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 27.1511, Y = 8.66005, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 22.5998, Y = 32.7103, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 13.4732, Y = 32.3996, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 3.7934, Y = 11.2945, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 32.4357, Y = 25.0721, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 19.4192, Y = 4.57163, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 8.99506, Y = 6.5709, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 7.44448, Y = 27.246, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 4.29638, Y = 14.4966, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 30.5799, Y = 11.0905, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 17.1893, Y = 33.9777, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 34.2467, Y = 21.1672, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 28.1075, Y = 30.6435, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 10.7405, Y = 2.64246, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 16.0227, Y = 1.15507, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 2.62509, Y = 18.7575, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 4.20061, Y = 24.8877, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 35.4227, Y = 17.7279, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 34.1572, Y = 12.5626, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 20.2629, Y = 35.0166, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 26.7293, Y = 31.2791, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 24.1084, Y = 1.95866, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 11.0608, Y = 32.337, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 7.72315, Y = 30.3982, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 28.6115, Y = 5.81974, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 4.00002, Y = 8.76757, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 21.6079, Y = 2.12994, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 5.96056, Y = 4.92925, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 6.47539, Y = 30.067, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 32.1983, Y = 27.376, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 15.6113, Y = 35.4735, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 2.01553, Y = 12.5966, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 32.0717, Y = 7.72346, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 11.9668, Y = 2.14288, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 1.68217, Y = 22.5748, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 34.1725, Y = 23.678, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 29.8263, Y = 30.814, Color = "#FF7E8087", Size = 2.0 },
            new LogoCircle { X = 34.5704, Y = 13.7106, Color = "#FF7E8087", Size = 2.0 },
            
            // Grüne Akzent-Kreise (#FFC4D82E)
            new LogoCircle { X = 29.7252, Y = 23.4317, Color = "#FFC4D82E", Size = 2.0 },
            new LogoCircle { X = 9.1142, Y = 23.2867, Color = "#FFC4D82E", Size = 2.0 },
            new LogoCircle { X = 11.066, Y = 6.78541, Color = "#FFC4D82E", Size = 2.0 },
            new LogoCircle { X = 30.7693, Y = 15.1849, Color = "#FFC4D82E", Size = 2.0 },
            new LogoCircle { X = 11.145, Y = 29.4211, Color = "#FFC4D82E", Size = 2.0 }
        };

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
            double scaleX = AnimationCanvas.Width / 36.0;
            double scaleY = AnimationCanvas.Height / 36.0;

            for (int i = 0; i < logoCircles.Count; i++)
            {
                var logoCircle = logoCircles[i];
                
                Ellipse circle = new Ellipse
                {
                    Width = logoCircle.Size * scaleX,
                    Height = logoCircle.Size * scaleY,
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(logoCircle.Color)),
                    Opacity = 0
                };

                double startX = random.NextDouble() * AnimationCanvas.Width;
                double startY = random.NextDouble() * AnimationCanvas.Height;

                double targetX = logoCircle.X * scaleX - (logoCircle.Size * scaleX / 2);
                double targetY = logoCircle.Y * scaleY - (logoCircle.Size * scaleY / 2);

                Canvas.SetLeft(circle, startX);
                Canvas.SetTop(circle, startY);
                AnimationCanvas.Children.Add(circle);

                AnimateCircle(circle, startX, startY, targetX, targetY, i);
            }
        }

        private void AnimateCircle(Ellipse circle, double startX, double startY, 
                                   double targetX, double targetY, int index)
        {
            double delay = index * 0.05;

            Storyboard storyboard = new Storyboard();
            storyboard.BeginTime = TimeSpan.FromSeconds(delay);

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

            storyboard.Completed += (s, e) =>
            {
                StartBreathingAnimation(circle);
                
                if (index == logoCircles.Count - 1)
                {
                    ShowCompleteLogo();
                }
            };
            storyboard.Begin();
        }

        private void StartBreathingAnimation(Ellipse circle)
        {
            Storyboard breathingStoryboard = new Storyboard
            {
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = true
            };

            DoubleAnimation breatheScale = new DoubleAnimation
            {
                From = 1,
                To = 1.1,
                Duration = TimeSpan.FromSeconds(2.0),
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard.SetTarget(breatheScale, circle);
            Storyboard.SetTargetProperty(breatheScale, new PropertyPath("RenderTransform.ScaleX"));
            breathingStoryboard.Children.Add(breatheScale);

            DoubleAnimation breatheScaleY = new DoubleAnimation
            {
                From = 1,
                To = 1.1,
                Duration = TimeSpan.FromSeconds(2.0),
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard.SetTarget(breatheScaleY, circle);
            Storyboard.SetTargetProperty(breatheScaleY, new PropertyPath("RenderTransform.ScaleY"));
            breathingStoryboard.Children.Add(breatheScaleY);

            breathingStoryboard.Begin();
        }

        private void ShowCompleteLogo()
        {
            var timer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                
                if (CompleteLogo != null)
                {
                    Storyboard logoFadeIn = new Storyboard();
                    
                    DoubleAnimation fadeIn = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(1.0),
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                    };
                    
                    Storyboard.SetTarget(fadeIn, CompleteLogo);
                    Storyboard.SetTargetProperty(fadeIn, new PropertyPath(OpacityProperty));
                    logoFadeIn.Children.Add(fadeIn);
                    
                    logoFadeIn.Begin();
                }
            };
            timer.Start();
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

    public class LogoCircle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Color { get; set; }
        public double Size { get; set; }
    }
}