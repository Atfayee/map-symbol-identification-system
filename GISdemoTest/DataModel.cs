using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using DotSpatial.Data;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;

namespace GISdemoTest
{
    class DataModel
    {
        public static Mat Layer2Mat(IMapLayer layer)
        {
            Mat result = new Mat();
            IMapImageLayer stateLayer = (IMapImageLayer)layer;
            IImageData dataset = stateLayer.DataSet;
            Byte[] vs = dataset.Values;
            if (dataset.NumBands == 3)
            {
                result = new Mat(dataset.Height, dataset.Width, MatType.CV_8UC3, vs);
            }
            else if (dataset.NumBands == 4)
            {
                result = new Mat(dataset.Height, dataset.Width, MatType.CV_8UC4, vs);
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static string Mat2layer(Mat ori,string ImageName)
        {

            Mat val_color = new Mat();
            ImageData dataset = new ImageData();
            Cv2.CvtColor(ori, val_color, ColorConversionCodes.GRAY2BGRA);
            Bitmap bt = BitmapConverter.ToBitmap(val_color);
            bt.Save($"{ImageName}");
            return ImageName;
        }
    }
}

