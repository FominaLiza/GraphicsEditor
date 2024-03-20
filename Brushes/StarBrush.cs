using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Brushes
{
    class StarBrush : Brush
    {
        public StarBrush(Color brushColor, int size)
            : base(brushColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            using (Graphics gr = Graphics.FromImage(image))
            {

                using (Pen pen = new Pen(BrushColor, Size))
                { 
                      // Количество вершин звезды
                      int vertexCount = 5;
                      // Определяем размеры звезды
                      double rx = Size / 2.0;//Эти линии вычисляют горизонтальный и вертикальный радиусы звезды на основе параметра Size.                     
                      double ry = Size / 2.0;//Размер звезды определяется этими радиусами.

                      double cx = x + rx;//Эти линии вычисляют координаты центра (cx, cy) звезды.
                      double cy = y + ry;//Звезда будет нарисована с центром в этих координатах.

                      // Генерируем точки для звезды
                      PointF[] pts = StarPoints(vertexCount, new Rectangle((int)cx - (int)rx, (int)cy - (int)ry, (int)rx * 2, (int)ry * 2));

                      // Рисуем звезду
                      gr.DrawPolygon(pen, pts);
                    
                }

                // Метод для генерации точек звезды
                PointF[] StarPoints(int num_points, Rectangle bounds)// В качестве параметров метод принимает количество точек и границы звезды
                {
                    PointF[] pts = new PointF[num_points];

                    double rx = bounds.Width / 2;
                    double ry = bounds.Height / 2;
                    double cx = bounds.X + rx;
                    double cy = bounds.Y + ry;

                    double theta = -Math.PI / 2;//Эти строки инициализируют начальный угол (theta) и                   
                    double dtheta = 4 * Math.PI / num_points;//приращение угла (dtheta) для вычисления точек звезды
                    for (int i = 0; i < num_points; i++)
                    {
                        pts[i] = new PointF(
                            (float)(cx + rx * Math.Cos(theta)),
                            (float)(cy + ry * Math.Sin(theta)));
                        theta += dtheta;
                    }

                    return pts;
                }
            
           
            }
        }
    }
}
