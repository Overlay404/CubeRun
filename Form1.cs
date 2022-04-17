using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CubeRun
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Pen p;
        private float x = 200.0f;
        private float y = 200.0f;
        private int xPos;
        private int yPos;
        Cube cube;
        public Form1()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            cube = new Cube(x, y, 35);

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
        }
        public void update(object sender, EventArgs e)
        {
            if(yPos - cube.y > 0 && yPos - cube.y < 100 && xPos - cube.x < 20 && xPos - cube.x > 0)  //нижняя часть кубика
            {
                cube.y -= 0.1f * 10;
            }
            if (yPos - cube.y < 0 && yPos - cube.y > -100 && xPos - cube.x < 20 && xPos - cube.x > 0)// верхняя часть кубика
            {
                cube.y += 0.1f * 10;
            }
            if(yPos - cube.y < 20 && yPos - cube.y > 0 && xPos - cube.x < 100 && xPos - cube.x > 0)  // правая часть кубика
            {
                cube.x -= 0.1f * 10;
            }
            if (yPos - cube.y < 20 && yPos - cube.y > 0 && xPos - cube.x > -100 && xPos - cube.x < 0)// левая часть кубика
            {
                cube.x += 0.1f * 10;
            }
            else
            {
                cube.x -= 0.0001f;
                cube.y -= 0.00001f;
            }

            label1.Text = Convert.ToString(xPos) + "; " + Convert.ToString(yPos) + "\n" + Convert.ToString((int) cube.x) + "; " + Convert.ToString((int) cube.y);
            this.Invalidate();
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            gr = e.Graphics;
            gr.DrawImage(cube.cubeImage, cube.x, cube.y, cube.size, cube.size);
        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            xPos = e.X;
            yPos = e.Y;
        }
    }
}
