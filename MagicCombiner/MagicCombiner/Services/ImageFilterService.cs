using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicCombiner.Model;

namespace MagicCombiner.Services
{
    public class ImageFilterService : IImageFilterService
    {
        public void TestFilter(ImageMap image)
        {
            int add = 100;

            for (int x = 0; x < image.ResolutionX; x++) {
                for (int y = 0; y < image.ResolutionY; y++) {
                    image.Map[x, y] += add;
                }
            }
        }
    }
}
