using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4_4
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics graph;
        Pen myPen;
        SolidBrush sBrush;
        int y_0 = 200;
        int x_0 = 1000; // точка початку човна
        int x_1 = 0;   // для хвиль
        double alpha = 0;
        double angle = 0; // для гвинта
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InIt()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            myPen = new Pen(Color.Black, 3);
            sBrush = new SolidBrush(Color.DarkGray);
            pictureBox1.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InIt();
            Draw();
            timer1.Enabled = true;
        }

        private void Draw()
        {
            for (int j = x_1 + pictureBox1.Width; j > -50; j -= 40)
            {
                graph.FillEllipse(new SolidBrush(Color.White), j, 150, 50, 50);
            }

            // перископ
            Point[] arrPoint3 = { new Point(x_0 + 120, y_0), new Point(x_0 + 145, y_0), new Point(x_0 + 145, y_0 + 60), new Point(x_0 + 135, y_0 + 60), new Point(x_0 + 135, y_0 + 15), new Point(x_0 + 120, y_0 + 15) };
            graph.DrawPolygon(myPen, arrPoint3);
            graph.FillPolygon(new SolidBrush(Color.DarkGray), arrPoint3);

            Point[] arrPoint2 = { new Point(x_0 + 95, 220), new Point(x_0 + 105, 190), new Point(x_0 + 165, 190), new Point(x_0 + 175, 220) };
            graph.DrawPolygon(myPen, arrPoint2);
            graph.FillPolygon(sBrush, arrPoint2);

            // хвилі
            for (int j = x_1 + pictureBox1.Width; j > -50; j -= 40)
            {
                graph.DrawArc(new Pen(Color.Aqua, 3), j, 150, 50, 50, 35, 110);
            }

            Point[] arrPoints1 = { new Point(x_0 + 45, 260), new Point(x_0 + 65, 220), new Point(x_0 + 205, 220), new Point(x_0 + 225, 260) };
            graph.DrawPolygon(myPen, arrPoints1);
            graph.FillPolygon(sBrush, arrPoints1);

            for (int i = x_0 + 65; i < x_0 + 195; i += 40)
            {
                graph.DrawEllipse(myPen, i, 235, 15, 15);
            }
            // головна частина човна
            Point[] arrPoints = { new Point(x_0, 260), new Point(x_0 + 295, 260), new Point(x_0 + 350, 277), new Point(x_0 + 365, 215), new Point(x_0 + 385, 215), new Point(x_0 + 385, 289), new Point(x_0 + 415, 300), new Point(x_0 + 385, 312), new Point(x_0 + 385, 370), new Point(x_0 + 370, 370), new Point(x_0 + 350, 324), new Point(x_0 + 295, 341), new Point(x_0, 341) };
            graph.DrawPolygon(myPen, arrPoints);
            graph.FillPolygon(sBrush, arrPoints);
            graph.DrawArc(myPen, x_0 - 35, 259, 82, 82, 100, 160);
            graph.FillEllipse(sBrush, x_0 - 35, 260, 80, 80);
            graph.DrawLine(myPen, x_0 - 35, 300, x_0 + 310, 300);
            graph.DrawLine(myPen, x_0 + 310, 300, x_0 + 350, 277);

            for (int i = x_0; i < x_0 + 295; i += 48)
            {
                graph.DrawEllipse(myPen, i, 266, 23, 23);
            }
            // гвинт

            int y1 = 190;
            Point[] end = { new Point(x_0 + 415, y1 + 90), new Point(x_0 + 422, y1 + 90), new Point(x_0 + 415, y1 + 110), new Point(x_0 + 422, y1 + 130), new Point(x_0 + 415, y1 + 130) };

            Point[] arrPointsToMove = new Point[end.Length];
            for (int i = 0; i < end.Length; i++)
            {
                int x = end[i].X;
                int y = (int)((end[i].Y - 300) * Math.Cos(angle) + (end[i].Y - 300) * Math.Sin(angle) + 300);
                arrPointsToMove[i] = new Point(x, y);
            }
            graph.DrawPolygon(myPen, arrPointsToMove);
            graph.FillPolygon(new SolidBrush(Color.Black), arrPointsToMove);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width + 100, 190);
            graph.FillRectangle(new SolidBrush(Color.LightBlue), -10, 189, pictureBox1.Width + 100, pictureBox1.Height);
            x_0 -= 7;
            x_1 += 5;
            if (x_0 < -415)
            {
                x_0 = 1370;
            }
            y_0 = (int)(190 - 60 * Math.Sin(alpha));
            if (y_0 > 190)
            {
                y_0 = (int)(200 + 70 * Math.Sin(alpha));
            }
            angle -= 0.1;
            alpha += 0.03;
            Draw();
            pictureBox1.Image = bmp;
        }
    }
}
