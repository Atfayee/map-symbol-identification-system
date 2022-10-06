using DotSpatial.Controls;
using DotSpatial.Symbology;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GISdemoTest
{
    public partial class AttributeTable : Form
    {
        public AttributeTable()
        {
            
            InitializeComponent();
            ViewAttrbute();
        }

        private void ViewAttrbute()
        {

            //Declare a datatable
            System.Data.DataTable dt = null;
            Map map = Form1.map1_;
            if (map.Layers.Count > 0)
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);

                stateLayer = (MapPolygonLayer)Form1.map1_.Layers[0];

                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;
                    //Set the datagridview datasource from datatable dt
                    dgvAttributeTable.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        private void CreateAColumInAttributeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare a datatable
            System.Data.DataTable dt = null;

            //check the layers
            if (Form1.map1_.Layers.Count > 0)
            {
                //Declare a mappolygon layer
                MapPolygonLayer stateLayer = default(MapPolygonLayer);

                //Assign the mappolygon layer from the map
                stateLayer = (MapPolygonLayer)Form1.map1_.Layers[0];

                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;

                    //Add new column
                    DataColumn column = new DataColumn("PointID");
                    dt.Columns.Add(column);

                    ////calculate values
                    //foreach (DataRow row in dt.Rows)
                    //{

                    //    //double males = Convert.ToDouble(row["males"]);
                    //    //double females = Convert.ToDouble(row["females"]);
                    //    //double malesPercentage = (males / (males + females)) * 100;
                    //    row["PointID"] = ' ';
                    //}
                    //Set the datagridview datasource from datatable dt
                    dgvAttributeTable.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }

        }
        private void SaveTheColumInShapeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.map1_.Layers.Count > 0)
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);
                stateLayer = (MapPolygonLayer)Form1.map1_.Layers[0];
                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    stateLayer.DataSet.Save();
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }
        private void DeleteColumnInAttributeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare a datatable
            System.Data.DataTable dt = null;

            if (Form1.map1_.Layers.Count > 0)
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);

                stateLayer = (MapPolygonLayer)Form1.map1_.Layers[0];

                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;

                    //Remove a column
                    dt.Columns.Remove("PointID");

                    //Set the datagridview datasource from datatable dt
                    dgvAttributeTable.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }

        }
        private void ExportAttributeTableToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare a datatable
            System.Data.DataTable dt = null;

            if (Form1.map1_.Layers.Count > 0)
            {
                MapPolygonLayer stateLayer = default(MapPolygonLayer);
                stateLayer = (MapPolygonLayer)Form1.map1_.Layers[0];
                if (stateLayer == null)
                {
                    MessageBox.Show("The layer is not a polygon layer.");
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = stateLayer.DataSet.DataTable;
                    //Call the sub ExportToExcel 
                    //This sub procedure expects a datatable as an input
                    //ExportToExcel(dt);
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }

        }

        /// <summary>
        /// This sub method is used to create an excel worksheet from the attribute table
        /// </summary>
        /// <param name="objDT">attribute table as a datatable input</param>
        /// <remarks>Click the COM tab of the Add Reference dialog box, and find Microsoft Excel 14 Object Library.</remarks>

        //private void ExportToExcel(System.Data.DataTable objDT)
        //{
        //    //excel = new Excel.Application();
        //    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();


        //    string strFilename = null;
        //    int intCol = 0;
        //    int intRow = 0;
        //    //path for storing excel datasheet
        //    string strPath = "C:\\2009 Falls\\";

        //    if (xlApp == null)
        //    {
        //        MessageBox.Show("It appears that Excel is not installed on this machine. This operation requires MS Excel to be installed on this machine.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }
        //    try
        //    {
        //        //var _with1 = Microsoft.Office.Interop.Excel.Application();
        //        xlApp.SheetsInNewWorkbook = 1;
        //        xlApp.Workbooks.Add();
        //        xlApp.Worksheets[1].Select();

        //        xlApp.Cells[1, 1].value = "Attribute table";
        //        //Heading of the excel file
        //        xlApp.Cells[1, 1].EntireRow.Font.Bold = true;

        //        //Add the column names from the attribute table to excel worksheet
        //        int intI = 1;
        //        for (intCol = 0; intCol <= objDT.Columns.Count - 1; intCol++)
        //        {
        //            xlApp.Cells[2, intI].value = objDT.Columns[intCol].ColumnName;
        //            xlApp.Cells[2, intI].EntireRow.Font.Bold = true;
        //            intI += 1;
        //        }

        //        //Add the data row values from the attribute table to ecxel worksheet
        //        intI = 3;
        //        int intK = 1;
        //        for (intCol = 0; intCol <= objDT.Columns.Count - 1; intCol++)
        //        {
        //            intI = 3;
        //            for (intRow = 0; intRow <= objDT.Rows.Count - 1; intRow++)
        //            {
        //                xlApp.Cells[intI, intK].Value = objDT.Rows[intRow].ItemArray[intCol];
        //                intI += 1;
        //            }
        //            intK += 1;
        //        }


        //        if (strPath.Substring(strPath.Length - 1, 1) != "\\")
        //        {
        //            strPath = strPath + "\\";
        //        }

        //        strFilename = strPath + "AttributeTable.xls";

        //        xlApp.ActiveCell.Worksheet.SaveAs(strFilename);

        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

        //        xlApp = null;
        //        MessageBox.Show("Data's are exported to Excel Succesfully in '" + strFilename + "'", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    // The excel is created and opened for insert value. We most close this excel using this system
        //    System.Diagnostics.Process[] pro = (System.Diagnostics.Process[])System.Diagnostics.Process.GetProcessesByName("EXCEL");
        //    foreach (System.Diagnostics.Process i in pro)
        //    {
        //        i.Kill();
        //    }
        //}
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Select function is used to select a shape on the shape file
            Form1.map1_.FunctionMode = FunctionMode.Select;

            if (dgvAttributeTable.SelectedRows.Count > 1)
                return;
                string val, col;
                for (int i = 0; i < dgvAttributeTable.Columns.Count; i++)
                {
                    col = dgvAttributeTable.Columns[i].Name.ToUpper();
                    if (col == "NAME")
                    {
                        val = dgvAttributeTable.SelectedRows[0].Cells[col].Value.ToString();
                        MapPolygonLayer statelayer = (MapPolygonLayer)Form1.map1_.Layers[0];
                        statelayer.SelectByAttribute("[NAME]=" + "'" + val + "'");
                    }

                }
            
           
        }

        private void btnSelectAll_Click(object sender, EventArgs e) 
        {
            dgvAttributeTable.SelectAll();
            MapPolygonLayer statelayer = (MapPolygonLayer)Form1.map1_.Layers[0];
            statelayer.SelectAll();
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            dgvAttributeTable.ClearSelection();
            MapPolygonLayer statelayer = (MapPolygonLayer)Form1.map1_.Layers[0];
            statelayer.ClearSelection();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            //ZoomIn method is used to ZoomIn the shape file
            Form1.map1_.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            //ZoomOut method is used to ZoomIn the shape file
            Form1.map1_.ZoomOut();
        }

        private void btnZoomToExtent_Click(object sender, EventArgs e)
        {
            //ZoomToMaxExtent method is used to Extent the shape file
            Form1.map1_.FunctionMode = FunctionMode.Select;
            MapPolygonLayer statelayer = (MapPolygonLayer)Form1.map1_.Layers[0];
            statelayer.ZoomToSelectedFeatures();
        }
        private void 属性标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

    
}
