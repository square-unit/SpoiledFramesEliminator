using System;
using System.IO;
using System.Linq;

namespace SpoiledFramesEliminator
{   
    //get list of the files in directory
    public class Search
    {
        public Search(string pathParameter)
        {
	        var path = pathParameter;
	        string[] fileEntries = Directory.GetFiles(path);
	        string[] rawFileExtensions = {".DNG", ".CR3", ".CR2", ".RAF", ".NEF"};
	        string[] lossyFileExtensions = {".JPG", ".JPEG"};
	        
			
	        foreach (string File in fileEntries)
             	        {	
             		        foreach (string x in rawFileExtensions)
             		        {
             			        if (File.Contains(x))
             			        {
             				        string raw = x;
             				        Console.WriteLine(raw);
             				        Console.WriteLine(File);
				                    
             			        }
             		        }   
             	        }
	        
	        foreach (string File in fileEntries)
	        {	
		        foreach (string j in lossyFileExtensions)
		        {
			        if (File.Contains(j))
			        {
				        string jpeg = j;
				        Console.WriteLine(jpeg);
				        Console.WriteLine(File);
			        }
		        }   
	        }
			

	        Console.ReadLine();

        }




	}
}