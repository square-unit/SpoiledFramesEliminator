using System.Collections.Generic;
using System.IO;

namespace SpoiledFramesEliminator
{
    //removes them
    public static class Eliminate
    {
        public static void Remove(List<string> filesToRemove)
        {
            foreach (var f in filesToRemove) File.Delete(f);
        }
    }
}