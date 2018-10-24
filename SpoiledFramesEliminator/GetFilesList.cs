using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpoiledFramesEliminator
{   
    public class AllTheFiles
    {
	    private readonly string _currentPath;
	    
	    public AllTheFiles(string pathParameter)
	    {
		    _currentPath = pathParameter;
	    }

	    readonly string[] _rawFileExtensions = {".DNG", ".CR3", ".CR2", ".RAF", ".NEF"};
	    readonly string[] _lossyFileExtensions = {".JPG", ".JPEG"};
	    private List<string> rawFilesList = new List<string>();
	    private List<string> lossyFilesList = new List<string>();
	    private List<string> rawFilesMissingItsLossyCopies = new List<string>();

	    public void Get2ListsByFileTypes()
	    {
		    var fileEntries = Directory.GetFiles(_currentPath);

		    foreach (var File in fileEntries)
		    {	
			    foreach (var rawFileExt in _rawFileExtensions)
				    if (File.Contains(rawFileExt))
				    {
					    string rawFileName = File;
					    
						rawFilesList.Add(File);
				    }
			    foreach (var jpegExt in _lossyFileExtensions)
				    if (File.Contains(jpegExt))
				    {
					    lossyFilesList.Add(File);
				    }
		    }
	    }

	    public void PrintOutTestData()
	    {	
		    Console.WriteLine("RAWs");
		    foreach (string i in rawFilesList)
		    {
			    Console.WriteLine(i);
		    }
		    Console.WriteLine("JPEGs");
		    foreach (string i in lossyFilesList)
		    {
			    Console.WriteLine(i);
		    } 
	    }

	    public void GetRawFilesToDelete()
	    {
		    foreach (string lossyFile in lossyFilesList)
		    {
			    
		    }
	    }
	    

	}
}