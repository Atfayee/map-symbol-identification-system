using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Data;
using DotSpatial.Controls;
using OpenCvSharp;
using OSGeo.GDAL;
using OSGeo.OGR;
using System.Numerics;
using System.Diagnostics;

namespace GISdemoTest
{
    class vectorization
    {
        private const string filename = @"data2.asc";
        private int WindowSearch(double[,] info, int row, int col, int h, int w)
        {
            int ws = -9999;
            int r, left, right;
            r = 5;
            left = (r / 2);
            right = left + 1;
            //if (row==134&&col==471)
            //{
            //    int a = 4;
            //}
            for (int i = row - left; i < row + right; i++)
            {
                for (int j = col - left; j < col + right; j++)
                {
                    if (i < 0 || j < 0 || i >= h || j >= w)
                    {
                        continue;
                    }
                    else
                    {
                        if (info[i, j] == 0)
                        {
                            ws = -233;
                            break;
                        }
                    }
                }
            }
            return ws;

        }
        public static void CreateShpPolygon()
        {

            Gdal.AllRegister();

            //string strFile = @"data.asc";
            //读取路径中的栅格数据
            Dataset inraster = Gdal.Open(filename, Access.GA_ReadOnly);
            Band inband = inraster.GetRasterBand(1);
            Band maskband = inband.GetMaskBand();
            string prj = inraster.GetProjection();

            string outshp = Path.GetFileNameWithoutExtension(filename) + ".shp";
            //Console.WriteLine(outshp);string strDriver = "ESRI Shapefile";
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
            // 为了使属性表字段支持中文，请添加下面这句
            OSGeo.GDAL.Gdal.SetConfigOption("SHAPE_ENCODING", "");
            string strVectorFile1 = @"C:\Users\Administrator\Desktop\CS\c#\test";
            Ogr.RegisterAll();
            string strDriver = "ESRI Shapefile";
            OSGeo.OGR.Driver oDriver = Ogr.GetDriverByName(strDriver);
            if (oDriver == null)
            {
                MessageBox.Show(" 驱动不可用！\n", strVectorFile1);
                return;
            }
            //创建一个目标文件
            DataSource polygon_ds = oDriver.CreateDataSource(strVectorFile1, null);
            Layer polygon_layer = polygon_ds.CreateLayer(Path.GetFileNameWithoutExtension(filename), null, wkbGeometryType.wkbPolygon, null);
            FieldDefn filed_value = new FieldDefn("value", FieldType.OFTReal);
            polygon_layer.CreateField(filed_value, 1);

            Gdal.Polygonize(inband, maskband, polygon_layer, 0, null, null, null);
            polygon_layer.SyncToDisk();

            polygon_layer.Dispose();
            Console.ReadLine();

            MessageBox.Show("shp面图层创建完成！");

        }
        public void Vectorization(IMapImageLayer it)
        {
            //读取图像图层数据集
            IImageData iter = it.DataSet;
            //转为一维数组
            Byte[] vs = iter.Values;
            //去除A(亮度波段）
            for (int i = 0; i < vs.Length; i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    vs[i] = 0;
                }
            }
            int bands = iter.NumBands;
            //将IImageData中的数据读入opencv的Mat格式数据中
            Mat it1 = new Mat(iter.Height, iter.Width, MatType.CV_8UC4, vs);
            //灰度
            Mat it2 = new Mat(it1.Rows, it1.Cols, it1.Depth());
            Cv2.CvtColor(it1, it2, ColorConversionCodes.BGR2GRAY);
            //二值化
            Mat it3 = new Mat(it2.Rows, it2.Cols, it2.Depth());
            Cv2.Threshold(it2, it3, 120, 255, 0);
            //闭运算
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(3, 3), new OpenCvSharp.Point(-1, -1));
            //膨胀
            Mat it4 = new Mat(it3.Rows, it3.Cols, it3.Depth());
            Cv2.Dilate(it3, it4, kernel, new OpenCvSharp.Point(-1, -1), 1);
            //腐蚀
            Mat it5 = new Mat(it4.Rows, it4.Cols, it4.Depth());
            Cv2.Dilate(it4, it5, kernel, new OpenCvSharp.Point(-1, -1), 1);

            //转为IImageData格式
            Bitmap bt = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(it3);
            iter.WriteBlock(bt, 0, 0);
            //真正二值化
            for (int i = 0; i < iter.Height * iter.Width * 4; i++)
            {
                if (iter.Values[i] < 11)
                {
                    iter.Values[i] = 0;

                }
            }
            //将有    效数据放入数组
            double[,] info = new double[iter.Height, iter.Width];
            int row, col;
            row = col = 0;
            for (int i = 0; i < iter.Height * iter.Width * 4; i += 4)
            {
                info[row, col] = iter.Values[i + 0] + iter.Values[i + 1] + iter.Values[i + 2];
                col++;
                if (col == iter.Width)
                {
                    col = 0;
                    row++;
                }
            }
            //写为栅格文件
            StreamWriter wt = new StreamWriter(filename);
            wt.WriteLine("ncols\t{0}", iter.Width);
            wt.WriteLine("nrows\t{0}", iter.Height);
            wt.WriteLine("xllcorner\t{0}", 0);
            wt.WriteLine("yllcorner\t{0}", 0);
            wt.WriteLine("cellsize\t{0}", 1);
            wt.WriteLine("NODATA_value\t{0}", -9999);
            int h = iter.Height;
            int w = iter.Width;

            for (int i = 0; i < iter.Height; i++)
            {
                for (int j = 0; j < iter.Width; j++)
                {
                    if (info[i, j] != 0)
                    {
                        info[i, j] = WindowSearch(info, i, j, h, w);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            for (int i = 0; i < iter.Height; i++)
            {
                for (int j = 0; j < iter.Width; j++)
                {
                    int out2 = 1;
                    if (info[i, j] == 0 || info[i, j] == -233)
                    {
                        out2 = 1;/*无效值为nodata*/
                    }
                    else
                    {
                        out2 = -9999;
                    }
                    wt.Write("{0} ", out2);
                }
                wt.Write("\n");
            }
            wt.Close();
            CreateShpPolygon();
            //加载并显示


        }
    }
}
