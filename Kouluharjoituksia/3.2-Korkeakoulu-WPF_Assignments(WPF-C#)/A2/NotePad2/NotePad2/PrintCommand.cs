using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace NotePad2
{
    internal class PrintCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Create a new dialog instance for printing
            PrintDialog prtDialog = new PrintDialog();
            //Set some defaults related to pagination
            prtDialog.PageRangeSelection = PageRangeSelection.AllPages;
            prtDialog.UserPageRangeEnabled = true;

            //Save the resulting bool from the dialog choices to a field variable
            var result = prtDialog.ShowDialog();


            if (result == true)
            {
                //Get the mainwindow to find the textbox containing the notepad text
                MainWindow currentWindow = (MainWindow)Application.Current.MainWindow;

                //Create a new FlowDocument, for the ease of printing strings made in notepad style
                FlowDocument flowDocument = new FlowDocument();
                flowDocument.Blocks.Add(new Paragraph(new Run(currentWindow.TextFileBox.Text)));
                flowDocument.ColumnWidth = prtDialog.PrintableAreaWidth;


                //Then simply print the result
                prtDialog.PrintDocument(((IDocumentPaginatorSource)flowDocument).DocumentPaginator, "Notepad print job");

            }
        }
    }
}