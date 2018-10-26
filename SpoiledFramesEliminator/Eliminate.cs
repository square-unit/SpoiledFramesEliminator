using System.Collections.Generic;
using System.IO;

namespace SpoiledFramesEliminator
{
    //removes them
    public static class Eliminate
    {
        public static void Remove(List<string> FilesToRemove)
        {
            foreach (var f in FilesToRemove) File.Delete(f);
        }
    }
}