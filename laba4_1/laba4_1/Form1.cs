using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Geometry Figures";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawGeometryFigures();
        }

        public void DrawGeometryFigures()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen myPen = new Pen(Color.Red, 1);
            SolidBrush mySolidBrush = new SolidBrush(Color.Coral);
            pictureBox1.Image = bmp;

            Point[] myPointArray = { new Point(250, 250), new Point(190, 120), new Point(130, 260) };// трикутник
            g.FillPolygon(mySolidBrush, myPointArray);

            int x_0 = 110;
            int y_0 = 110;
            int r = 70; // довжина сторони шестикутника
            Point[] myPointArray1 = new Point[6];
            int x, y;
            for (int i = 0; i < 6; i++)
            {
                x = x_0 + (int)(r * Math.Cos(i * 60 * Math.PI / 180));
                y = y_0 - (int)(r * Math.Sin(i * 60 * Math.PI / 180));
                myPointArray1[i] = new Point(x, y);
            }
            g.FillPolygon(new SolidBrush(Color.HotPink), myPointArray1);

            g.DrawEllipse(myPen, 200, 50, 200, 100); // еліпс
            g.DrawEllipse(myPen, 300, 220, 130, 130); // коло
        }
    }
}
