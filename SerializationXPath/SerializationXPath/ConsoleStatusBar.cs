
namespace SerializationXPath
{
    using System;

    using Ionic.Zip;

    public class ConsoleStatusBar
    {
        private int _length;

        private int _status;

        private int _progress;

        private int _currentLine;

        public ConsoleStatusBar(int length)
        {
            _length = length;
            _currentLine = Console.CursorTop;
            Console.SetCursorPosition(110, _currentLine);
            Console.Write("0%");
        }

        public void ShowZipExtractProgress(object sender, ZipProgressEventArgs args)
        {
            if (args.EventType == ZipProgressEventType.Extracting_AfterExtractEntry)
            {
                _status++;
                if (_progress < (int)((double)_status / _length * 100))
                {
                    Console.SetCursorPosition(_progress + 8, _currentLine);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                    _progress = (int)((double)_status / _length * 100);
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.SetCursorPosition(110, _currentLine);
                Console.Write($"{(double)_status / _length * 100:F}%");
            }
        }
    }
}