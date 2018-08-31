using MagicCombiner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCombiner.Services
{
    public interface IImageFileService
    {
        ImageMap LoadImageFromFile(string filePath);

        void SaveImageToFile(string filePath, ImageMap imageMap);
    }
}
