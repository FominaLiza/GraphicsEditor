using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    abstract class Brush
    {
        public Color BrushColor { get; set; }
        public int Size { get; set; }
        public Brush(Color BrushColor, int size)
        {
            BrushColor = BrushColor;
            Size = size;
        }  
        public abstract void Draw(Bitmap image, int x, int y);

    }
}
