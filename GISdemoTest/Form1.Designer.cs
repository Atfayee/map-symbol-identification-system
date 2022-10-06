
namespace GISdemoTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.spatialToolStrip1 = new DotSpatial.Controls.SpatialToolStrip();
            this.map1 = new DotSpatial.Controls.Map();
            this.legend1 = new DotSpatial.Controls.Legend();
            this.spatialStatusStrip1 = new DotSpatial.Controls.SpatialStatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择所有元素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消选择所有元素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.缩小图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放至所有元素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.测量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矢量化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.符号识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直接识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.截图识别ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.形状颜色识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spatialToolStrip1
            // 
            this.spatialToolStrip1.ApplicationManager = null;
            this.spatialToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.spatialToolStrip1.Location = new System.Drawing.Point(0, 28);
            this.spatialToolStrip1.Map = this.map1;
            this.spatialToolStrip1.Name = "spatialToolStrip1";
            this.spatialToolStrip1.Size = new System.Drawing.Size(1241, 27);
            this.spatialToolStrip1.TabIndex = 0;
            this.spatialToolStrip1.Text = "spatialToolStrip1";
            // 
            // map1
            // 
            this.map1.AllowDrop = true;
            this.map1.AutoSize = true;
            this.map1.BackColor = System.Drawing.Color.White;
            this.map1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.map1.CollectAfterDraw = false;
            this.map1.CollisionDetection = false;
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.ExtendBuffer = false;
            this.map1.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            this.map1.IsBusy = false;
            this.map1.IsZoomedToMaxExtent = false;
            this.map1.Legend = this.legend1;
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.map1.Name = "map1";
            this.map1.ProgressHandler = this.spatialStatusStrip1;
            this.map1.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.RedrawLayersWhileResizing = false;
            this.map1.SelectionEnabled = true;
            this.map1.Size = new System.Drawing.Size(1012, 571);
            this.map1.TabIndex = 7;
            // 
            // legend1
            // 
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.ControlRectangle = new System.Drawing.Rectangle(0, 0, 211, 560);
            this.legend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legend1.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.legend1.HorizontalScrollEnabled = true;
            this.legend1.Indentation = 30;
            this.legend1.IsInitialized = false;
            this.legend1.Location = new System.Drawing.Point(3, 2);
            this.legend1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.legend1.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend1.Name = "legend1";
            this.legend1.ProgressHandler = null;
            this.legend1.ResetOnResize = false;
            this.legend1.SelectionFontColor = System.Drawing.Color.Black;
            this.legend1.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend1.Size = new System.Drawing.Size(211, 560);
            this.legend1.TabIndex = 0;
            this.legend1.Text = "legend1";
            this.legend1.VerticalScrollEnabled = true;
            // 
            // spatialStatusStrip1
            // 
            this.spatialStatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.spatialStatusStrip1.Location = new System.Drawing.Point(0, 571);
            this.spatialStatusStrip1.Name = "spatialStatusStrip1";
            this.spatialStatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.spatialStatusStrip1.ProgressBar = null;
            this.spatialStatusStrip1.ProgressLabel = null;
            this.spatialStatusStrip1.Size = new System.Drawing.Size(1012, 22);
            this.spatialStatusStrip1.TabIndex = 5;
            this.spatialStatusStrip1.Text = "spatialStatusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.开始ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.选择ToolStripMenuItem,
            this.预处理ToolStripMenuItem,
            this.矢量化ToolStripMenuItem,
            this.符号识别ToolStripMenuItem,
            this.数据入库ToolStripMenuItem,
            this.帮助ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1241, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem1,
            this.新建ToolStripMenuItem,
            this.toolStripSeparator1,
            this.保存ToolStripMenuItem,
            this.toolStripSeparator2,
            this.打印ToolStripMenuItem,
            this.toolStripSeparator4,
            this.退出ToolStripMenuItem});
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.打开ToolStripMenuItem.Text = "文件";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem1
            // 
            this.打开ToolStripMenuItem1.Name = "打开ToolStripMenuItem1";
            this.打开ToolStripMenuItem1.Size = new System.Drawing.Size(122, 26);
            this.打开ToolStripMenuItem1.Text = "打开";
            this.打开ToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.新建ToolStripMenuItem.Text = "移除";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.ClearMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.打印ToolStripMenuItem.Text = "打印";
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.PrintMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(119, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.closeFormToolStripMenuItem_Click);
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择所有元素ToolStripMenuItem,
            this.取消选择所有元素ToolStripMenuItem,
            this.toolStripSeparator8,
            this.缩小图层ToolStripMenuItem,
            this.放大ToolStripMenuItem,
            this.缩放至所有元素ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.开始ToolStripMenuItem.Text = "编辑";
            // 
            // 选择所有元素ToolStripMenuItem
            // 
            this.选择所有元素ToolStripMenuItem.Name = "选择所有元素ToolStripMenuItem";
            this.选择所有元素ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.选择所有元素ToolStripMenuItem.Text = "选择所有元素";
            this.选择所有元素ToolStripMenuItem.Click += new System.EventHandler(this.selectAll_ToolStripMenuItem_Click);
            // 
            // 取消选择所有元素ToolStripMenuItem
            // 
            this.取消选择所有元素ToolStripMenuItem.Name = "取消选择所有元素ToolStripMenuItem";
            this.取消选择所有元素ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.取消选择所有元素ToolStripMenuItem.Text = "取消选择所有元素";
            this.取消选择所有元素ToolStripMenuItem.Click += new System.EventHandler(this.UnselectAll_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(221, 6);
            // 
            // 缩小图层ToolStripMenuItem
            // 
            this.缩小图层ToolStripMenuItem.Name = "缩小图层ToolStripMenuItem";
            this.缩小图层ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.缩小图层ToolStripMenuItem.Text = "缩小元素";
            this.缩小图层ToolStripMenuItem.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.放大ToolStripMenuItem.Text = "放大元素";
            this.放大ToolStripMenuItem.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // 缩放至所有元素ToolStripMenuItem
            // 
            this.缩放至所有元素ToolStripMenuItem.Name = "缩放至所有元素ToolStripMenuItem";
            this.缩放至所有元素ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.缩放至所有元素ToolStripMenuItem.Text = "缩放至所有元素";
            this.缩放至所有元素ToolStripMenuItem.Click += new System.EventHandler(this.btnZoomToExtent_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性表ToolStripMenuItem});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 属性表ToolStripMenuItem
            // 
            this.属性表ToolStripMenuItem.Name = "属性表ToolStripMenuItem";
            this.属性表ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.属性表ToolStripMenuItem.Text = "属性表";
            this.属性表ToolStripMenuItem.Click += new System.EventHandler(this.btnAttributeTable_Click);
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.默认ToolStripMenuItem,
            this.选择要素ToolStripMenuItem,
            this.取消选择ToolStripMenuItem,
            this.移动ToolStripMenuItem,
            this.toolStripSeparator7,
            this.测量ToolStripMenuItem,
            this.查看信息ToolStripMenuItem});
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.选择ToolStripMenuItem.Text = "选择";
            // 
            // 默认ToolStripMenuItem
            // 
            this.默认ToolStripMenuItem.Name = "默认ToolStripMenuItem";
            this.默认ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.默认ToolStripMenuItem.Text = "默认";
            this.默认ToolStripMenuItem.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // 选择要素ToolStripMenuItem
            // 
            this.选择要素ToolStripMenuItem.Name = "选择要素ToolStripMenuItem";
            this.选择要素ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.选择要素ToolStripMenuItem.Text = "选择";
            this.选择要素ToolStripMenuItem.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // 取消选择ToolStripMenuItem
            // 
            this.取消选择ToolStripMenuItem.Name = "取消选择ToolStripMenuItem";
            this.取消选择ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.取消选择ToolStripMenuItem.Text = "取消选择";
            this.取消选择ToolStripMenuItem.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // 移动ToolStripMenuItem
            // 
            this.移动ToolStripMenuItem.Name = "移动ToolStripMenuItem";
            this.移动ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.移动ToolStripMenuItem.Text = "移动";
            this.移动ToolStripMenuItem.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(221, 6);
            // 
            // 测量ToolStripMenuItem
            // 
            this.测量ToolStripMenuItem.Name = "测量ToolStripMenuItem";
            this.测量ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.测量ToolStripMenuItem.Text = "测量";
            this.测量ToolStripMenuItem.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // 查看信息ToolStripMenuItem
            // 
            this.查看信息ToolStripMenuItem.Name = "查看信息ToolStripMenuItem";
            this.查看信息ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.查看信息ToolStripMenuItem.Text = "查看信息";
            this.查看信息ToolStripMenuItem.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // 预处理ToolStripMenuItem
            // 
            this.预处理ToolStripMenuItem.Name = "预处理ToolStripMenuItem";
            this.预处理ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.预处理ToolStripMenuItem.Text = "预处理";
            // 
            // 矢量化ToolStripMenuItem
            // 
            this.矢量化ToolStripMenuItem.Name = "矢量化ToolStripMenuItem";
            this.矢量化ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.矢量化ToolStripMenuItem.Text = "矢量化";
            this.矢量化ToolStripMenuItem.Click += new System.EventHandler(this.矢量化ToolStripMenuItem_Click);
            // 
            // 符号识别ToolStripMenuItem
            // 
            this.符号识别ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.直接识别ToolStripMenuItem,
            this.截图识别ToolStripMenuItem1,
            this.形状颜色识别ToolStripMenuItem});
            this.符号识别ToolStripMenuItem.Name = "符号识别ToolStripMenuItem";
            this.符号识别ToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.符号识别ToolStripMenuItem.Text = "地图符号识别";
            // 
            // 直接识别ToolStripMenuItem
            // 
            this.直接识别ToolStripMenuItem.Name = "直接识别ToolStripMenuItem";
            this.直接识别ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.直接识别ToolStripMenuItem.Text = "直接识别";
            this.直接识别ToolStripMenuItem.Click += new System.EventHandler(this.Result_Click);
            // 
            // 截图识别ToolStripMenuItem1
            // 
            this.截图识别ToolStripMenuItem1.Name = "截图识别ToolStripMenuItem1";
            this.截图识别ToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.截图识别ToolStripMenuItem1.Text = "截图识别";
            this.截图识别ToolStripMenuItem1.Click += new System.EventHandler(this.Capture_Click);
            // 
            // 形状颜色识别ToolStripMenuItem
            // 
            this.形状颜色识别ToolStripMenuItem.Name = "形状颜色识别ToolStripMenuItem";
            this.形状颜色识别ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.形状颜色识别ToolStripMenuItem.Text = "形状颜色识别";
            this.形状颜色识别ToolStripMenuItem.Click += new System.EventHandler(this.形状颜色识别ToolStripMenuItem_Click);
            // 
            // 数据入库ToolStripMenuItem
            // 
            this.数据入库ToolStripMenuItem.Name = "数据入库ToolStripMenuItem";
            this.数据入库ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.数据入库ToolStripMenuItem.Text = "数据入库";
            this.数据入库ToolStripMenuItem.Click += new System.EventHandler(this.数据入库ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(53, 24);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            this.帮助ToolStripMenuItem1.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 55);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1241, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.Result_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 82);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.map1);
            this.splitContainer1.Panel2.Controls.Add(this.spatialStatusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1241, 593);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(225, 593);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.legend1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(217, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "图层";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 675);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.spatialToolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "地图符号识别";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DotSpatial.Controls.SpatialToolStrip spatialToolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DotSpatial.Controls.SpatialStatusStrip spatialStatusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择所有元素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消选择所有元素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩放至所有元素ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DotSpatial.Controls.Legend legend1;
        private System.Windows.Forms.ToolStripMenuItem 属性表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 默认ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem 测量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem 取消选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 矢量化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 符号识别ToolStripMenuItem;
        public DotSpatial.Controls.Map map1;
        private System.Windows.Forms.ToolStripMenuItem 直接识别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 截图识别ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem 形状颜色识别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据入库ToolStripMenuItem;
    }
}

