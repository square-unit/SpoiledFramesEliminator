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

			//call something to get the list of JPEG and RAW files
			Search searching = new Search(pathParameter);

	        //call smthng to remove RAW files

			//write a message

	        
        }
	    
	}


}
