using System;
using System.Collections.Generic;
using System.IO;

namespace SpoiledFramesEliminator
{
    class Program
    {
        static void Main(string[] args)
        {
	        //take parameter(s)
	        //var pathParameter = args[0];
	        var pathParameter = @".\..\TestFolder";
	        List<string> RawFilesToDelete = new List<string>();

			//make an instance of the folder's state
			AllTheFiles currentDir = new AllTheFiles(pathParameter);
	        
	        currentDir.Get2ListsByFileTypes();
	        
	        currentDir.TrimTheLists();
	        
	        currentDir.PrintOutTestData();
	        
	        RawFilesToDelete = currentDir.GetRawFilesToDelete();

	        Eliminate.Remove(RawFilesToDelete);

	        //call smthng to remove RAW files

			//write a message

	        Console.ReadLine();
        }
	    
	}


}
