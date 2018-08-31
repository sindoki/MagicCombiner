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

        public ServiceHolder() {
            ImageFileService = new ImageFileService();
        }
    }
}
