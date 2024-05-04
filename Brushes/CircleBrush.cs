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
            try
            {
                // Перебираем все пиксели внутри радиуса
                for (int i = -Size/2; i <= Size/2; i++)// Size/2 - радиус
                {
                    for (int j = -Size / 2; j <= Size / 2; j++)
                    {
                        // Проверяем, находится ли текущий пиксель внутри круга
                        if (i * i + j * j <= (Size / 2) * (Size / 2))
                        {
                            image.SetPixel(x + i, y + j, BrushColor);
                        }
                    }
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                return;       
            }

            //for (double y0 = -Size; y0 <= Size; ++y0)
            //{
            //    double x1 = Math.Sqrt(Size * Size - Math.Pow(y0, 2));

            //    image.SetPixel(x + (int)x1, (int)y0 + (int)y, BrushColor);
            //    image.SetPixel(x - (int)x1, (int)y0 + (int)y, BrushColor);
                
            //}
            //for (double x0 = -Size; x0 <= Size; ++x0)
            //{
            //    double y1 = Math.Sqrt(Size * Size - Math.Pow(x0, 2));
     
            //    if (x >= 0 && x < image.Width && y >= 0 && y < image.Height)
            //    {
            //        image.SetPixel((int)x0 + x, y + (int)y1, BrushColor);
            //        image.SetPixel((int)x0 + x, y - (int)y1, BrushColor);
            //    }
            //}
            
        }
        
    }
}
