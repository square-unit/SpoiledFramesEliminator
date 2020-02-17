using System;
using System.Collections.Generic;
using System.IO;

namespace SpoiledFramesEliminator
{
    public class AllTheFiles
    {
        private readonly string _currentPath;
        private readonly string[] _lossyFileExtensions = {".JPG", ".JPEG"};

        private readonly string[] _rawFileExtensions = {".DNG", ".CR3", ".CR2", ".RAF", ".NEF"};
        private string _actualLossyExtension;
        private string _actualRawExtension;
        private readonly List<string> _lossyFilesList = new List<string>();
        private readonly List<string> _rawFilesList = new List<string>();
        private readonly List<string> _rawFilesMissingItsLossyCopies = new List<string>();

        public AllTheFiles(string pathParameter)
        {
            _currentPath = pathParameter;
        }

        public void Get2ListsByFileTypes()
        {
            var fileEntries = Directory.GetFiles(_currentPath);

            foreach (var file in fileEntries)
            {
                foreach (var rawFileExt in _rawFileExtensions)
                    if (file.Contains(rawFileExt))
                    {
                        _rawFilesList.Add(file);
                        _actualRawExtension = rawFileExt;
                    }

                foreach (var jpegExt in _lossyFileExtensions)
                    if (file.Contains(jpegExt))
                    {
                        _lossyFilesList.Add(file);
                        _actualLossyExtension = jpegExt;
                    }
            }
        }

        public void TrimTheLists()
        {
            for (var index = 0; index < _rawFilesList.Count; index++)
                _rawFilesList[index] = _rawFilesList[index].Replace(_actualRawExtension, "");

            for (var index = 0; index < _lossyFilesList.Count; index++)
                _lossyFilesList[index] = _lossyFilesList[index].Replace(_actualLossyExtension, "");
        }

        public void PrintOutTestData()
        {
            Console.WriteLine("RAWs");
            foreach (var i in _rawFilesList) Console.WriteLine(i);
            Console.WriteLine("JPEGs");
            foreach (var i in _lossyFilesList) Console.WriteLine(i);
        }

        public List<string> GetRawFilesToDelete()
        {
            foreach (var rawFile in _rawFilesList)
                if (_lossyFilesList.Contains(rawFile) == false)
                    _rawFilesMissingItsLossyCopies.Add(rawFile);

            for (var index = 0; index < _rawFilesMissingItsLossyCopies.Count; index++)
                _rawFilesMissingItsLossyCopies[index] = _rawFilesMissingItsLossyCopies[index]
                    .Insert(_rawFilesMissingItsLossyCopies[index].Length, _actualRawExtension);

            Console.WriteLine("RAW files to be removed:");
            foreach (var i in _rawFilesMissingItsLossyCopies) Console.WriteLine(i);

            return _rawFilesMissingItsLossyCopies;
        }
    }
}