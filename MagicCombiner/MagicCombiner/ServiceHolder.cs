using MagicCombiner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCombiner
{
    public class ServiceHolder
    {
        public IImageFileService ImageFileService { get; private set; }

        public IImageFilterService ImageFilterService { get; private set; }

        public IContrastMapCalculator ContrastMapCalculator { get; private set; }

        public ServiceHolder() {
            ImageFileService = new ImageFileService();
            ImageFilterService = new ImageFilterService();
            ContrastMapCalculator = new ContrastMapCalculator();
        }
    }
}
