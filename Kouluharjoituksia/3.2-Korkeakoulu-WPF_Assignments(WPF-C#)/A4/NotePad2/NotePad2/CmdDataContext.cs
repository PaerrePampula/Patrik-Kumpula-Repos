using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NotePad2
{
    public class CmdDataContext
    {
        ICommand _newFileCommand = new NewFileCommand();

        public ICommand NewFileCommand
        {
            get { return _newFileCommand; }
        }
        ICommand _saveFileCommand = new SaveFileCommand();

        public ICommand SaveFileCommand
        {
            get { return _saveFileCommand;  }
        }

        ICommand _openFileCommand = new OpenFileCommand();

        public ICommand OpenFileCommand
        {
            get { return _openFileCommand;  }
        }

        ICommand _exitCommand = new ExitCommand();

        public ICommand ExitCommand
        {
            get { return _exitCommand; }
        }

        ICommand _printCommand = new PrintCommand();

        public ICommand PrintCommand
        {
            get { return _printCommand;  }
        }

        ICommand _formatCommand = new FormatCommand();

        public ICommand FormatCommand
        {
            get { return _formatCommand; }
        }

        ICommand _copyCommand = new CopyCommand();

        public ICommand CopyCommand
        {
            get { return _copyCommand; }
        }

        ICommand _pasteCommand = new PasteCommand();

        public ICommand PasteCommand
        {
            get { return _pasteCommand; }
        }
    }
}
