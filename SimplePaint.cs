using GraphicsEditor.Brushes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    public partial class SimplePaint : Form
    {
        public SimplePaint()
        {
            InitializeComponent();
            CreateBlank(pictureBox1.Width, pictureBox1.Height);
        }
        int _x;//текущая х координата мыши
        int _y;//текушщая у координата мыши
        bool _mouseClicked;//мышь зажата, состояние актуально для рисования

        Color SelectedColor
        {
            get
            {
                return Color.Red;
            }
        }
        int SelectedSize
        {
            get { return trackBrush.Value; }
        }
        Brush _selectedBrush;
        Color DefaultColor
        {
            get { return Color.White; }
        }
        void CreateBlank(int width, int height)
        {
            //сохраняем старую картинку
            var oldImage = pictureBox1.Image;
            //создаем новый Bitmap
            var bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);    
            //производим попиксельное закрашивание
            for(int i =0; i < width; i++)
            {
                for (int j =0; j < height; j++)
                {
                    bmp.SetPixel(i, j, DefaultColor);
                }
            }
            pictureBox1.Image = bmp;
            if(oldImage != null)
            {
                oldImage.Dispose();//освобождаем ресурсы занятые старой картинкой
            }
        }
        private void SimplePaint_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        _selectedBrush = new QuadBrush(SelectedColor, SelectedSize);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseClicked = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)//обработчик события при нажатии кнопки мыши
        {
            if (_selectedBrush == null)
            {
                return;
            }
            _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x,_y);
            pictureBox1.Refresh();
            _mouseClicked = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //отсекаем отрицательные координаты, не даем выйти за границы
            _x= e.X>0 ? e.X : 0;
            _y= e.Y>0 ? e.Y : 0;
            if(_mouseClicked)//если мышь зажата то рисуем
            {
                _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);
                pictureBox1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)//круглая кисть
        {
            _selectedBrush = new CircleBrush(SelectedColor, SelectedSize);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateBlank(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
