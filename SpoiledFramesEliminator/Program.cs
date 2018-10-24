using System;
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

			//make an instance of the folder's state
			AllTheFiles currentDir = new AllTheFiles(pathParameter);
	        
	        currentDir.Get2ListsByFileTypes();
	        
	        currentDir.PrintOutTestData();
	        
	        

	        //call smthng to remove RAW files

			//write a message
	        
	        

	        Console.ReadLine();
        }
	    
	}


}
