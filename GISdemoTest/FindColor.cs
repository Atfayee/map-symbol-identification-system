using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace GISdemoTest
{
    
        public struct HSV
        {
        public int H, S, V;
         }
        class FindColor
        {
            private static Mat Med_img, Hsv_img;
            public static void findColor(Mat ori_img, List<List<Point>> _conat, out List<HSV> color)
            {
                color = new List<HSV>(_conat.Count);

                if (_conat.Count < 2) return;
                // 图像颜色空间转化为HSV
                toHsv(ori_img);

                for (int i = 0; i < _conat.Count; i++)
                {
                    var pts = _conat[i].ToArray();
                    color.Add(getColor(pts));
                }
            }

            private static void toHsv(Mat ori_img)
            {
                Med_img = new Mat();
                Cv2.MedianBlur(ori_img, Med_img, 3);
                Hsv_img = new Mat();
                Cv2.CvtColor(Med_img, Hsv_img, ColorConversionCodes.BGR2HSV);
            }

            private static HSV getColor(Point[] conat)
            {
                HSV hsv;
                var m = Cv2.Moments(conat);
                int cx = (int)Math.Round(m.M10 / m.M00);
                int cy = (int)Math.Round(m.M01 / m.M00);

                var vec3b = Hsv_img.At<Vec3b>(cx, cy);
                hsv.H = vec3b.Item0;
                hsv.S = vec3b.Item1;
                hsv.V = vec3b.Item2;
                return hsv;
            }
        }
 }

