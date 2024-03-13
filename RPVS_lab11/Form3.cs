using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPVS_lab11
{
    public partial class Form3 : Form
    {
        Bitmap pic;
        Bitmap pic1;
        int x1, y1;
        int xclick1, yclick1;
        string mode;
        public Form3()
        {
            InitializeComponent();
            pic = new Bitmap(1000,1000);
            pic1 = new Bitmap(1000,1000);
            x1 = y1 = 0;
            mode = "Линия";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            button5.BackColor = b.BackColor;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pic.Save(saveFileDialog1.FileName);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mode = "Линия";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mode = "Прямоугольник";       
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mode = "Овал";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            xclick1 = e.X;
            yclick1 = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p = new Pen(button5.BackColor, trackBar1.Value);
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;

            Graphics g = Graphics.FromImage(pic);
            Graphics g1 = Graphics.FromImage(pic1);

            if (e.Button == MouseButtons.Left)
            {
                if (mode == "Линия")
                {
                    g.DrawLine(p, x1, y1, e.X, e.Y);
                }
                if (mode == "Прямоугольник")
                {
                    g1.Clear(Color.Transparent);
                    int x, y;
                    x = xclick1;
                    y = yclick1;    
                    if (x>e.X) x = e.X;
                    if (y>e.Y) y = e.Y;
                    g1.DrawRectangle(p, x, y, Math.Abs(e.X - xclick1), Math.Abs(e.Y - yclick1)); ;
                }
                if (mode == "Овал")
                {
                    g1.Clear(Color.White);
                    g1.DrawEllipse(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1); ;
                }
                g1.DrawImage(pic, 0, 0);
                pictureBox1.Image = pic1;    
            }
            x1 = e.X;
            y1 = e.Y;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(pic);
            Pen p = new Pen(button5.BackColor, trackBar1.Value);
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            if (mode == "Прямоугольник")
            {
                int x, y;
                x = xclick1;
                y = yclick1;
                if (x > e.X) x = e.X;
                if (y > e.Y) y = e.Y;
                g.DrawRectangle(p, x, y, Math.Abs(e.X - xclick1), Math.Abs(e.Y - yclick1)); ;
            }
            if (mode == "Овал")
            {

                g.DrawEllipse(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1); ;
            }
        }
    }
}
