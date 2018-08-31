using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHolder services = new ServiceHolder();

            string imageFilePath = "D:\\Private\\Phone\\DSC_1108.JPG";
            string outputFilePath = "D:\\Private\\Phone\\DSC_1108_01.JPG";
            var imageMap = services.ImageFileService.LoadImageFromFile(imageFilePath);
            services.ImageFilterService.TestFilter(imageMap);
            services.ImageFileService.SaveImageToFile(outputFilePath, imageMap);
        }
    }
}
