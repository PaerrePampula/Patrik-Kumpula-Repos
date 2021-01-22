using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NotePad2
{
    class SaveFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            //get the current application instance
            NotePad2.MainWindow currentWindow = (NotePad2.MainWindow)Application.Current.MainWindow;
            //get the element containing user text
            string fileText = currentWindow.TextFileBox.Text;
            //generate dialog for saving the file.
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            //If dialog was not canceled, save file.
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, fileText);
                //Make sure that you are currently handling the saved file in the notepad.
                NotepadMain.changeFile(dialog.SafeFileName, dialog.FileName);

            }
        }

    }
}
