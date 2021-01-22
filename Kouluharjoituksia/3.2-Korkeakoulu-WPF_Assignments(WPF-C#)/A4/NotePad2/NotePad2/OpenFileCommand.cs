using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NotePad2
{
    class OpenFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NotePad2.MainWindow currentWindow = (NotePad2.MainWindow)Application.Current.MainWindow;

            var checkedFile = ExistingFileDialog.checkForExistingFile();

            if (checkedFile.Item2 == MessageBoxResult.Yes)
            {

                File.WriteAllText(NotepadMain.CurrentFilePath, currentWindow.TextFileBox.Text);

            }

            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (dialog.ShowDialog() == true)
            {
                NotepadMain.changeFile(dialog.SafeFileName, dialog.FileName);
            }
            //NotePad2.MainWindow currentWindow = (NotePad2.MainWindow)Application.Current.MainWindow;
            //string fileText = currentWindow.TextFileBox.Text;

            //SaveFileDialog dialog = new SaveFileDialog()
            //{
            //    Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            //};

            //if (dialog.ShowDialog() == true)
            //{
            //    File.WriteAllText(dialog.FileName, fileText);
            //    NotepadMain.changeFile(dialog.SafeFileName, dialog.FileName);

            //}
        }
    }
}
