using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.API.Concrete
{
    public class DetectedObject
    {
        public int ObjectIndex { get; set; }
        public Image? DetectedImage  { get; set; }
        public string? DetectedImageBase64 { get; set; }
        public DetectedObject()
        {
            ObjectIndex= -1;
        }

    }
}
