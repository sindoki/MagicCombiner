using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicCombiner.Model;

namespace MagicCombiner.Services
{
    public class ContrastMapCalculator : IContrastMapCalculator
    {
        public void CalculateContrastMap(ImageMap image, float sharpness)
        {
            image.ResetContrastMap();

            int windowX = (int)(image.ResolutionX * sharpness);
            int windowY = (int)(image.ResolutionY * sharpness);


        }
    }
}
