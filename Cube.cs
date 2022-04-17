using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeRun
{
    public class Cube
    {
        public float x;
        public float y;

        public int size;

        public Image cubeImage;

        public Cube(float x, float y, int size)
        {
            cubeImage = new Bitmap("C:\\Users\\Overlay\\Desktop\\cube1.png");
            this.x = x;
            this.y = y;
            this.size = size;
        }
    }
}
