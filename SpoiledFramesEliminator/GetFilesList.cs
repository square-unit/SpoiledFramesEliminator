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
	    private string ActualRawExtension;
	    private string ActualLossyExtension;
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
						rawFilesList.Add(File);
					    ActualRawExtension = rawFileExt;
				    }
			    foreach (var jpegExt in _lossyFileExtensions)
				    if (File.Contains(jpegExt))
				    {	
					    lossyFilesList.Add(File);
					    ActualLossyExtension = jpegExt;
				    }
		    }
	    }

	    public void TrimTheLists()
	    {
		    for (var index = 0; index < rawFilesList.Count; index++)
		    {
			    rawFilesList[index] = rawFilesList[index].Replace(ActualRawExtension, "");
		    }

		    for (var index = 0; index < lossyFilesList.Count; index++)
		    {
			    lossyFilesList[index] = lossyFilesList[index].Replace(ActualLossyExtension, "");
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

	    public List<string> GetRawFilesToDelete()
	    {
		    foreach (string rawFile in rawFilesList)
		    {
			    if (lossyFilesList.Contains(rawFile) == false)
			    {
				    rawFilesMissingItsLossyCopies.Add(rawFile);
			    }
		    }

		    for (var index = 0; index < rawFilesMissingItsLossyCopies.Count; index++)
		    {
			    rawFilesMissingItsLossyCopies[index] = rawFilesMissingItsLossyCopies[index]
				    .Insert(rawFilesMissingItsLossyCopies[index].Length, ActualRawExtension);
		    }
		    
		    Console.WriteLine("RAW files to be removed");
		    foreach (string i in rawFilesMissingItsLossyCopies)
		    {
			    Console.WriteLine(i);
		    }

		    return rawFilesMissingItsLossyCopies;
	    }
	    
	    

	}
}