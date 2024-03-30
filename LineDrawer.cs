using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    static class LineDrawer
    {

        static void SwapPoints(ref int x1, ref int x2, ref int y1, ref int y2)
        {
            int tmp = x1;
            x1 = x2;
            x2 = tmp;

            tmp = y1;
            y1 = y2;
            y2 = tmp;
        }


        public static void DrawLine(Bitmap image, Color color222, int x1, int y1, int x2, int y2)
        {

            if (x1 == x2)
            {
                for (int y=y2; y <= y1; y++)
                {
                    image.SetPixel(x1, y, color222);
                }
                for (int y = y1; y <= y2; y++)
                {
                    image.SetPixel(x1, y, color222);
                }
            }
            else if (y1 == y2)
            {
                for (int x = x2; x <= x1; x++)
                {
                    image.SetPixel(x, y1, color222);
                }
                for (int x = x1; x <= x2; x++)
                {
                    int y = y1;
                    image.SetPixel(x, y, color222);
                }
            }
            else
            {
                if (x1 > x2)
                {
                    SwapPoints(ref x1, ref x2, ref y1, ref y2);
                    for (int x = x1; x <= x2; x++)
                    {
                        int y = ((x - x1) * (y2 - y1)) / (x2 - x1) + y1;
                        image.SetPixel(x, y, color222);
                    }
                }
                else
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        int y = ((x - x1) * (y2 - y1)) / (x2 - x1) + y1;
                        image.SetPixel(x, y, color222);
                    }
                }
                if (y1 > y2)
                {
                    SwapPoints(ref x1, ref x2, ref y1, ref y2);
                    for (int y = y1; y <= y2; y++)
                    {
                        int x = ((x2 - x1) * (y - y1)) / (y2 - y1) + x1;
                        image.SetPixel(x, y, color222);
                    }
                }
                else
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        int x = ((x2 - x1) * (y - y1)) / (y2 - y1) + x1;
                        image.SetPixel(x, y, color222);
                    }
                }


            }


        }
    }
}
