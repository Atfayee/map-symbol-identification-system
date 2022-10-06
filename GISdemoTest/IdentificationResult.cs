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

namespace GISdemoTest
{
    public partial class IdentificationResult : Form
    {
        public IdentificationResult(int id,string name)
        {
            InitializeComponent();

            // 识别符号路径
            // 赋值结果路径
            // string symbolPath = filepath;
            // 以多金属矿为例
            string str = AppDomain.CurrentDomain.BaseDirectory;
            string str2 = id.ToString();
            string str3 = "image";
            string str4 = "\\";
            string symbolPath = str+str3+ str4+str2 + ".png";

            // 识别符号名称
            string symbolName = Path.GetFileNameWithoutExtension(symbolPath);

            // 结果显示
            labelResult.Text = name;
            this.pictureBox1.Load(symbolPath);
        }
    }
}
