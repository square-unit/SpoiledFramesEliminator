using System.Collections.Generic;
using System.IO;

namespace SpoiledFramesEliminator
{   
    //takes a list of jpg and raw files, generates a list of raw files to remove, removes them
    public class Eliminate
    {
        public static void Remove(List<string> FilesToRemove)
        {
            foreach (string f in FilesToRemove)
            {
                File.Delete(f);
            }
        }
        
        
    }
}