using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BadPaint
{
    /// <summary>
    /// Interaction logic for DialogCanvasScale.xaml
    /// </summary>
    public partial class DialogCanvasScale : Window
    {
        public DialogCanvasScale(double targetYScale, double targetXscale)
        {
            InitializeComponent();

            Yscale.Text = targetYScale.ToString();
            Xscale.Text = targetXscale.ToString();

        }


        public float XScaleField { get => float.Parse(Xscale.Text); }
        public float YScaleField { get => float.Parse(Yscale.Text); }

        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("(\\d)+");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
