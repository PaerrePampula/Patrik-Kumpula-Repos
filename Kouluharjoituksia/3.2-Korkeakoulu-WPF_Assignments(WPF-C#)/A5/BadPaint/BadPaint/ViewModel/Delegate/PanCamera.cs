using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace BadPaint.ViewModel.Delegate
{
    class PanCamera : ICommand
    {
        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ///An asynchronous operation due to the needed while loop below
            Thread t = new Thread(() => dragWorkerDoWork());
            t.Start();

        }

        async private void dragWorkerDoWork()
        {

            ///Does a begininvoke due to changes being done to the UI in an asynchronous thread
            await Application.Current.Dispatcher.BeginInvoke(dragAction);

        }
        async void dragAction()
        {

            //Gets the currentwindow instance, from which the workarea is needed to drag it around
            BadPaint.MainWindow currentWindow = (BadPaint.MainWindow)Application.Current.MainWindow;
            //The needed UI-element is found, to be used in the dragging, which is always the immediate child of the background


            var scrollArea = currentWindow.scrollViewer;
            var workArea = currentWindow.PaintCanvasBorder;
            //An offset is determined between the current mouse, and the transform of the
            //"Work area" element
            Point offset = Mouse.GetPosition(scrollArea);
            while (Mouse.RightButton == MouseButtonState.Pressed)
            {
                //The current mousePosition is to be found every while loop, then the 
                //Location is used in determining a new position for the transformed "Work area" element
                Point mousePos = Mouse.GetPosition(currentWindow);

                var newTransform = new TranslateTransform
                {
                    //The new location is determined with subtracting the original mouse position of the 
                    //Held down mouse button command, to prevent the "work area" from jumping around the screen
                    X = (mousePos.X + workArea.RenderTransformOrigin.X - offset.X),
                    Y = (mousePos.Y + workArea.RenderTransformOrigin.Y - offset.Y)

                };
                //The actual transforming of the "work area" element is done, and the user sees it as scrolling or the dragging
                //The viewport of the "workspace"
                workArea.RenderTransform = newTransform;
                //Also this task is limited to a set time, since it really doesnt need to be called every moment possible.
                await Task.Delay(20);

            }
        }
    }
}
