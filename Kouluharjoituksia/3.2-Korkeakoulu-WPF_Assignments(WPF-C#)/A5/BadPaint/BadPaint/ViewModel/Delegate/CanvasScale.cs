using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BadPaint.ViewModel.Delegate
{
    class CanvasScale : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            BadPaint.MainWindow currentWindow = (BadPaint.MainWindow)Application.Current.MainWindow;
            var canvasAreaBorder = currentWindow.PaintCanvasBorder;
            var dialog = new DialogCanvasScale(canvasAreaBorder.Height, canvasAreaBorder.Width);

            if (dialog.ShowDialog() == true)
            {
                var x = dialog.XScaleField;
                var y = dialog.YScaleField;

                canvasAreaBorder.Width = x;
                canvasAreaBorder.Height = y;
            }
        }
    }
}
