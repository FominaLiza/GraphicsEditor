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
        public override void Draw(Bitmap image, int x0, int y0)
        {
            double fi = 0;
            //int lastY = (Size * 1) + y0;
           // int lastX = (Size * 0) + x0;


            int lastY =  y0;
            int lastX = Size + x0;
            //? чему равны эти координаты до начала рассчетов
            for (fi = 0; fi < 2 *Math.PI; fi += 0.015)
            {                
                double R = Size +  Size * Math.Sin(5 * fi) / 2.0;
                int y = (int)( R * Math.Sin(fi)) + y0;
                int x = (int) (R * Math.Cos(fi)) + x0;
               // image.SetPixel(x, y, BrushColor);
                LineDrawer.DrawLine(image, BrushColor, lastX, lastY, x, y);
                lastX = x;
                lastY = y;
            }

            int y2 = y0;
            int x2 = Size + x0;
            LineDrawer.DrawLine(image, BrushColor, lastX, lastY, x2, y2);

        }
    }
}
