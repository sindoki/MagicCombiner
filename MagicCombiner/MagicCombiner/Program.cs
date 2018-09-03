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

            string imageFilePath = "C:\\Квартира\\План_3_с_мебелью.jpg";//"D:\\Private\\Phone\\DSC_1108.JPG";
            string outputFilePath = "D:\\Private\\Phone\\DSC_1108_01.JPG";
            var imageMap = services.ImageFileService.LoadImageFromFile(imageFilePath);
            services.ContrastMapCalculator.CalculateContrastMap(imageMap, 0.01f, 10);
            //services.ImageFilterService.TestFilter(imageMap);
            //services.ImageFileService.SaveImageToFile(outputFilePath, imageMap);
        }
    }
}
