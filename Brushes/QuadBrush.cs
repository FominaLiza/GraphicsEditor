using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Brushes
{
    class QuadBrush : Brush
    {
        public QuadBrush(Color brushColor, int size)
            : base(brushColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            try
            {
                for (int y0 = y - Size; y0 < y + Size; ++y0)
                {
                    for (int x0 = x - Size; x0 < x + Size; ++x0)
                    {
                        image.SetPixel(x0, y0, BrushColor);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

        }
    }
}
