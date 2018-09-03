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

        public byte[,][] Map { get; private set; }

        public float[,] ContrastMap { get; private set; }

        public int[,] ContrastMapQuantified { get; private set; }

        public ImageMap(int resolutuonX, int resolutionY) {
            ResolutionX = resolutuonX;
            ResolutionY = resolutionY;
            Map = new byte[ResolutionX, ResolutionY][]; //RGBA
        }

        public void ResetContrastMap() {
            ContrastMap = new float[ResolutionX, ResolutionY];
            ContrastMapQuantified = new int[ResolutionX, ResolutionY];
        }
    }
}
