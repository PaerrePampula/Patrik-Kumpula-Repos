using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BadPaint.ViewModel.Delegate
{
    class ChangeBrushType : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BadPaint.MainWindow currentWindow = (BadPaint.MainWindow)Application.Current.MainWindow;

            if (parameter.ToString() == "Normal")
            {
                currentWindow.PaintingCanvas.EditingMode = InkCanvasEditingMode.Ink;
            }
            else
            {
                currentWindow.PaintingCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
        }
    }
}
