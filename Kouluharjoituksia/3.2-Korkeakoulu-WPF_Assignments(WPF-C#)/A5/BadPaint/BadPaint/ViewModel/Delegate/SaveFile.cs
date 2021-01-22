using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BadPaint.ViewModel.Delegate
{
    class SaveFile : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {

            //generate dialog for saving the file.
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Project files(*.pr)|*.pr|All(*.*)|*"
            };
            //If dialog was not canceled, save file.
            if (dialog.ShowDialog() == true)
            {
                saveProjectFile(dialog.FileName);


            }



        }
        public static void saveProjectFile(string fileName = "project file")
        {
            BadPaint.MainWindow currentWindow = (BadPaint.MainWindow)Application.Current.MainWindow;



            using (FileStream inkFileStream = new FileStream(fileName, FileMode.Create))
            {

                // Transfer your data and close the file.
                currentWindow.PaintingCanvas.Strokes.Save(inkFileStream);
            }





        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
