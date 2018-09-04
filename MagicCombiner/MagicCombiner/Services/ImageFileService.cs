using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicCombiner.Model;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;

namespace MagicCombiner.Services
{
    public class ImageFileService : IImageFileService
    {
        public ImageMap LoadImageFromFile(string filePath)
        {
            Bitmap img = new Bitmap(filePath);
            ImageMap result = new ImageMap(img.Width, img.Height);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    result.Map[i, j] = ToBytes(pixel);
                }
            }

            return result;
        }

        public void SaveImageToFile(string filePath, ImageMap imageMap)
        {
            Bitmap img = new Bitmap(imageMap.ResolutionX, imageMap.ResolutionY, PixelFormat.Format24bppRgb);
            for (int y = 0; y < imageMap.ResolutionY; y++)
            {
                for (int x = 0; x < imageMap.ResolutionX; x++)
                {
                    img.SetPixel(x, y, ToColor(imageMap.Map[x, y]));
                }
            }
            img.Save(filePath);
        }

        public void SaveContrastToTextFile(string filePath, ImageMap imageMap)
        {
            if (imageMap.ContrastMapQuantified == null)
                throw new Exception("Contrast map is not ready");

            using (StreamWriter sw = new StreamWriter(filePath))
                for (int y = 0; y < imageMap.ResolutionY; y++)
                {
                    for (int x = 0; x < imageMap.ResolutionX; x++)
                        sw.Write(imageMap.ContrastMapQuantified[x,y]);
                    if (y < imageMap.ResolutionY - 1)
                        sw.WriteLine();
                }
        }

        private int ToInt(Color pixel)
        {
            return pixel.ToArgb();
        }

        private byte[] ToBytes(Color pixel)
        {
            return new byte[] { pixel.A, pixel.R, pixel.G, pixel.B };
        }

        private Color ToColor(int value)
        {
            return Color.FromArgb(value);
        }

        private Color ToColor(byte[] bytes)
        {
            return Color.FromArgb(bytes[0], bytes[1], bytes[2], bytes[3]);
        }

        private float ToFloat(Color pixel) {
            CommonDenominatorBetweenColoursAndDoubles s;
            s.AsFloat = 0;
            s.R = pixel.R;
            s.G = pixel.G;
            s.B = pixel.B;

            return s.AsFloat;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct CommonDenominatorBetweenColoursAndDoubles
    {

        [FieldOffset(0)]
        public byte R;
        [FieldOffset(1)]
        public byte G;
        [FieldOffset(2)]
        public byte B;

        [FieldOffset(0)]
        public float AsFloat;

        [FieldOffset(0)]
        public int AsInt;
    }
}
