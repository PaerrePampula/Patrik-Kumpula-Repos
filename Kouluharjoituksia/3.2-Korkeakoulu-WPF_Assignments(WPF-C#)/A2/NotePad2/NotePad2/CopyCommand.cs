using System;
using System.Windows;
using System.Windows.Input;

namespace NotePad2
{
    internal class CopyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NotePad2.MainWindow currentWindow = (NotePad2.MainWindow)Application.Current.MainWindow;
            if(currentWindow.TextFileBox.SelectedText.Length > 0)
            {
                Clipboard.SetText(currentWindow.TextFileBox.SelectedText);
            }

        }
    }
}