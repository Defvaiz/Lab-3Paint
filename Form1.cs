using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateBlank(pictureBox1.Width = 2000, pictureBox1.Height = 1000);
        }
        Color DefaultColor
        {
            get { return Color.White; }
        }
        void CreateBlank(int width, int height)
        {
            //Сохраняем старую картинку
            var oldImage = pictureBox1.Image;
            //Создаем новый битмап
            var bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //Производим попиксельное закрашивание
            //Битмап - обычный двумерный массив точек, поэтому проходим его за 2 цикла
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bmp.SetPixel(i, j, DefaultColor);
                }
            }
            pictureBox1.Image = bmp;
            if (oldImage != null)
            {
                oldImage.Dispose(); //Освобождаем ресурсы занятые старой картинкой
            }

        }

        int _x;                          //Текущая х координата мыши
        int _y;                          //Текущая y координата мыши
        bool _mouseClicked = false;      //Мышь зажата, состояние актуально для рисования кистью

        //Выбранный цвет, пока задан константой, в дальнейшем - палитрой
        Color SelectedColor { get { return colorDialog1.Color; } }

        //Выбранный размер кисти, задается ползунком
        int SelectedSize
        {
            get { return paintBrush.Value; }
        }
        Brush _selectedBrush;   // Выбранная кисть

        private void button1_Click(object sender, EventArgs e)
        {
            _selectedBrush = new QuadBrush(SelectedColor, SelectedSize);
        }


        //Нажатие кнопки мыши
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedBrush == null)
            {
                return;
            }
            _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);
            pictureBox1.Refresh();
            _mouseClicked = true;
        }

        //Отжатие кнопки мыши
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseClicked = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Не даем выйти мыши за границы области, отсекаем отрицательные координаты
            _x = e.X > 0 ? e.X : 0;
            _y = e.Y > 0 ? e.Y : 0;
            if (_mouseClicked)
            {
                _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);
                pictureBox1.Refresh();
            }
        }
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            if (form.Canceled == false)
            {
                CreateBlank(form.W, form.H);
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _selectedBrush = new CircleBrush(SelectedColor, SelectedSize);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _selectedBrush = new CardioidBrush(SelectedColor, SelectedSize);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _selectedBrush = new ThreeLeafBrush(SelectedColor, SelectedSize);
        }

        private void paintBrush_Scroll(object sender, EventArgs e)
        {
            if (_selectedBrush != null)
            {
                _selectedBrush.Size = SelectedSize;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Color defaultColor = Color.White;
            _selectedBrush = new EraserBrush(defaultColor, SelectedSize);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button6.BackColor = colorDialog1.Color;
            }
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

        private void button11_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _selectedBrush.BrushColor = ((Button)sender).BackColor;
        }
    }
}
