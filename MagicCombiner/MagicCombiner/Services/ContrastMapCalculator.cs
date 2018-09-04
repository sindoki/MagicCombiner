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
        public void CalculateContrastMap(ImageMap image, float sharpness, int quantifier)
        {
            image.ResetContrastMap();

            int windowX = (int)(image.ResolutionX * sharpness);
            int windowY = (int)(image.ResolutionY * sharpness);
            if (windowX < 5)
                windowX = 5;
            if (windowY < 5)
                windowY = 5;

            if (windowX % 2 == 0)
                windowX++;

            if (windowY % 2 == 0)
                windowY++;

            int wX = (windowX - 1) / 2;
            int wY = (windowY - 1) / 2;
            int dx, dy;
            float contrast;
            float minContrast = 1;
            float maxContrast = 0;

            // Сумма цветовых расстояний (контрастов)
            for (int x = wX; x < image.ResolutionX - wX; x++)
                for (int y = wY; y < image.ResolutionY - wY; y++)
                {
                    for (int i = 1; i <= wX; i++)
                        for (int j = 1; j <= wY; j++)
                        {
                            contrast = Contrast(image.Map[x, y], image.Map[x + i, y + j]);
                            image.ContrastMap[x, y] += contrast;
                            image.ContrastMap[x + i, y + j] += contrast;
                        }
                }

            // Вычисление среднего контраста в окрестности, а также минимума и максимума
            for (int x = 0; x < image.ResolutionX; x++)
                for (int y = 0; y < image.ResolutionY; y++)
                {
                    dx = x < wX 
                       ? x : x >= image.ResolutionX - wX 
                       ? image.ResolutionX - x - 1 : wX;
                    dy = y < wY
                       ? y : y >= image.ResolutionY - wY
                       ? image.ResolutionY - y - 1 : wY;
                    image.ContrastMap[x, y] /= (wX + dx + 1) * (wY + dy + 1);

                    if (minContrast > image.ContrastMap[x, y])
                        minContrast = image.ContrastMap[x, y];
                    if (maxContrast < image.ContrastMap[x, y])
                        maxContrast = image.ContrastMap[x, y];
                }

            // Вычисление квантованной карты
            // TODO: реализовать более гибкий метод, в котором в каждом кванте будет одинаковое количество значений, чтобы квантование выполнялось в соответствии с плотностью распределения
            float quant = (maxContrast - minContrast) / quantifier;
            for (int x = 0; x < image.ResolutionX; x++)
                for (int y = 0; y < image.ResolutionY; y++) {
                    image.ContrastMapQuantified[x, y] = (int)(image.ContrastMap[x, y] / quant);
                    if (image.ContrastMapQuantified[x, y] == quantifier)
                        image.ContrastMapQuantified[x, y] = quantifier - 1;
                }
        }

        private float Contrast(byte[] p1, byte[] p2) {
            return (float)Math.Sqrt(
                Sqr(p1[0] - p2[0]) / 256 + 
                Sqr(p1[1] - p2[1]) / 256 + 
                Sqr(p1[2] - p2[2]) / 256 + 
                Sqr(p1[3] - p2[3]) / 256
            );
        }

        private int Sqr(int x) {
            return x * x;
        }
    }
}
