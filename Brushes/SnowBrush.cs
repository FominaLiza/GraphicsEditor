using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Brushes
{
    class SnowBrush : Brush
    {
        public SnowBrush(Color brushColor, int size)
            : base(brushColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            
            double a = Math.Sqrt((Size * Size) / 2);
            for (double y0 = -a; y0 <= a; ++y0)// две галочки, сверху и снизу от оси X
            {
                double x1 = Math.Abs(y0);

                image.SetPixel(x + (int)x1, (int)y0 + (int)y, BrushColor);
                image.SetPixel(x - (int)x1, (int)y0 + (int)y, BrushColor);

            }
            for (double x0 = -Size; x0 <= Size; ++x0)// горизонтальная линия
            {
                double y1 = 0;
                
                if (x >= 0 && x < image.Width && y >= 0 && y < image.Height)
                {
                    image.SetPixel((int)x0 + x, y + (int)y1, BrushColor);
                   
                }
            }
            for (int y0 = -Size; y0 <= Size; ++y0)// вертикальная линия
            {
                
                if (x >= 0 && x < image.Width && y + y0 >= 0 && y + y0 < image.Height)
                {
                    image.SetPixel(x, y + y0, BrushColor);
                }
            }
            
           

        }
    }
}
