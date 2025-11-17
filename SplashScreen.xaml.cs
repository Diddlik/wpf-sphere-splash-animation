using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;

namespace WpfSphereSplash
{
    public partial class SplashScreen : Window
    {
        private readonly Random random = new Random();
        private readonly List<SphereCircle> sphereCircles = new List<SphereCircle>();
        private double currentRotationX = 0;
        private double currentRotationY = 0;
        private double currentRotationZ = 0;
        
        // Sphere parameters
        private const double SphereRadius = 200.0;
        private const double CameraDistance = 800.0;
        private const double RotationSpeed = 0.02; // radians per frame
        
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
            ConvertToSphereCoordinates();
            CreateAndAnimateCircles();
            AnimateLoadingText();
        }
        
        /// <summary>
        /// Converts the 2D logo circles to 3D sphere coordinates using Fibonacci spiral distribution
        /// </summary>
        private void ConvertToSphereCoordinates()
        {
            int count = logoCircles.Count;
            double goldenRatio = (1.0 + Math.Sqrt(5.0)) / 2.0;
            double angleIncrement = Math.PI * 2.0 * goldenRatio;
            
            for (int i = 0; i < count; i++)
            {
                var logoCircle = logoCircles[i];
                
                // Fibonacci spiral distribution for uniform sphere coverage
                double t = (double)i / count;
                double inclination = Math.Acos(1.0 - 2.0 * t); // theta: 0 to PI
                double azimuth = angleIncrement * i; // phi: 0 to 2PI
                
                // Convert spherical to Cartesian coordinates
                double x = SphereRadius * Math.Sin(inclination) * Math.Cos(azimuth);
                double y = SphereRadius * Math.Sin(inclination) * Math.Sin(azimuth);
                double z = SphereRadius * Math.Cos(inclination);
                
                var sphereCircle = new SphereCircle
                {
                    OriginalX = logoCircle.X,
                    OriginalY = logoCircle.Y,
                    Theta = inclination,
                    Phi = azimuth,
                    X = x,
                    Y = y,
                    Z = z,
                    Color = logoCircle.Color,
                    Size = logoCircle.Size
                };
                
                sphereCircles.Add(sphereCircle);
            }
        }
        
        /// <summary>
        /// Projects 3D coordinates to 2D canvas with perspective
        /// </summary>
        private Point ProjectToCanvas(double x, double y, double z)
        {
            // Perspective projection
            double factor = CameraDistance / (CameraDistance + z);
            double projectedX = x * factor + AnimationCanvas.Width / 2;
            double projectedY = y * factor + AnimationCanvas.Height / 2;
            
            return new Point(projectedX, projectedY);
        }
        
        /// <summary>
        /// Rotates a 3D point around X, Y, and Z axes
        /// </summary>
        private (double x, double y, double z) RotatePoint(double x, double y, double z, double rotX, double rotY, double rotZ)
        {
            // Rotation around X axis
            double cosX = Math.Cos(rotX);
            double sinX = Math.Sin(rotX);
            double y1 = y * cosX - z * sinX;
            double z1 = y * sinX + z * cosX;
            y = y1;
            z = z1;
            
            // Rotation around Y axis
            double cosY = Math.Cos(rotY);
            double sinY = Math.Sin(rotY);
            double x1 = x * cosY + z * sinY;
            z1 = -x * sinY + z * cosY;
            x = x1;
            z = z1;
            
            // Rotation around Z axis
            double cosZ = Math.Cos(rotZ);
            double sinZ = Math.Sin(rotZ);
            x1 = x * cosZ - y * sinZ;
            y1 = x * sinZ + y * cosZ;
            x = x1;
            y = y1;
            
            return (x, y, z);
        }
        
        /// <summary>
        /// Calculates scale factor based on Z depth (closer = larger, further = smaller)
        /// </summary>
        private double GetDepthScale(double z)
        {
            return CameraDistance / (CameraDistance + z);
        }
        
        /// <summary>
        /// Calculates opacity based on Z depth (closer = more opaque, further = more transparent)
        /// </summary>
        private double GetDepthOpacity(double z)
        {
            double scale = GetDepthScale(z);
            return Math.Max(0.3, Math.Min(1.0, scale));
        }

        private void CreateAndAnimateCircles()
        {
            double scaleX = AnimationCanvas.Width / 36.0;
            double scaleY = AnimationCanvas.Height / 36.0;

            // Sort circles by Z-depth (back to front) for proper rendering
            var sortedCircles = sphereCircles.OrderBy(c => c.Z).ToList();
            
            for (int i = 0; i < sortedCircles.Count; i++)
            {
                var sphereCircle = sortedCircles[i];
                
                Ellipse circle = new Ellipse
                {
                    Width = sphereCircle.Size * scaleX,
                    Height = sphereCircle.Size * scaleY,
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sphereCircle.Color)),
                    Opacity = 1,
                    Tag = sphereCircle // Store reference to sphere circle
                };

                // Generate random scatter position
                double scatterX = random.NextDouble() * AnimationCanvas.Width;
                double scatterY = random.NextDouble() * AnimationCanvas.Height;

                // Start at scattered position
                Canvas.SetLeft(circle, scatterX);
                Canvas.SetTop(circle, scatterY);
                Canvas.SetZIndex(circle, (int)(sphereCircle.Z + 1000)); // Z-ordering
                
                AnimationCanvas.Children.Add(circle);
                sphereCircle.UIElement = circle;

                AnimateCircle(circle, sphereCircle, scatterX, scatterY, i);
            }
        }

        private void AnimateCircle(Ellipse circle, SphereCircle sphereCircle, 
                                   double scatterX, double scatterY, int index)
        {
            double delay = index * 0.02; // Stagger the animation

            // Phase 1: Brief pause at scattered position
            Storyboard pauseStoryboard = new Storyboard();
            pauseStoryboard.BeginTime = TimeSpan.FromSeconds(0.5 + delay);
            pauseStoryboard.Duration = TimeSpan.FromSeconds(0.1);
            pauseStoryboard.Completed += (s, e) =>
            {
                // Phase 2: Form sphere - circles fly to sphere positions
                FormSphere(circle, sphereCircle, scatterX, scatterY, index);
            };
            pauseStoryboard.Begin();
        }

        private void FormSphere(Ellipse circle, SphereCircle sphereCircle,
                               double scatterX, double scatterY, int index)
        {
            // Initial rotation for sphere formation
            var (rotX, rotY, rotZ) = RotatePoint(sphereCircle.X, sphereCircle.Y, sphereCircle.Z, 
                                                  currentRotationX, currentRotationY, currentRotationZ);
            Point projected = ProjectToCanvas(rotX, rotY, rotZ);
            double depthScale = GetDepthScale(rotZ);
            double depthOpacity = GetDepthOpacity(rotZ);
            
            Storyboard formStoryboard = new Storyboard();

            // Move to sphere position
            DoubleAnimation moveX = new DoubleAnimation
            {
                From = scatterX,
                To = projected.X - circle.Width / 2,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(moveX, circle);
            Storyboard.SetTargetProperty(moveX, new PropertyPath(Canvas.LeftProperty));
            formStoryboard.Children.Add(moveX);

            DoubleAnimation moveY = new DoubleAnimation
            {
                From = scatterY,
                To = projected.Y - circle.Height / 2,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(moveY, circle);
            Storyboard.SetTargetProperty(moveY, new PropertyPath(Canvas.TopProperty));
            formStoryboard.Children.Add(moveY);

            // Add scale transformation based on depth
            if (circle.RenderTransform == null || !(circle.RenderTransform is ScaleTransform))
            {
                ScaleTransform scaleTransform = new ScaleTransform(1, 1);
                circle.RenderTransform = scaleTransform;
                circle.RenderTransformOrigin = new Point(0.5, 0.5);
            }

            DoubleAnimation scaleX = new DoubleAnimation
            {
                From = 1.0,
                To = depthScale,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(scaleX, circle);
            Storyboard.SetTargetProperty(scaleX, new PropertyPath("RenderTransform.ScaleX"));
            formStoryboard.Children.Add(scaleX);

            DoubleAnimation scaleY = new DoubleAnimation
            {
                From = 1.0,
                To = depthScale,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(scaleY, circle);
            Storyboard.SetTargetProperty(scaleY, new PropertyPath("RenderTransform.ScaleY"));
            formStoryboard.Children.Add(scaleY);

            // Fade based on depth
            DoubleAnimation fadeAnim = new DoubleAnimation
            {
                From = 1.0,
                To = depthOpacity,
                Duration = TimeSpan.FromSeconds(1.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(fadeAnim, circle);
            Storyboard.SetTargetProperty(fadeAnim, new PropertyPath(OpacityProperty));
            formStoryboard.Children.Add(fadeAnim);

            formStoryboard.Completed += (s, e) =>
            {
                if (index == sphereCircles.Count - 1)
                {
                    // Start continuous rotation and breathing
                    StartRotationAndBreathing();
                }
            };
            formStoryboard.Begin();
        }

        private void StartRotationAndBreathing()
        {
            var rotationTimer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(30) // ~33 FPS
            };
            
            int frameCount = 0;
            rotationTimer.Tick += (s, e) =>
            {
                frameCount++;
                
                // Update rotation angles
                currentRotationX += RotationSpeed * 0.7;
                currentRotationY += RotationSpeed * 1.0;
                currentRotationZ += RotationSpeed * 0.3;
                
                // Update each circle's position
                foreach (var sphereCircle in sphereCircles)
                {
                    if (sphereCircle.UIElement == null) continue;
                    
                    // Rotate the sphere point
                    var (rotX, rotY, rotZ) = RotatePoint(sphereCircle.X, sphereCircle.Y, sphereCircle.Z,
                                                          currentRotationX, currentRotationY, currentRotationZ);
                    
                    // Add breathing effect (subtle pulsation)
                    double breathingFactor = 1.0 + 0.05 * Math.Sin(frameCount * 0.02);
                    rotX *= breathingFactor;
                    rotY *= breathingFactor;
                    rotZ *= breathingFactor;
                    
                    // Project to 2D
                    Point projected = ProjectToCanvas(rotX, rotY, rotZ);
                    double depthScale = GetDepthScale(rotZ);
                    double depthOpacity = GetDepthOpacity(rotZ);
                    
                    // Update UI element
                    var circle = sphereCircle.UIElement;
                    Canvas.SetLeft(circle, projected.X - circle.Width / 2);
                    Canvas.SetTop(circle, projected.Y - circle.Height / 2);
                    Canvas.SetZIndex(circle, (int)(rotZ + 1000)); // Update Z-ordering
                    
                    if (circle.RenderTransform is ScaleTransform scaleTransform)
                    {
                        scaleTransform.ScaleX = depthScale;
                        scaleTransform.ScaleY = depthScale;
                    }
                    
                    circle.Opacity = depthOpacity;
                }
                
                // After some time, transition to final logo
                if (frameCount > 180) // About 6 seconds at 30 FPS
                {
                    rotationTimer.Stop();
                    TransitionToLogo();
                }
            };
            
            rotationTimer.Start();
        }

        private void TransitionToLogo()
        {
            double scaleX = AnimationCanvas.Width / 36.0;
            double scaleY = AnimationCanvas.Height / 36.0;
            
            for (int i = 0; i < sphereCircles.Count; i++)
            {
                var sphereCircle = sphereCircles[i];
                if (sphereCircle.UIElement == null) continue;
                
                var circle = sphereCircle.UIElement;
                
                // Target position is the original logo position
                double logoX = sphereCircle.OriginalX * scaleX - (sphereCircle.Size * scaleX / 2);
                double logoY = sphereCircle.OriginalY * scaleY - (sphereCircle.Size * scaleY / 2);
                
                Storyboard logoStoryboard = new Storyboard();
                logoStoryboard.BeginTime = TimeSpan.FromSeconds(i * 0.01);
                
                // Move to logo position
                DoubleAnimation moveX = new DoubleAnimation
                {
                    To = logoX,
                    Duration = TimeSpan.FromSeconds(1.2),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };
                Storyboard.SetTarget(moveX, circle);
                Storyboard.SetTargetProperty(moveX, new PropertyPath(Canvas.LeftProperty));
                logoStoryboard.Children.Add(moveX);
                
                DoubleAnimation moveY = new DoubleAnimation
                {
                    To = logoY,
                    Duration = TimeSpan.FromSeconds(1.2),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };
                Storyboard.SetTarget(moveY, circle);
                Storyboard.SetTargetProperty(moveY, new PropertyPath(Canvas.TopProperty));
                logoStoryboard.Children.Add(moveY);
                
                // Reset scale
                DoubleAnimation scaleBackX = new DoubleAnimation
                {
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(1.2),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };
                Storyboard.SetTarget(scaleBackX, circle);
                Storyboard.SetTargetProperty(scaleBackX, new PropertyPath("RenderTransform.ScaleX"));
                logoStoryboard.Children.Add(scaleBackX);
                
                DoubleAnimation scaleBackY = new DoubleAnimation
                {
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(1.2),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };
                Storyboard.SetTarget(scaleBackY, circle);
                Storyboard.SetTargetProperty(scaleBackY, new PropertyPath("RenderTransform.ScaleY"));
                logoStoryboard.Children.Add(scaleBackY);
                
                // Reset opacity
                DoubleAnimation opacityAnim = new DoubleAnimation
                {
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(1.2),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };
                Storyboard.SetTarget(opacityAnim, circle);
                Storyboard.SetTargetProperty(opacityAnim, new PropertyPath(OpacityProperty));
                logoStoryboard.Children.Add(opacityAnim);
                
                logoStoryboard.Completed += (s, e) =>
                {
                    if (i == sphereCircles.Count - 1)
                    {
                        ShowCompleteLogo();
                    }
                };
                
                logoStoryboard.Begin();
            }
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
    
    /// <summary>
    /// Represents a circle in 3D spherical coordinates
    /// </summary>
    public class SphereCircle
    {
        public double OriginalX { get; set; }
        public double OriginalY { get; set; }
        public double Theta { get; set; }  // Inclination angle (0 to PI)
        public double Phi { get; set; }    // Azimuth angle (0 to 2PI)
        public double X { get; set; }      // Cartesian X
        public double Y { get; set; }      // Cartesian Y
        public double Z { get; set; }      // Cartesian Z
        public string Color { get; set; } = string.Empty;
        public double Size { get; set; }
        public Ellipse? UIElement { get; set; }
    }

    public class LogoCircle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Color { get; set; } = string.Empty;
        public double Size { get; set; }
    }
}