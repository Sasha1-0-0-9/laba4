using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4_3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics graph;
        Pen myPen;
        SolidBrush sBrush;
        Point[] arrPoints;
        double angle = 0; //кут повороту
        int x_0;
        int y_0;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void OriginRectangle()
        {
            x_0 = pictureBox1.Width / 2;
            y_0 = pictureBox1.Height / 2;
            arrPoints = new Point[] { new Point(x_0, y_0), new Point(620, y_0), new Point(620, 400), new Point(x_0, 400) };
        }

        private void DrawMovingRectangle()
        {

            Point[] arrPointsToMove = new Point[arrPoints.Length];
            double angleRadian = angle * Math.PI / 180;
            for (int i = 0; i < arrPoints.Length; i++)
            {
                int x = (int)((arrPoints[i].X - x_0) * Math.Cos(angleRadian) - (arrPoints[i].Y - y_0) * Math.Sin(angleRadian) + x_0);
                int y = (int)((arrPoints[i].X - x_0) * Math.Sin(angleRadian) + (arrPoints[i].Y - y_0) * Math.Cos(angleRadian) + y_0);
                arrPointsToMove[i] = new Point(x, y);
            }
            graph.DrawPolygon(myPen, arrPointsToMove);
            graph.FillPolygon(sBrush, arrPointsToMove);
        }

        private void InIt()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            myPen = new Pen(Color.Black, 3);
            sBrush = new SolidBrush(Color.Coral);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            graph.Clear(Color.White);
            angle += 0.9;
            DrawMovingRectangle();
            pictureBox1.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InIt();
            OriginRectangle();
            timer1.Enabled = true;
        }
    }
}
