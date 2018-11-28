namespace Paint
{
    using System.Collections.Generic;

    public class FileNameSystem
    {
        public string LastFile = string.Empty, CurrentFile = string.Empty;

        private List<string> _files = new List<string>();

        public string NewFile(string newFile = "Безымянный.png")
        {
            LastFile = CurrentFile;
            int number = 1;
            while (_files.Contains(newFile))
            {
                newFile = string.Format("Безымянный ({0}).png", number);
                ++number;
            }

            _files.Add(newFile);
            CurrentFile = newFile;
            return (newFile);
        }

        public void CloseFile(string fileName)
        {
            LastFile = fileName;
            _files.Remove(fileName);
            if (_files.Count > 0)
            {
                CurrentFile = _files[_files.Count - 1];
            }
            else
            {
                CurrentFile = string.Empty;
            }
        }

        public void ChangeFile(string fileName)
        {
            LastFile = CurrentFile;
            CurrentFile = fileName;
        }

        public int GetIndexFile(string fileName)
        {
            if (_files.Contains(fileName))
            {
                return _files.IndexOf(fileName);
            }
            else
            {
                return -1;
            }
        }
    }
}