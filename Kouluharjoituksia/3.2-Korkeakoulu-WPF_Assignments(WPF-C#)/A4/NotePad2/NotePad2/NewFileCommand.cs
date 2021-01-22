using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NotePad2
{
    class NewFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Check if current file (if found) has any changes
            var checkedFile = ExistingFileDialog.checkForExistingFile();
            switch (checkedFile.Item2)
            {
                case MessageBoxResult.Cancel:
                    //Cancel this event
                    break;
                case MessageBoxResult.Yes:
                    //Save the edited file and create a new file
                    NotePad2.MainWindow currentWindow = (NotePad2.MainWindow)Application.Current.MainWindow;
                    File.WriteAllText(NotepadMain.CurrentFilePath, currentWindow.TextFileBox.Text);
                    NotepadMain.changeFile("New text file");
                    break;
                case MessageBoxResult.No:
                    //Dont save the file and create a new file
                    NotepadMain.changeFile("New text file");
                    break;
                default:
                    NotepadMain.changeFile("New text file");
                    break;
            }

        }
    }
}
