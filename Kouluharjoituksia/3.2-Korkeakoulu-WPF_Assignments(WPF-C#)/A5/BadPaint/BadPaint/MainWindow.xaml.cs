using BadPaint.ViewModel;
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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BadPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BadPaintModel BpModel = new BadPaintModel();
            DataContext = BpModel;
        }


        private void cp_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (cp.SelectedColor.HasValue)
            {

                DrawingAttributes inkAttributes = PaintingCanvas.DefaultDrawingAttributes;

                inkAttributes.Color = cp.SelectedColor.Value;

                PaintingCanvas.DefaultDrawingAttributes = inkAttributes;

            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("(\\d)+");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textProperty = e.Source as TextBox;
            if (textProperty.Text.Length > 0 && textProperty.Text != "0")
            {
                DrawingAttributes inkAttributes = PaintingCanvas.DefaultDrawingAttributes;

                inkAttributes.Height = float.Parse(textProperty.Text);
                inkAttributes.Width = float.Parse(textProperty.Text);

                PaintingCanvas.DefaultDrawingAttributes = inkAttributes;
            }

        }
    }
}
