using System;
using System.Windows;
using System.Windows.Input;

namespace NotePad2
{
    internal class PasteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NotePad2.MainWindow currentWindow = (NotePad2.MainWindow)Application.Current.MainWindow;
            if (Clipboard.GetText().Length > 0)
            {
                currentWindow.TextFileBox.SelectedText = Clipboard.GetText();
            }

        }
    }
}