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
    public partial class SizeOfForm : Form
    {
        public SizeOfForm()
        {
            InitializeComponent();
        }
        
        public int W 
        {
            get
            {
                string text = txtWidth.Text;
                int value = Convert.ToInt32(text);
                return value;
            }
        }
        public int H
        {
            get
            {
                string text = txtHeight.Text;
                int value = Convert.ToInt32(text);
                return value;
            }
        }
        public string FileName
        {
            get
            {
                string text = txtNameFile.Text;
                return text;
            }
        }
        bool _canceled=false;
        public bool Canceled
        {
            get { return _canceled; }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SizeOfForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Кнопка ОК
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)//Кнопка отмены
        {
            _canceled = true;
            Close();
        }
    }
}
