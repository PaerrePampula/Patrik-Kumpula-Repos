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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window currentWindow;
        List<Button> foundButtonsForNumbers;
        List<Button> foundButtonsForOperations;
        TextBlock outPutField;
        Calculation currentCalculation;



        public MainWindow()
        {
            InitializeComponent();
            currentWindow = App.Current.MainWindow;
            foundButtonsForNumbers = findButtons("NumbersGrid");
            foundButtonsForOperations = findButtons("OperationsGrid");
            addEventsToNumberButtons(foundButtonsForNumbers);
            addEventsToOperationButtons(foundButtonsForOperations);
            outPutField =(TextBlock)currentWindow.FindName("OutputText");
            currentCalculation = new Calculation();
            Calculation.OnNewCalculation += updateOutputField;
            //Tai as TextBlock
        }

        private void updateOutputField(string displayValue)
        {
            outPutField.Text = displayValue;
        }

        List<Button> findButtons(string gridName)
        {

            var cellsParent = (Grid)currentWindow.FindName(gridName);
            var foundNumberCells = cellsParent.Children.OfType<Button>().ToList();
            return foundNumberCells;
            //Tai for loop verraten jokaisen iteraation tyyppiä
        }

        void addEventsToOperationButtons(List<Button> buttons)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Click += handleNumberInputClick;
            }
        }
        void addEventsToNumberButtons(List<Button> buttons)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Click += handleNumberInputClick;
            }
        }



        void handleNumberInputClick(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            var input = button.Content.ToString();
            var isNumeric = int.TryParse(input, out int resultInt);


            currentCalculation.addToCalculation(input);
            //Välttää inputin yhdistämistä vaan niin esim 1+1=2 vaan 1+1=11...



        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (currentCalculation != null)
            {
                currentCalculation.CurrentCalculation = "";

            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {

            currentCalculation.evaluateCalculation();
        }
    }

}
