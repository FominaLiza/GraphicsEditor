using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Brushes
{
    class Star2 : Brush
    {
        public Star2(Color brushColor, int size)
            : base(brushColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            Graphics g = Graphics.FromImage(image);
            double fi = 0;
            float LastX, LastY;
            for (fi = 0; fi <= 2 *Math.PI; fi += 0.05)
            {
                
                double R = Size +  Size * Math.Sin(5 * fi) / 2.0;
                //double R = Size * Math.Sin(2 * fi / 3);
                //double R = Size + Size * fi / 3;
                double y1 = R * Math.Sin(fi);
                double x1 = R * Math.Cos(fi);
                image.SetPixel(x + (int)x1, y + (int)y1, BrushColor);
                LastX = x + (float)x1;
                LastY = y + (float)y1;
                g.DrawLine(new Pen(BrushColor), x + (int)x1, y + (int)y1, LastX, LastY);
            }

            g.Dispose();
        }
    }
}
