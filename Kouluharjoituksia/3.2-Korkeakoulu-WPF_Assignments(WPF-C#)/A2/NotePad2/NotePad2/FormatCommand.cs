using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Media;
using System.Drawing;

namespace NotePad2
{
    internal class FormatCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            //Get the mainwindow to find the textbox containing the notepad text
            MainWindow currentWindow = (MainWindow)System.Windows.Application.Current.MainWindow;

            var fontDialog = new FontDialog();
            // FontFamily mfont = new FontFamily(currentWindow.TextFileBox.Name);
            fontDialog.Font = new Font(currentWindow.TextFileBox.FontFamily.ToString(), (float)currentWindow.TextFileBox.FontSize);
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedFont = fontDialog.Font;
                currentWindow.TextFileBox.FontSize = selectedFont.Size;
                currentWindow.TextFileBox.FontFamily = new System.Windows.Media.FontFamily(selectedFont.FontFamily.Name);
                currentWindow.TextFileBox.FontWeight = selectedFont.Bold ? FontWeights.Bold : FontWeights.Normal;
                currentWindow.TextFileBox.FontStyle = selectedFont.Italic ? FontStyles.Italic : FontStyles.Normal;
            }
        }
    }
}