using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace NotePad2
{
    internal class ExitCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Do a check first, if there is a file that has changes in use.
            var checkForFile = ExistingFileDialog.checkForExistingFile();
            //Get the current instance window
            MainWindow currentWindow = (MainWindow)Application.Current.MainWindow;
            //Checks if a change is detected to a current file.
            if (checkForFile.Item1 == true)
            {
                //In the case of cancel, do nothing, if user chooses yes, save and quit, if no is chosen, quit
                switch (checkForFile.Item2)
                {

                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.Yes:
                        File.WriteAllText(NotepadMain.CurrentFilePath, currentWindow.TextFileBox.Text);
                        Application.Current.Shutdown();
                        break;
                    case MessageBoxResult.No:
                        Application.Current.Shutdown();
                        break;

                }

            }

        }
    }
}