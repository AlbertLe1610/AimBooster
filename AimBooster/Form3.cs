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

namespace AimBooster
{
    public partial class Form3 : Form
    {
        List<Int32> points = new List<Int32>();
        public Form3(string point)
        {
            InitializeComponent();
            lblTarget.Text = point;
            ReadFile();
            points.Add(Int32.Parse(point));
            SapXep();
            Write();
            if (points.Count >= 1)
            {
                lbl1.Text = points[0].ToString();
                
            }
            else
            {
                lbl1.Text = string.Empty;
            }
            if (points.Count >= 2)
            {
                lbl2.Text = points[1].ToString();

            }
            else
            {
                lbl2.Text = string.Empty;
            }
            if (points.Count >= 3)
            {
                lbl3.Text = points[2].ToString();

            }
            else
            {
                lbl3.Text = string.Empty;
            }
            if (points.Count >= 4)
            {
                lbl4.Text = points[3].ToString();

            }
            else
            {
                lbl4.Text = string.Empty;
            }
            if (points.Count >= 5)
            {
                lbl5.Text = points[4].ToString();

            }
            else
            {
                lbl5.Text = string.Empty;
            }

        }
        private void ReadFile()
        {
            string[] strpoints = File.ReadAllLines("Ranking.txt");
            for (int i = 0; i < strpoints.Length; i++)
                if (Int32.TryParse(strpoints[i], out int re))
                {
                    points.Add(re);
                }


        }
        private void SapXep()
        {
            for (int i = 0; i < points.Count - 1; i++)
                for (int j = i + 1; j < points.Count; j++)
                    if (points[i] < points[j])
                    {
                        int temp = points[i];
                        points[i] = points[j];
                        points[j] = temp;
                    }
        }
        private void Write()
        {
            string content = String.Empty;
            for (int i = 0; i < points.Count; i++)
                content += points[i].ToString() + "\n";
            File.WriteAllText("Ranking.txt", content);
        }
    }

}