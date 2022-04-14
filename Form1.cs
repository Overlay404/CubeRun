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
        Graphics gr;       //объявляем объект - графику, на которой будем рисовать
        Pen p;             //объявляем объект - карандаш, которым будем рисовать контур
        SolidBrush fon;    //объявляем объект - заливки, для заливки соответственно фона
        SolidBrush fig;    //и внутренности рисуемой фигуры
        Random rnd;

        Point DownPoint;   //точка перемещения
        bool IsDragMode;   //нажата ли кнопка мыши

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            gr = pictureBox1.CreateGraphics();  //инициализируем объект типа графики

            p = new Pen(Color.Lime);           // задали цвет для карандаша 
            fon = new SolidBrush(Color.White); // и для заливки
            fig = new SolidBrush(Color.Black);

            gr.FillRectangle(fig, 0, 0, pictureBox1.Width, pictureBox1.Height);
            label1.Text = "Счёт";
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            
            pictureBox1.Left += 1;
            pictureBox1.Top += 1;
        }

        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
            IsDragMode = true;
            base.OnMouseDown(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            IsDragMode = false;
            base.OnMouseUp(e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragMode)
        {
            Point p = e.Location;
            Point dp = new Point(p.X - DownPoint.X, p.Y - DownPoint.Y);
            Location = new Point(Location.X + dp.X, Location.Y + dp.Y);
        }
        base.OnMouseMove(e);
        }
    }
}
