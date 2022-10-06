using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace GISdemoTest
{
    class FindCanny
    {
        private static Mat new_img,
            gray_img,
            gray_low_img,
            edges_img,
            values_img,
            dst_img,
            Open_img,
            values2_img,
            grad,
            Open2_img,
            Gao_img,
            Hsv_img,
            Med_img;

        private static int thresholdVal = 45;
        private static int thresholdPer = 180;
        private static int thresholdBac = 35;
        private static int CloseKernel = 3;
        private static int CloseKernel2 = 2;
        private static int g_ContrastValue = 80;
        /// <summary>
        /// 几何轮廓检测
        /// </summary>
        /// <param name="ori_img">原始Mat格式图像</param>
        /// <param name="out_canny_img">输出轮廓图像</param>
        /// <param name="_conat">输出所有轮廓点集数组</param>
        /// <param name="_hierarchy">输出轮廓拓扑信息数组</param>
        public static void findCanny(Mat ori_img, out Mat out_canny_img, out List<List<Point>> _conat, out HierarchyIndex[] _hierarchy)
        {
            out_canny_img = null;
            _conat = null;
            _hierarchy = null;

            // 转灰度图
            gray_low_img = new Mat();
            gray_low_img = GetGray(ori_img);

            // 高斯滤波去噪声
            Gao_img = new Mat();
            Cv2.GaussianBlur(gray_low_img, Gao_img, new Size(3, 3), 1);

            // Sobel边缘检测
            grad = new Mat();
            grad = SobelCanny(Gao_img);

            // 初步二值化
            values_img = new Mat();
            Cv2.Threshold(grad, values_img, thresholdVal, 255, ThresholdTypes.Binary);

            // 形态学后处理
            Open2_img = new Mat();
            Open2_img = MorphProcess(values_img);

            // canny边缘检测获取轮廓图
            out_canny_img = new Mat();
            Cv2.Canny(Open2_img, out_canny_img, 10, 250, 5);

            Point[][] _conats;
            // 获取轮廓和轮廓拓扑信息
            Cv2.FindContours(Open2_img, out _conats, out _hierarchy, RetrievalModes.CComp, ContourApproximationModes.ApproxSimple);

            // 数组转list
            _conat = new List<List<Point>>();
            ArrytoList(_conats, ref _conat);

        }
        private static void ArrytoList(Point[][] _conats, ref List<List<Point>> pts)
        {
            for (int i = 0; i < _conats.Length; i++)
            {
                var points = _conats[i];
                List<Point> onPts = new List<Point>();
                for (int j = 0; j < points.Length; j++)
                {
                    onPts.Add(points[j]);
                }
                pts.Add(onPts);
            }
        }
        private static Mat GetGray(Mat ori)
        {
            Mat result = new Mat();
            Cv2.CvtColor(ori, result, ColorConversionCodes.BGR2GRAY);
            return result;
        }

        private static Mat SobelCanny(Mat gray_img)
        {
            Mat grad_x = new Mat(), grad_y = new Mat();
            Mat abs_grad_x = new Mat(), abs_grad_y = new Mat();
            Mat result = new Mat();

            // x方向
            Cv2.Sobel(Gao_img, grad_x, MatType.CV_16S, 1, 0);
            Cv2.ConvertScaleAbs(grad_x, abs_grad_x);

            // y方向
            Cv2.Sobel(Gao_img, grad_y, MatType.CV_16S, 0, 1);
            Cv2.ConvertScaleAbs(grad_y, abs_grad_y);

            Cv2.AddWeighted(abs_grad_x, 1, abs_grad_y, 1, 0, result);
            return result;
        }

        private static Mat MorphProcess(Mat val_img)
        {
            Mat result = new Mat();
            // 结构元素
            Mat element3 = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(CloseKernel, CloseKernel));
            Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(CloseKernel2, CloseKernel2));

            // 闭运算
            Cv2.MorphologyEx(val_img, result, MorphTypes.Close, element3);
            // 开运算
            Cv2.MorphologyEx(result, result, MorphTypes.Open, element);
            return result;
        }
    }
}

