using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GISdemoTest
{
    public struct RGB
    {
        public int Red, Green, Blue;
    }
    //public struct HSV
    //{
    //    public int H, S, V;
    //}
    class symboldetect
    {
        string filename = "SymbolLibrary.txt";
        List<string> name = new List<string>();
        List<List<int>> GeoInfo = new List<List<int>>();
        List<List<HSV>> hsv = new List<List<HSV>>();
        private void Readfile()
        {
            StreamReader sw = new StreamReader(filename);
            string line;
            while ((line = sw.ReadLine()) != null)
            {
                if (line == null)
                    break;
                string[] list = line.Split(',');//split
                //read name
                name.Add(list[1]);
                //read Geometry Information
                List<int> gi = new List<int>();
                for (int i = 2; i < 12; i++)
                {
                    gi.Add(int.Parse(list[i]));
                }
                GeoInfo.Add(gi);
                //read HSV
                List<HSV> hsvt = new List<HSV>();
                for (int i = 12; i < list.Length; i++)
                {
                    HSV hsvt2;
                    string[] list2 = list[i].Split('|');
                    hsvt2.H = int.Parse(list2[0]);
                    hsvt2.S = int.Parse(list2[1]);
                    hsvt2.V = int.Parse(list2[2]);
                    hsvt.Add(hsvt2);
                }
                hsv.Add(hsvt);
            }
            
         }
        public List<int> Gss2GI(GeoShapeStatistic gss)
        {
            List<int> GeoIndt = new List<int>();
            GeoIndt.Add(gss.Triangle1); GeoIndt.Add(gss.Triangle2);
            GeoIndt.Add(gss.Rectangle); GeoIndt.Add(gss.Squared); GeoIndt.Add(gss.Rhombus1); GeoIndt.Add(gss.Rhombus2);
            GeoIndt.Add(gss.Pentagon); GeoIndt.Add(gss.Hexagon);
            GeoIndt.Add(gss.Circle); GeoIndt.Add(gss.Fan);
            return GeoIndt;
        }
        private bool Equal(HSV ht1, HSV ht2)
        {
            bool e = false;
            int threshold = 5;
            if (ht1.H> ht2.H- threshold&& ht1.H < ht2.H + threshold &&
                ht1.S > ht2.S - threshold && ht1.S < ht2.S + threshold &&
                ht1.V > ht2.V - threshold && ht1.V < ht2.V + threshold)
            {
                e = true;
            }
            return e;
        }
        private bool ColorCheck(List<HSV> hsvdt, List<HSV> hsvt)
        {
            bool find = false;
            int record = hsvdt.Count;
            for (int i = 0; i < hsvdt.Count; i++)
            {
                HSV ht = hsvdt[i];
                for (int j = 0; j < hsvt.Count; j++)
                {
                    HSV ht2 = hsvt[j];
                    bool e = Equal(ht, ht2);
                    if (e==true)
                    {
                        record--;
                        break;                       
                    }
                }
            }
            if (record==0)
            {
                find = true;
            }
            return find;
        }
        private bool EqualList(List<int> L1, List<int> L2)
        {
            bool e = true;
            if (L1.Count!=L2.Count)
            {
                e = false;
                return e;
            }
            for (int i = 0; i < L1.Count; i++)
            {
                if (L1[i]!= L2[i])
                {
                    e = false;
                    return e;
                    break;
                }
            }
     
            return e;
        }
        public void SymbolDetect(GeoShapeStatistic gss,List<HSV> hsvdt)
        {
            Readfile();
            List<int> GeoIndt= Gss2GI(gss);
            List<int> index = new List<int>();
            int pos = -99;
            string nm;
            for (int i = 0; i < GeoInfo.Count; i++)
            {
                if (EqualList(GeoInfo[i], GeoIndt))
                {
                    index.Add(i);
                }
            }
            if (index.Count!=0)
            {
                for (int i = 0; i < index.Count; i++)
                {
                    int id = index[i];
                    if (ColorCheck(hsvdt, hsv[id]))
                    {
                        pos = id;
                        break;
                    }
                }
            }
            if (pos!=-99)
            {
                nm = name[pos];
            }
            else
            {
                nm = "未能识别该符号";
            }
            IdentificationResult fm = new IdentificationResult(pos,nm);
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.Show();
        }
    }
}
