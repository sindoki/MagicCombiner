using MagicCombiner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCombiner.Services
{
    public interface IContrastMapCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sharpness">Доля изображения, рассматриваемая в качестве окрестности пикселя</param>
        void CalculateContrastMap(ImageMap image, float sharpness);
    }
}
