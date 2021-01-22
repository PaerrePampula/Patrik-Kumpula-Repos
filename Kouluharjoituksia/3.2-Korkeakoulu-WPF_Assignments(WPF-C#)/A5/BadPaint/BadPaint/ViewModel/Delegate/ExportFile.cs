using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BadPaint.ViewModel.Delegate
{
    class ExportFile : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //generate dialog for saving the file.
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "JPG files(*.jpg)|*.jpg|All(*.*)|*"
            };
            //If dialog was not canceled, save file.
            if (dialog.ShowDialog() == true)
            {
                importFile(dialog.FileName);


            }

        }
        void importFile(string path)
        {
            BadPaint.MainWindow currentWindow = (BadPaint.MainWindow)Application.Current.MainWindow;


            RenderTargetBitmap rtb = new RenderTargetBitmap((int)currentWindow.PaintingCanvas.RenderSize.Width,
            (int)currentWindow.PaintingCanvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(currentWindow.PaintingCanvas);


            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            using (var fs = System.IO.File.OpenWrite(path))
            {
                pngEncoder.Save(fs);
            }
        }
    }
}
