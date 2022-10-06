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
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Topology;
using OpenCvSharp;
using System.Text.RegularExpressions;

namespace GISdemoTest
{
    public partial class Form1 : Form
    {
        string fileType;
        string shapeType;
        #region Point ShapeFile class level variable

        //the new point feature set
        FeatureSet pointF = new FeatureSet(FeatureType.Point);

        //the id of point
        int pointID = 0;

        //to differentiate the right and left mouse click
        bool pointmouseClick = false;

        #endregion
        #region Polyline  ShapeFile class level variables

        MapLineLayer lineLayer = default(MapLineLayer);

        //the line feature set
        FeatureSet lineF = new FeatureSet(FeatureType.Line);

        int lineID = 0;

        //boolean variable for first time mouse click
        bool firstClick = false;

        //It controls the drawing the polyline after the polyline saved operation.
        bool linemouseClick = false;

        #endregion

        #region Polygon ShapeFile class level variables

        FeatureSet polygonF = new FeatureSet(FeatureType.Polygon);

        int polygonID = 0;

        bool polygonmouseClick = false;

        #endregion
        #region "Class level varibales"
        //the line layer
        //MapLineLayer lineLayer = default(MapLineLayer);
        //the line feature set
        //FeatureSet lineF = new FeatureSet(FeatureType.Line);
        //int lineID = 0;
        //boolean variable for first time mouse click
        //bool firstClick = false;
        //boolean variable for ski path drawing finished
        bool hikingpathPathFinished = false;
        #endregion

        #region "轮廓检测信息"
        private Mat ori_img;
        public Mat Canny_img;
        public List<HSV> colorList;
        public Mat Ori_img
        {
            get
            {
                return ori_img ?? new Mat();
            }
            set
            {
                if (ori_img != null)
                {
                    ori_img = value;
                    return;
                }
                ori_img = new Mat();
                ori_img = value;
            }
        }

        private List<List<OpenCvSharp.Point>> _conat;
        private HierarchyIndex[] _hierarchyIndices;
        #endregion

        public static Form1 f1 { get; set; }
        public static IFeatureSet featureSet1_ { get; set; }
        public static Map map1_ { get; set; }

        public class PathPoint
        {
            public double X;
            public double Y;
            public double Distance;
            public double Elevation;
        }



        public Form1()
        {
            map1_ = map1;
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //菜单栏
        //======================文件栏==========================

        //去除地图
        private void ClearMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear() method is used to clear the layers from the map control.
            map1.Layers.Clear();
        }

        // 打印地图
        private void PrintMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DotSpatial.Controls.LayoutForm frm = new DotSpatial.Controls.LayoutForm();
            frm.MapControl = map1;
            frm.Show();
        }

        //打开地图
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear the existing layers from the map control
            if ((map1.Layers.Count > 0))
            {
                map1.Layers.Clear();
            }
       
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "图片|*.png";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog.FileName;
                map1.AddLayer(filename);
                map1.FunctionMode = FunctionMode.Select;
            }               
        }

        //保存
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.SaveLayer();
        }
        ////另存为
        //private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
            
        //    SaveFileDialog fileDialog = new SaveFileDialog();
        //    if (fileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        var featureSet1 = FeatureSet.Open(fileDialog.FileName);
        //        featureSet1.SaveAs(fileDialog.FileName, true);
        //    }

        private void closeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //}
        //===========================编辑栏==================================
        //选择所有元素
        private void selectAll_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPolygonLayer statelayer = (MapPolygonLayer)map1.Layers[0];
            statelayer.SelectAll();
        }
        //取消选择
        private void UnselectAll_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPolygonLayer statelayer = (MapPolygonLayer)map1.Layers[0];
            statelayer.ClearSelection();
        }
        //开始编辑 点、线、面
        private void createPointShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Change the cursor style
            map1.Cursor = Cursors.Cross;
            //set the shape type to the classlevel string variable
            //we are going to use this variable in select case statement
            shapeType = "Point";
            //set projection
            pointF.Projection = map1.Projection;
            //initialize the featureSet attribute table
            DataColumn column = new DataColumn("ID");
            pointF.DataTable.Columns.Add(column);
            //add the featureSet as map layer
            MapPointLayer pointLayer = (MapPointLayer)map1.Layers.Add(pointF);
            //Create a new symbolizer
            PointSymbolizer symbol = new PointSymbolizer(Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 3);
            //Set the symbolizer to the point layer
            pointLayer.Symbolizer = symbol;
            //Set the legentText as point
            pointLayer.LegendText = "point";
            //Set left mouse click as true
            pointmouseClick = true;
        }


        private void CreatePolylineShapeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Change the mouse cursor
            map1.Cursor = Cursors.Cross;

            //set shape type
            shapeType = "line";

            //set projection
            lineF.Projection = map1.Projection;

            //initialize the featureSet attribute table
            DataColumn column = new DataColumn("LineID");

            if (!lineF.DataTable.Columns.Contains("LineID"))
            {
                lineF.DataTable.Columns.Add(column);
            }

            //add the featureSet as map layer
            lineLayer = (MapLineLayer)map1.Layers.Add(lineF);

            //Set the symbolizer to the line feature. 
            LineSymbolizer symbol = new LineSymbolizer(Color.Blue, 2);
            lineLayer.Symbolizer = symbol;
            lineLayer.LegendText = "line";

            firstClick = true;

            linemouseClick = true;
        }


        private void CreatePolygonShapeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //initialize polyline feature set
            map1.Cursor = Cursors.Cross;

            //set shape type
            shapeType = "polygon";

            //set projection
            polygonF.Projection = map1.Projection;

            //initialize the featureSet attribute table
            DataColumn column = new DataColumn("PolygonID");

            if (!polygonF.DataTable.Columns.Contains("PolygonID"))
            {
                polygonF.DataTable.Columns.Add(column);
            }

            //add the featureSet as map layer
            MapPolygonLayer polygonLayer = (MapPolygonLayer)map1.Layers.Add(polygonF);

            PolygonSymbolizer symbol = new PolygonSymbolizer(Color.Green);

            polygonLayer.Symbolizer = symbol;
            polygonLayer.LegendText = "polygon";

            firstClick = true;

            polygonmouseClick = true;

        }
        private void SaveShapeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (shapeType)
            {
                case "Point":
                    {
                        pointF.SaveAs("point.shp", true);
                        MessageBox.Show("The point shapefile has been saved.");
                        map1.Cursor = Cursors.Arrow;
                    }
                    break;
                case "line":
                    {
                        lineF.SaveAs("line.shp", true);
                        MessageBox.Show("The line shapefile has been saved.");
                        map1.Cursor = Cursors.Arrow;
                    }
                    break;
                case "polygon":
                    {
                        polygonF.SaveAs("c:\\MW\\polygon.shp", true);
                        MessageBox.Show("The polygon shapefile has been saved.");
                        map1.Cursor = Cursors.Arrow;
                        polygonmouseClick = false;
                    }
                    break;
            }
            
        }
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help form = new help();
            form.Show();
        }
    private void Map1_MouseDown(object sender, MouseEventArgs e)
        {

            switch (fileType)
            {
                case ".bgd":
                    {
                        //if ski path is fininshed, don't draw any line
                        if (hikingpathPathFinished == true)
                            return;
                        if (e.Button == MouseButtons.Left)
                        {
                            //left click - fill array of coordinates
                            //coordinate of clicked point
                            Coordinate coord = map1.PixelToProj(e.Location);
                            //first time left click - create empty line feature
                            if (firstClick)
                            {
                                //Create a new List called lineArray.
                                //In List we need not define the size and also 
                                //Here this list will store the Coordinates
                                //We are going to store the mouse click coordinates into this array.
                                List<Coordinate> lineArray = new List<Coordinate>();

                                //Create an instance for LineString class.
                                //We need to pass collection of list coordinates
                                LineString lineGeometry = new LineString(lineArray);

                                //Add the linegeometry to line feature
                                IFeature lineFeature = lineF.AddFeature(lineGeometry);

                                //add first coordinate to the line feature
                                lineFeature.Coordinates.Add(coord);
                                //set the line feature attribute
                                lineID = lineID + 1;
                                lineFeature.DataRow["ID"] = lineID;
                                firstClick = false;
                            }
                            else
                            {
                                //second or more clicks - add points to the existing feature
                                IFeature existingFeature = lineF.Features[lineF.Features.Count - 1];
                                existingFeature.Coordinates.Add(coord);
                                //refresh the map if line has 2 or more points
                                if (existingFeature.Coordinates.Count >= 2)
                                {
                                    lineF.InitializeVertices();
                                    map1.ResetBuffer();
                                }
                            }
                        }
                        else
                        {
                            //right click - reset first mouse click
                            firstClick = true;
                            map1.ResetBuffer();
                            lineF.SaveAs("c:\\2009 Falls\\linepath.shp", true);
                            MessageBox.Show("The line shapefile has been saved.");
                            map1.Cursor = Cursors.Arrow;
                            //the ski path is finished
                            hikingpathPathFinished = true;
                        }
                    }
                    break;
                case ".shp":
                    {
                        switch (shapeType)
                        {
                            case "Point":
                                if (e.Button == MouseButtons.Left)
                                {
                                    if ((pointmouseClick))
                                    {
                                        //This method is used to convert the screen cordinate to map coordinate
                                        //e.location is the mouse click point on the map control
                                        Coordinate coord = map1.PixelToProj(e.Location);

                                        //Create a new point
                                        //Input parameter is clicked point coordinate
                                        DotSpatial.Topology.Point point = new DotSpatial.Topology.Point(coord);

                                        //Add the point into the Point Feature
                                        //assigning the point feature to IFeature because via it only we can set the attributes.
                                        IFeature currentFeature = pointF.AddFeature(point);

                                        //increase the point id
                                        pointID = pointID + 1;

                                        //set the ID attribute
                                        currentFeature.DataRow["ID"] = pointID;

                                        //refresh the map
                                        map1.ResetBuffer();
                                    }
                                }
                                else
                                {
                                    //mouse right click
                                    map1.Cursor = Cursors.Default;
                                    pointmouseClick = false;
                                }
                                break;
                            case "line":
                                if (e.Button == MouseButtons.Left)
                                {
                                    //left click - fill array of coordinates
                                    //coordinate of clicked point
                                    Coordinate coord = map1.PixelToProj(e.Location);
                                    if (linemouseClick)
                                    {
                                        //first time left click - create empty line feature
                                        if (firstClick)
                                        {
                                            //Create a new List called lineArray.                          
                                            //This list will store the Coordinates
                                            //We are going to store the mouse click coordinates into this array.
                                            List<Coordinate> lineArray = new List<Coordinate>();

                                            //Create an instance for LineString class.
                                            //We need to pass collection of list coordinates
                                            LineString lineGeometry = new LineString(lineArray);

                                            //Add the linegeometry to line feature
                                            IFeature lineFeature = lineF.AddFeature(lineGeometry);

                                            //add first coordinate to the line feature
                                            lineFeature.Coordinates.Add(coord);
                                            //set the line feature attribute
                                            lineID = lineID + 1;
                                            lineFeature.DataRow["LineID"] = lineID;
                                            firstClick = false;
                                        }
                                        else
                                        {
                                            //second or more clicks - add points to the existing feature
                                            IFeature existingFeature = lineF.Features[lineF.Features.Count - 1];
                                            existingFeature.Coordinates.Add(coord);

                                            //refresh the map if line has 2 or more points
                                            if (existingFeature.Coordinates.Count >= 2)
                                            {
                                                lineF.InitializeVertices();
                                                map1.ResetBuffer();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //right click - reset first mouse click
                                    firstClick = true;
                                    map1.ResetBuffer();
                                }
                                break;
                            case "polygon":

                                if (e.Button == MouseButtons.Left)
                                {
                                    //left click - fill array of coordinates
                                    Coordinate coord = map1.PixelToProj(e.Location);

                                    if (polygonmouseClick)
                                    {
                                        //first time left click - create empty line feature
                                        if (firstClick)
                                        {
                                            //Create a new List called polygonArray.

                                            //this list will store the Coordinates
                                            //We are going to store the mouse click coordinates into this array.

                                            List<Coordinate> polygonArray = new List<Coordinate>();

                                            //Create an instance for LinearRing class.
                                            //We pass the polygon List to the constructor of this class
                                            LinearRing polygonGeometry = new LinearRing(polygonArray);

                                            //Add the polygonGeometry instance to PolygonFeature
                                            IFeature polygonFeature = polygonF.AddFeature(polygonGeometry);

                                            //add first coordinate to the polygon feature
                                            polygonFeature.Coordinates.Add(coord);

                                            //set the polygon feature attribute
                                            polygonID = polygonID + 1;
                                            polygonFeature.DataRow["PolygonID"] = polygonID;
                                            firstClick = false;
                                        }
                                        else
                                        {
                                            //second or more clicks - add points to the existing feature
                                            IFeature existingFeature = (IFeature)polygonF.Features[polygonF.Features.Count - 1];

                                            existingFeature.Coordinates.Add(coord);

                                            //refresh the map if line has 2 or more points
                                            if (existingFeature.Coordinates.Count >= 3)
                                            {
                                                //refresh the map
                                                polygonF.InitializeVertices();
                                                map1.ResetBuffer();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //right click - reset first mouse click
                                    firstClick = true;
                                }
                                break;


                        }
                    }
                    break;
            }


        }
        //======================选择栏==========================
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            //ZoomIn method is used to ZoomIn the shape file
            map1.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            //ZoomOut method is used to ZoomIn the shape file
            map1.ZoomOut();
        }

        private void btnZoomToExtent_Click(object sender, EventArgs e)
        {
            //ZoomToMaxExtent method is used to Extent the shape file
            map1.ZoomToMaxExtent();
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            //Pan function is used to pan the map
            map1.FunctionMode = FunctionMode.Pan;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            //Info function is used to get the information of the selected shape
            map1.FunctionMode = FunctionMode.Info;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Select function is used to select a shape on the shape file
            map1.FunctionMode = FunctionMode.Select;
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            //Select function is used to select a shape on the shape file
            map1.FunctionMode = FunctionMode.Pan;
            MapPolygonLayer statelayer = (MapPolygonLayer)map1.Layers[0];
            statelayer.ClearSelection();
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            // None function is used to change the mouse cursor to default
            map1.FunctionMode = FunctionMode.None;
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            //Measure function is used to measure the distance and area
            DotSpatial.Plugins.Measure.MapFunctionMeasure mapFunctionMeasure = new DotSpatial.Plugins.Measure.MapFunctionMeasure(map1);
            map1.ActivateMapFunction(mapFunctionMeasure);
        }

        private void btnAttributeTable_Click(object sender, EventArgs e)
        {

            map1_ = map1;
            AttributeTable form = new AttributeTable();
            form.Show();
        }
        

        private void toolManager1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void map1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Result_Click(object sender, EventArgs e)
        {
            //IdentificationResult form = new IdentificationResult();
            //form.StartPosition = FormStartPosition.CenterParent;
            //form.ShowDialog();


            // 获取检测的图像
            IMapLayer layer = map1.Layers.SelectedLayer;
            Ori_img = DataModel.Layer2Mat(map1.Layers.SelectedLayer);

            // 检测轮廓
            FindCanny.findCanny(Ori_img, out Canny_img, out _conat, out _hierarchyIndices);

            // 获取颜色            
            FindColor.findColor(Ori_img, _conat, out colorList);

            // 显示轮廓图
            string canny_layer_url = DataModel.Mat2layer(Canny_img, "轮廓图.png");
            map1.AddLayer(canny_layer_url);

            //逐轮廓进行形状检测
            List<ShapeType> allshape = new List<ShapeType>();
            Shapedetect sd = new Shapedetect();
            for (int j = 0; j < _conat.Count; j++)
            {
                List<OpenCvSharp.Point> LPt = _conat[j];
                OpenCvSharp.Point[] pts = new OpenCvSharp.Point[_conat[j].Count];
                for (int i = 0; i < LPt.Count; i++)
                {
                    pts[i].X = LPt[i].X; pts[i].Y = LPt[i].Y;
                }
                int circleon = 0;
                if (allshape.Count!=0)
                {
                    if (allshape[0]== ShapeType.Circle)
                    {
                        circleon = 1;
                    }
                }
                //形状检测
                ShapeType st0 = sd.ShapeDetect(pts, circleon);
                allshape.Add(st0);
            }
            GeoShapeStatistic gss = sd.GSS(allshape);

            //符号检测
            symboldetect sbd = new symboldetect();
            sbd.SymbolDetect(gss, colorList);
        }

        private void Capture_Click(object sender, EventArgs e)
        {
            

        }

        private void 形状颜色识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 获取检测的图像
            IMapLayer layer = map1.Layers.SelectedLayer;
            Ori_img = DataModel.Layer2Mat(map1.Layers.SelectedLayer);

            // 检测轮廓
            FindCanny.findCanny(Ori_img, out Canny_img, out _conat, out _hierarchyIndices);

            // 获取颜色            
            FindColor.findColor(Ori_img, _conat, out colorList);

            // 显示轮廓图
            string canny_layer_url = DataModel.Mat2layer(Canny_img, "轮廓图.png");
            map1.AddLayer(canny_layer_url);

            //逐轮廓进行形状检测
            List<ShapeType> allshape = new List<ShapeType>();
            Shapedetect sd = new Shapedetect();
            for (int j = 0; j < _conat.Count; j++)
            {
                List<OpenCvSharp.Point> LPt = _conat[j];
                OpenCvSharp.Point[] pts = new OpenCvSharp.Point[_conat[j].Count];
                for (int i = 0; i < LPt.Count; i++)
                {
                    pts[i].X = LPt[i].X; pts[i].Y = LPt[i].Y;
                }
                int circleon = 0;
                if (allshape.Count != 0)
                {
                    if (allshape[0] == ShapeType.Circle)
                    {
                        circleon = 1;
                    }
                }
                //形状检测
                ShapeType st0 = sd.ShapeDetect(pts, circleon);
                allshape.Add(st0);
            }
            GeoShapeStatistic gss = sd.GSS(allshape);
            symboldetect sbd=new symboldetect ();
            List<int> GeoIndt = sbd.Gss2GI(gss);
            StreamWriter wt = new StreamWriter("out.txt");
            for (int i = 0; i < GeoIndt.Count; i++)
            {
                wt.Write("{0},", GeoIndt[i]);
            }
            for (int i = 0; i < colorList.Count; i++)
            {
                wt.Write("{0}|{1}|{1},", colorList[i].H, colorList[i].S,colorList[i].V);
            }
            wt.Close();
        }

        private void 数据入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMapLayer layer = map1.Layers.SelectedLayer;
            Ori_img = DataModel.Layer2Mat(map1.Layers.SelectedLayer);

            // 检测轮廓
            FindCanny.findCanny(Ori_img, out Canny_img, out _conat, out _hierarchyIndices);

            // 获取颜色            
            FindColor.findColor(Ori_img, _conat, out colorList);

            // 显示轮廓图
            string canny_layer_url = DataModel.Mat2layer(Canny_img, "轮廓图.png");
            map1.AddLayer(canny_layer_url);

            //逐轮廓进行形状检测
            List<ShapeType> allshape = new List<ShapeType>();
            Shapedetect sd = new Shapedetect();
            for (int j = 0; j < _conat.Count; j++)
            {
                List<OpenCvSharp.Point> LPt = _conat[j];
                OpenCvSharp.Point[] pts = new OpenCvSharp.Point[_conat[j].Count];
                for (int i = 0; i < LPt.Count; i++)
                {
                    pts[i].X = LPt[i].X; pts[i].Y = LPt[i].Y;
                }
                int circleon = 0;
                if (allshape.Count != 0)
                {
                    if (allshape[0] == ShapeType.Circle)
                    {
                        circleon = 1;
                    }
                }
                //形状检测
                ShapeType st0 = sd.ShapeDetect(pts, circleon);
                allshape.Add(st0);
            }
            GeoShapeStatistic gss = sd.GSS(allshape);
            symboldetect sbd = new symboldetect();
            List<int> GeoIndt = sbd.Gss2GI(gss);
            AddSymbol fm = new AddSymbol(GeoIndt,colorList);
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.Show();
        }

        private void 矢量化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //取出图像图层
            IMapImageLayer it = (IMapImageLayer)map1.Layers.SelectedLayer;
            vectorization vz = new vectorization();
            vz.Vectorization(it);

        }
    }
}
