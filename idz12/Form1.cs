using System;
using System.Drawing;
using System.Windows.Forms;

namespace idz12
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Описываем объект класса OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            // Задаем расширения файлов
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.PNG)| *.bmp; *.jpg; *.gif; *.png)";
            // Вызываем диалог и проверяем выбран ли файл
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Загружаем изображение из выбранного файла
                Image image = Image.FromFile(dialog.FileName);
                int width = image.Width;
                int height = image.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                // Создаем и загружаем изображение в формате bmp
                bmp = new Bitmap(image, width, height);
                // Записываем изображение в pictureBox1
                pictureBox1.Image = bmp;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                if (i % 2 == 0)
                {
                    for (int z = 0; z < bmp.Height; z++)
                    {
                        int color = (255 + bmp.GetPixel(i, z).R + bmp.GetPixel(i, z).G + bmp.GetPixel(i, z).B) / 4;
                        bmp.SetPixel(i, z, Color.FromArgb(color, color, color));
                        pictureBox1.Image = bmp;
                    }
                }

            }

        }
    }
}
