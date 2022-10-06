using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using OpenCvSharp;

namespace GISdemoTest
{
    public enum ShapeType
    {
        NonShape,
        Triangle1,
        Triangle2,
        Rectangle,
        Squared,
        Rhombus1,
        Rhombus2,
        Pentagon,
        Hexagon,
        Circle,
        Fan,

    }
    public struct Geo
    {
        public OpenCvSharp.Point center;
        public int left, right, bottom, top;
        public OpenCvSharp.Point center2;
    }
    public struct GeoShapeStatistic
    {
        public int Triangle1,
        Triangle2,
        Rectangle,
        Squared,
        Rhombus1,
        Rhombus2,
        Pentagon,
        Hexagon,
        Circle,
        Fan;
        
    }
    class Shapedetect
    {
        public GeoShapeStatistic GSS(List<ShapeType> allshape )
        {
            GeoShapeStatistic gss;
            gss.Triangle1 = gss.Triangle2 = gss.Rectangle = gss.Squared = gss.Rhombus1 = gss.Rhombus2 = gss.Pentagon = gss.Hexagon = gss.Circle = gss.Fan = 0;
            for (int i = 0; i < allshape.Count; i++)
            {
                if (allshape[i]== ShapeType.Triangle1)
                {
                    gss.Triangle1++;
                }
                else if (allshape[i] == ShapeType.Triangle2)
                {
                    gss.Triangle2++;
                }
                else if (allshape[i] == ShapeType.Rectangle)
                {
                    gss.Rectangle++;
                }
                else if (allshape[i] == ShapeType.Squared)
                {
                    gss.Squared++;
                }
                else if (allshape[i] == ShapeType.Rhombus1)
                {
                    gss.Rhombus1++;
                }
                else if (allshape[i] == ShapeType.Rhombus2)
                {
                    gss.Rhombus2++;
                }
                else if (allshape[i] == ShapeType.Pentagon)
                {
                    gss.Pentagon++;
                }
                else if (allshape[i] == ShapeType.Hexagon)
                {
                    gss.Hexagon++;
                }
                else if (allshape[i] == ShapeType.Circle)
                {
                    gss.Circle++;
                }
                else if (allshape[i] == ShapeType.Fan)
                {
                    gss.Fan++;
                }
            }
            return gss;
        }
        private static Geo GetGeometry(OpenCvSharp.Point[] LPt)
        {
            Geo geo = new Geo();
            geo.left = geo.right = LPt[0].X; geo.bottom = geo.top = LPt[0].Y;
            double sumx = 0, sumy = 0;
            for (int i = 0; i < LPt.Length; i++)
            {
                sumx += LPt[i].X;
                sumy += LPt[i].Y;
                if (LPt[i].X > geo.right)
                {
                    geo.right = LPt[i].X;
                }
                else if (LPt[i].X < geo.left)
                {
                    geo.left = LPt[i].X;
                }
                if (LPt[i].Y > geo.top)
                {
                    geo.top = LPt[i].Y;
                }
                else if (LPt[i].Y < geo.bottom)
                {
                    geo.bottom = LPt[i].Y;
                }
            }
            geo.center.X = (int)(sumx / LPt.Length - 1);
            geo.center.Y = (int)(sumy / LPt.Length - 1);
            geo.center2 = new OpenCvSharp.Point((geo.left + geo.right) / 2, (geo.bottom + geo.top) / 2);
            return geo;
        }
        private static List<float> LFD(OpenCvSharp.Point[] LPt, OpenCvSharp.Point center)
        {
            List<float> ds = new List<float>();
            for (int i = 0; i < LPt.Length - 1; i++)
            {
                float d = (float)Math.Sqrt(Math.Pow((LPt[i].X - center.X), 2) + Math.Pow((LPt[i].Y - center.Y), 2));
                ds.Add(d);
            }
            return ds;
        }
        private static Vector2 VecNormalization(Vector2 v)
        {
            Vector2 v2;
            float d = (float)Math.Sqrt(Math.Pow(v.X, 2) + Math.Pow((v.Y), 2));
            v2.X = (float)v.X / d; v2.Y = (float)v.Y / d;
            return v2;
        }
        public  ShapeType ShapeDetect(OpenCvSharp.Point[] conat,int co, double polyCoffe = 0.04, double areaCoffe = 999)
        {
            ShapeType shapeType = 0;
            double ellp = polyCoffe * Cv2.ArcLength(conat, true);
            //Point a = new Point();

            //TODO 对轮廓根据周长和面积筛选
            var pts = Cv2.ApproxPolyDP(conat, ellp, true);
            var m = Cv2.Moments(conat);
            double cx = m.M10 / m.M00;
            double cy = m.M01 / m.M00;
            //Console.WriteLine(Program.Ori_img.At<Vec3b>((int)cx, (int)cy));
            if (pts.Length>6|| pts.Length==5||co==1)
            {
                pts = Cv2.ApproxPolyDP(conat, 0.001, true);
            }
            shapeType = MatchShape(pts);
            return shapeType;
        }
        private static ShapeType shape3detect(OpenCvSharp.Point[] pts)
        {
            ShapeType shapeType = 0;
            //List<Vector2> LV = new List<Vector2>();
            Vector2 a, b, c;
            a.X = pts[1].X - pts[0].X; a.Y = pts[1].Y - pts[0].Y;
            b.X = pts[2].X - pts[1].X; b.Y = pts[2].Y - pts[1].Y;
            c.X = pts[0].X - pts[2].X; c.Y = pts[0].Y - pts[2].Y;
            a = VecNormalization(a); b = VecNormalization(b); c = VecNormalization(c);
            float an1, an2, an3;
            an1 = Vector2.Dot(a, b); an2 = Vector2.Dot(a, c); an3 = Vector2.Dot(c, b);
            if (Math.Abs(an1) < 0.2|| Math.Abs(an2) < 0.2 || Math.Abs(an3) < 0.2)
            {
                shapeType = ShapeType.Triangle1;
            }
            else
            {
                shapeType = ShapeType.Triangle2;
            }
            return shapeType;
        }
        private static ShapeType shape4detect(OpenCvSharp.Point[] pts)
        {
            ShapeType shapeType = 0;
            //List<Vector2> LV = new List<Vector2>();
            Vector2 a, b, c, d, e, f;
            a.X = pts[1].X - pts[0].X; a.Y = pts[1].Y - pts[0].Y;
            b.X = pts[2].X - pts[1].X; b.Y = pts[2].Y - pts[1].Y;
            c.X = pts[3].X - pts[2].X; c.Y = pts[3].Y - pts[2].Y;
            d.X = pts[0].X - pts[3].X; d.Y = pts[0].Y - pts[3].Y;
            e.X = pts[0].X - pts[2].X; e.Y = pts[0].Y - pts[2].Y;
            f.X = pts[1].X - pts[3].X; f.Y = pts[1].Y - pts[3].Y;
            a = VecNormalization(a); b = VecNormalization(b); c = VecNormalization(c);
            d = VecNormalization(d); e = VecNormalization(e); f = VecNormalization(f);
            float an1, an2, an3, an4;
            an1 = Vector2.Dot(a, b); an2 = Vector2.Dot(d, c); an3 = Vector2.Dot(c, b); an4 = Vector2.Dot(e, f);
            if (Math.Abs(an4) > 0.25)
            {
                shapeType = ShapeType.Rectangle;
            }
            else if (Math.Abs(an1) < 0.001 || Math.Abs(an2) < 0.001 || Math.Abs(an3) < 0.001)
            {
                shapeType = ShapeType.Squared;
            }
            else
            {
                Geo geo = GetGeometry(pts);
                int h = geo.top - geo.bottom; int w = geo.right - geo.left;
                if (h > w)
                {
                    shapeType = ShapeType.Rhombus1;
                }
                else
                {
                    shapeType = ShapeType.Rhombus2;
                }
            }
            return shapeType;
        }
        private static ShapeType shapecirdetect(OpenCvSharp.Point[] pts)
        {
            ShapeType shapeType = 0;
            Geo geo = GetGeometry(pts);
            OpenCvSharp.Point center = geo.center2;
            int h = geo.top - geo.bottom; int w = geo.right - geo.left;
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].X = (int)((float)pts[i].X / w * 200);
                pts[i].Y = (int)((float)pts[i].Y / h * 200);
            }
            List<float> aved = LFD(pts, center);
            List<float> daved = new List<float>();
            for (int i = 0; i < aved.Count - 1; i++)
            {
                daved.Add(Math.Abs(aved[i + 1] - aved[i]));
            }
            daved.Add(Math.Abs(aved[aved.Count - 1] - aved[0]));
            for (int i = 0; i < (int)(pts.Length/8); i++)
            {
                daved.Remove(daved.Max());
            }
            float t = daved.Max();
            if (daved.Max() > 15)
            {
                shapeType = ShapeType.Fan;
            }
            else
            {
                shapeType = ShapeType.Circle;
            }
            return shapeType;
        }
        private static ShapeType MatchShape(OpenCvSharp.Point[] pts)
        {
            ShapeType shapeType = 0;
            int i = pts.Length;
            switch (i)
            {
                case 3:
                    //TODO 三角形形状判断
                    shapeType = shape3detect(pts);
                    break;
                case 4:
                    shapeType = shape4detect(pts);
                    break;
                case 5:
                    shapeType = ShapeType.Pentagon;
                    break;
                case 6:
                    shapeType = ShapeType.Hexagon;
                    break;
                default:
                    shapeType = shapecirdetect(pts);
                    break;
            }
            return shapeType;
        }
    }
}
