using BadPaint.ViewModel.Delegate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BadPaint.ViewModel
{
    class BadPaintModel
    {
        public ICommand CanvasScale { get; set; } = new CanvasScale();
        public ICommand PanCamera { get; set; } = new PanCamera();
        public ICommand ChangeBrushType { get; set; } = new ChangeBrushType();
        public ICommand SaveFile { get; set; } = new SaveFile();
        public ICommand OpenFile { get; set; } = new OpenFile();
        public ICommand ExportFile { get; set; } = new ExportFile();
        public ICommand NewFile { get; set; } = new NewFile();
    }
}
