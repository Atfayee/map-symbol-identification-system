
namespace GISdemoTest
{
    partial class AttributeTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAttributeTable = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移除属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放至当前要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择所有要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAttributeTable
            // 
            this.dgvAttributeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributeTable.Location = new System.Drawing.Point(0, 28);
            this.dgvAttributeTable.Name = "dgvAttributeTable";
            this.dgvAttributeTable.RowHeadersWidth = 51;
            this.dgvAttributeTable.RowTemplate.Height = 27;
            this.dgvAttributeTable.Size = new System.Drawing.Size(614, 350);
            this.dgvAttributeTable.TabIndex = 0;
            this.dgvAttributeTable.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.选择ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加属性ToolStripMenuItem,
            this.移除属性ToolStripMenuItem,
            this.开始编辑ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 添加属性ToolStripMenuItem
            // 
            this.添加属性ToolStripMenuItem.Name = "添加属性ToolStripMenuItem";
            this.添加属性ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.添加属性ToolStripMenuItem.Text = "添加字段";
            this.添加属性ToolStripMenuItem.Click += new System.EventHandler(this.CreateAColumInAttributeTableToolStripMenuItem_Click);
            // 
            // 移除属性ToolStripMenuItem
            // 
            this.移除属性ToolStripMenuItem.Name = "移除属性ToolStripMenuItem";
            this.移除属性ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.移除属性ToolStripMenuItem.Text = "移除字段";
            this.移除属性ToolStripMenuItem.Click += new System.EventHandler(this.DeleteColumnInAttributeTableToolStripMenuItem_Click);
            // 
            // 开始编辑ToolStripMenuItem
            // 
            this.开始编辑ToolStripMenuItem.Name = "开始编辑ToolStripMenuItem";
            this.开始编辑ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.开始编辑ToolStripMenuItem.Text = "更新字段";
            this.开始编辑ToolStripMenuItem.Click += new System.EventHandler(this.SaveTheColumInShapeFileToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.ExportAttributeTableToExcelToolStripMenuItem_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大要素ToolStripMenuItem,
            this.缩小要素ToolStripMenuItem,
            this.缩放至当前要素ToolStripMenuItem});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 放大要素ToolStripMenuItem
            // 
            this.放大要素ToolStripMenuItem.Name = "放大要素ToolStripMenuItem";
            this.放大要素ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.放大要素ToolStripMenuItem.Text = "放大要素";
            this.放大要素ToolStripMenuItem.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // 缩小要素ToolStripMenuItem
            // 
            this.缩小要素ToolStripMenuItem.Name = "缩小要素ToolStripMenuItem";
            this.缩小要素ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.缩小要素ToolStripMenuItem.Text = "缩小要素";
            this.缩小要素ToolStripMenuItem.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // 缩放至当前要素ToolStripMenuItem
            // 
            this.缩放至当前要素ToolStripMenuItem.Name = "缩放至当前要素ToolStripMenuItem";
            this.缩放至当前要素ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.缩放至当前要素ToolStripMenuItem.Text = "缩放至当前要素";
            this.缩放至当前要素ToolStripMenuItem.Click += new System.EventHandler(this.btnZoomToExtent_Click);
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择所有要素ToolStripMenuItem,
            this.清空选择ToolStripMenuItem});
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.选择ToolStripMenuItem.Text = "选择";
            this.选择ToolStripMenuItem.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // 选择所有要素ToolStripMenuItem
            // 
            this.选择所有要素ToolStripMenuItem.Name = "选择所有要素ToolStripMenuItem";
            this.选择所有要素ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.选择所有要素ToolStripMenuItem.Text = "选择所有要素";
            this.选择所有要素ToolStripMenuItem.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // 清空选择ToolStripMenuItem
            // 
            this.清空选择ToolStripMenuItem.Name = "清空选择ToolStripMenuItem";
            this.清空选择ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.清空选择ToolStripMenuItem.Text = "清空选择";
            this.清空选择ToolStripMenuItem.Click += new System.EventHandler(this.btnUnSelectAll_Click);
            // 
            // AttributeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 378);
            this.Controls.Add(this.dgvAttributeTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AttributeTable";
            this.Text = "属性表";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAttributeTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移除属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩放至当前要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择所有要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空选择ToolStripMenuItem;
    }
}