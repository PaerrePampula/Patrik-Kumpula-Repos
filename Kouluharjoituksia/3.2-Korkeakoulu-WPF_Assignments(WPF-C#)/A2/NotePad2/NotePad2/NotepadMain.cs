using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace NotePad2
{
    /// <summary>
    /// A utility class controlling some important objects for use for the notepad program.
    /// Includes the current file name, plus the path of the current file.
    /// Also includes methods for changing files.
    /// </summary>
    class NotepadMain
    {
        static string currentFileName;

        static string currentFilePath;

        public static string CurrentFileName
        {
            get => currentFileName; set
            {
                currentFileName = value;
                NotePad2.MainWindow currentWindow = (NotePad2.MainWindow)Application.Current.MainWindow;
                currentWindow.Title = currentFileName;

            }
        }

        public static string CurrentFilePath { get => currentFilePath; set => currentFilePath = value; }

        public static void changeFile(string name, string filePath = null)
        {
            CurrentFileName = name;

            CurrentFilePath = filePath;
            NotePad2.MainWindow currentWindow = (NotePad2.MainWindow)Application.Current.MainWindow;
            if (filePath != null)
            {

                if (File.Exists(filePath))
                {
                    currentWindow.TextFileBox.Text = "";
                    currentWindow.TextFileBox.Text = File.ReadAllText(filePath);
                }

            }
            else
            {
                currentWindow.TextFileBox.Text = "";
            }

        }


    }
}
