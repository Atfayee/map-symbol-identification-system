using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GISdemoTest
{
    public partial class AddSymbol : Form
    {
        List<int> GeoIndt = new List<int>();
        List<HSV> colorList = new List<HSV>();
        public AddSymbol(List<int> GeoInd, List<HSV> colorLis)
        {
            GeoIndt = GeoInd; colorList = colorLis;
            InitializeComponent();
        }

        private void Name_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Name_textBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string symbolName = Name_textBox.Text;
            string data = "";
            string FileName = "SymbolLibrary.txt";
            string[] lines = File.ReadAllLines(FileName);
            int id = lines.Length;
            data += id.ToString() + ','+ symbolName + ',';
            for (int i = 0; i < GeoIndt.Count; i++)
            {
                data += GeoIndt[i].ToString() + ',';
            }
            for (int i = 0; i < colorList.Count-1; i++)
            {
                data += colorList[i].H.ToString()+'|'+ colorList[i].S.ToString() + '|' +colorList[i].V.ToString() + ',';
            }
            data += colorList[colorList.Count - 1].H.ToString() + '|' + colorList[colorList.Count - 1].S.ToString() + '|' + colorList[colorList.Count - 1].V.ToString();
            File.AppendAllText(FileName, "\n");
            File.AppendAllText(FileName, data);

        }
    }
}
