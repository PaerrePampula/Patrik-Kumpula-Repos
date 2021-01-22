using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;

namespace BadPaint.ViewModel.Delegate
{
    class OpenFile : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {



            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Project Files(*.pr)|*.pr|All(*.*)|*"
            };

            if (dialog.ShowDialog() == true)
            {
                openFile(dialog.FileName);
            }


        }
        public static void openFile(string path)
        {
            BadPaint.MainWindow currentWindow = (BadPaint.MainWindow)Application.Current.MainWindow;

            // If our file exists,
            if (File.Exists(path))
            {

                FileStream inkFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                StrokeCollection strokes = new StrokeCollection(inkFileStream);

                currentWindow.PaintingCanvas.Strokes = strokes;

            }
        }
    }
}
