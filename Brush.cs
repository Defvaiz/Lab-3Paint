using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    abstract class Brush
    {
        public Color BrushColor { get; set; }
        public int Size { get; set; }
        public Brush(Color brushColor, int size)
        {
            BrushColor = brushColor;
            Size = size;
        }
        public abstract void Draw(Bitmap image, int x, int y);
        public void UpdateColor(Color newColor)
        {
            BrushColor = newColor;

        }
    }
    class QuadBrush : Brush
    {
        public QuadBrush(Color brushcolor, int size)
            : base(brushcolor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0 = y - Size; y0 <= y + Size && y0 < image.Height; ++y0)
            {
                if (y0 < 0) continue;
                for (int x0 = x - Size; x0 <= x + Size && x0 < image.Width; ++x0)
                {
                    if (x0 < 0) continue;
                    image.SetPixel(x0, y0, BrushColor);

                }
            }
        }
    }
    class CircleBrush : Brush
    {
        public CircleBrush(Color brushColor, int size)
            : base(brushColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            int radius = Size;
            using (Graphics g = Graphics.FromImage(image))//Используем объект Graphics для рисования
            {
                g.FillEllipse(new SolidBrush(BrushColor), x - radius, y - radius, 2 * radius, 2 * radius); // Используем метод FillEllipse для рисования круга,
                                                                                                           // x-radius y-radius - левый верхний угол прямоугольника,
                                                                                                           // в который вписывается эллипс. 2*radius - определяет ширину и высоту этого прямоугольника,
                                                                                                           // делая его квадратом
            }
        }
    }
    class CardioidBrush : Brush
    {
        public CardioidBrush(Color brushColor, int size)
            : base (brushColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                double theta = 0;
                double thetaIncrement = 0.01;
                while (theta < 2 * Math.PI)
                {
                    double r = Size * (1 + Math.Cos(theta));
                    double cartX = x + r * Math.Cos(theta);
                    double cartY = y + r * Math.Sin(theta);
                    if (cartX >= 0 && cartX < image.Width && cartY >= 0 && cartY < image.Height)
                    {
                        image.SetPixel((int)cartX, (int)cartY, BrushColor);
                    }
                    theta += thetaIncrement;
                }
            }
        }
    }
    class ThreeLeafBrush : Brush
    {
        public ThreeLeafBrush(Color brushColor, int size)
            : base (brushColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                double theta = 0;
                double thetaIncrement = 0.01;
                while (theta < 2 * Math.PI)
                {
                    double r = Size * Math.Sin(3 * theta);
                    double cartX = x + r * Math.Cos(theta);
                    double cartY = y + r * Math.Sin(theta);
                    if (cartX >= 0 && cartX < image.Width && cartY >= 0 && cartY < image.Height)
                    {
                        image.SetPixel((int)cartX, (int)cartY, BrushColor);
                    }
                    theta += thetaIncrement;
                }
            }
        }
    }
    class EraserBrush : Brush
    {
        public EraserBrush(Color defaultColor, int size)
            : base(defaultColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            int radius = Size;
            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillEllipse(new SolidBrush(BrushColor), x - radius, y - radius, 2 * radius, 2 * radius); 
                                                                                                           
                                                                                                           
                                                                                                           
            }
        }
    }
}
