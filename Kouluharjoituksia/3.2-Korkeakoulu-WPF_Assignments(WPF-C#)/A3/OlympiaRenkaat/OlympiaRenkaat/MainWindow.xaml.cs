using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OlympiaRenkaat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RingDestroyButton_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < OlympicRingCanvas.Children.Count; i++)
            {
                var initialYLocationForElement = OlympicRingCanvas.Children[i].TransformToAncestor(OlympicRingCanvas)
                          .Transform(new Point(0, 0));
                Random random = new Random();
                var randY = random.Next(50, 100);
                var randX = random.Next(-100, 100);
                DoubleAnimation doubleAnimation = new DoubleAnimation(initialYLocationForElement.Y, initialYLocationForElement.Y+randY, TimeSpan.FromSeconds(0.44f));
                DoubleAnimation doubleAnimationX = new DoubleAnimation(initialYLocationForElement.X, initialYLocationForElement.X + randX, TimeSpan.FromSeconds(0.44f));
                OlympicRingCanvas.Children[i].BeginAnimation(Canvas.TopProperty, doubleAnimation);
                OlympicRingCanvas.Children[i].BeginAnimation(Canvas.LeftProperty, doubleAnimationX);

            }
            RingDestroyButton.IsEnabled = false;

        }
    }
}
