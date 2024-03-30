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
                return colorDialog1.Color;
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
            trackBrush.ValueChanged += new EventHandler(trackBrush_ValueChanged);
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
            
            // Проверяем, что координаты мыши находятся в пределах PictureBox
            _x = Math.Max(0, Math.Min(e.X, pictureBox1.Width - 1));
            _y = Math.Max(0, Math.Min(e.Y, pictureBox1.Height - 1));

            if (_mouseClicked)//если мышь зажата то рисуем
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
            SizeOfForm form = new SizeOfForm();
            form.ShowDialog();
            if (form.Canceled == false)
            {
                CreateBlank(form.W, form.H);
            }

        }

        private void btnSnowBrush_Click(object sender, EventArgs e)
        {
            _selectedBrush = new SnowBrush(SelectedColor, SelectedSize);
        }

        private void btnStarBrush_Click(object sender, EventArgs e)
        {
            _selectedBrush = new StarBrush(SelectedColor, SelectedSize);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void trackBrush_ValueChanged(object sender, EventArgs e)
        {
            // Обновляем размер кисти
            if (_selectedBrush != null)
            {
                _selectedBrush.Size = SelectedSize;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            _selectedBrush = new EraserBrush(SelectedColor, SelectedSize);
        }

        private void Star2_Click(object sender, EventArgs e)
        {
            _selectedBrush = new Star2(SelectedColor, SelectedSize);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            LineDrawer.DrawLine((Bitmap)pictureBox1.Image, Color.Red, 200, 100, 400, 200);
            pictureBox1.Refresh();
            LineDrawer.DrawLine((Bitmap)pictureBox1.Image, Color.Red, 400, 200, 200, 300);
            pictureBox1.Refresh();
            LineDrawer.DrawLine((Bitmap)pictureBox1.Image, Color.Red, 200, 300, 100, 200);
            pictureBox1.Refresh();
            LineDrawer.DrawLine((Bitmap)pictureBox1.Image, Color.Red, 100, 200, 200, 100);
            pictureBox1.Refresh();
        }
    }
}
