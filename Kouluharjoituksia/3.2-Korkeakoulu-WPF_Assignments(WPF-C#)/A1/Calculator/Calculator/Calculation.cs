using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Calculation
    {
        public delegate void Calculated(string displayValue);
        public static event Calculated OnNewCalculation;
        string currentCalculation;

        public string CurrentCalculation
        {
            get { return currentCalculation; }
            set
            {

                currentCalculation = value;
                OnNewCalculation?.Invoke(currentCalculation);
            }
        }

        public void addToCalculation(string input)
        {
            CurrentCalculation += input;
        }
        public void evaluateCalculation()
        {
            try
            {
                CurrentCalculation = Evaluate(currentCalculation).ToString();

            }
            catch (System.Data.SyntaxErrorException)
            {


            }

        }
        
        static Double Evaluate(String expression)
        {
                System.Data.DataTable table = new System.Data.DataTable();

                return Convert.ToDouble(table.Compute(expression, String.Empty));
        }
    }
}
