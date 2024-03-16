using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Brushes
{
    class CircleBrush : Brush
    {
        public CircleBrush(Color brushColor, int size)
            : base(brushColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (double y0 = -Size; y0 <= Size; ++y0)
            {
                double x1 = Math.Sqrt(Size * Size - Math.Pow(y0, 2));

                image.SetPixel(x + (int)x1, (int)y0 + (int)y, BrushColor);
                image.SetPixel(x - (int)x1, (int)y0 + (int)y, BrushColor);
                if (y0 == -Size || y0 == Size)//проверяем если y0 находится сверху или снизу
                {
                    for (double x0 = -x1; x0 <= x1; ++x0)
                    {
                        image.SetPixel(x + (int)x0, (int)y0 + (int)y, BrushColor);
                    }
                
                }
            }
           
        }
    }
}
