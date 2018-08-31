using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCombiner.Model
{
    public class ImageMap
    {
        public int ResolutionX { get; private set; }

        public int ResolutionY { get; private set; }

        public int[,] Map { get; private set; }

        public ImageMap(int resolutuonX, int resolutionY) {
            ResolutionX = resolutuonX;
            ResolutionY = resolutionY;
            Map = new int[ResolutionX, ResolutionY];
        }
    }
}
