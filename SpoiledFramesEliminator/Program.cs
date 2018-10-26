using System;
using System.Collections.Generic;

namespace SpoiledFramesEliminator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var pathParameter = @".\..\TestFolder";
            var pathParameter = Environment.CurrentDirectory;
            

            //make an instance of the folder's state
            var currentDir = new AllTheFiles(pathParameter);

            currentDir.Get2ListsByFileTypes();

            currentDir.TrimTheLists();

            currentDir.PrintOutTestData();

            var rawFilesToDelete = currentDir.GetRawFilesToDelete();

            Eliminate.Remove(rawFilesToDelete);

            Console.ReadLine();
        }
    }
}