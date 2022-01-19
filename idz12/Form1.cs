using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace idz12
{
    public partial class lab : Form
    {
        private Bitmap bmp;
        Graphics graphics;
        Point point, PreviousPoint;
        private Pen blackPen = new Pen(Color.Black,4);
        string filename;

        public lab()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Описываем объект класса OpenFileDialog

            // Задаем расширения файлов
            openFileDialog1.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.PNG)| *.bmp; *.jpg; *.gif; *.png;";
            // Вызываем диалог и проверяем выбран ли файл
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Загружаем изображение из выбранного файла
                filename = openFileDialog1.FileName;
                Image image = Image.FromFile(openFileDialog1.FileName);
                int width = image.Width;
                int height = image.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                // Создаем и загружаем изображение в формате bmp
                bmp = new Bitmap(image, width, height);
                // Записываем изображение в pictureBox1
                pictureBox1.Image = bmp;
                graphics = Graphics.FromImage(pictureBox1.Image);

            }
        }


        private void save(Bitmap bmp)
        {
            saveFileDialog1.FileName = Path.ChangeExtension(Path.GetFileName(filename), null);
            saveFileDialog1.Filter = "*.BMP | *.bmp |  *.JPG|*.jpg |  *.GIF |*.gif| *.PNG| *.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                string strFilExtn = Path.GetExtension(filename.ToLower());
               
                switch (strFilExtn)
                {
                    case ".bmp":
                        bmp.Save(fileName,
                        System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case ".jpg":
                    case ".jpeg":
                        bmp.Save(fileName,
                         System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".gif":
                        bmp.Save(fileName,
                        System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case ".tif":
                    case ".tiff":
                        bmp.Save(fileName,
                         System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case ".png":
                        bmp.Save(fileName,
                        System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save(bmp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                if (i % 2 == 0)
                {
                    for (int z = 0; z < bmp.Height; z++)
                    {

                        var pixel = bmp.GetPixel(i, z);
                        int color = (255 + pixel.R + pixel.G + pixel.B) / 4;
                        bmp.SetPixel(i, z, Color.FromArgb(color, color, color));
                    }

                }


            }
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                point.X = e.X;
                point.Y = e.Y;
                graphics.DrawLine(blackPen, PreviousPoint, point);
                PreviousPoint.X = point.X;
                PreviousPoint.Y = point.Y;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

   
    }
}
