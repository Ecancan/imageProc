using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcAhmetCAN
{
    public partial class Form3 : Form
    {
        Bitmap imageSource, proc;
        public Form3()
        {
            InitializeComponent();
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult image = openFileDialog1.ShowDialog();
            if (image == DialogResult.OK){
                imageSource = new Bitmap(openFileDialog1.FileName);
                imageBox.Image = imageSource;
            }
        }

        private void ortalamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox2.Image = null;
            if (imageBox.Image != null)
            {
                int width = imageSource.Width;
                int height = imageSource.Height;
                proc = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color getColor = imageSource.GetPixel(x, y);
                        double average = (getColor.R + getColor.G + getColor.B)/3;
                        int averageInt = Convert.ToInt32(average);
                        Color grey = Color.FromArgb(averageInt, averageInt, averageInt);
                        proc.SetPixel(x, y, grey);
                    }
                }
                imageBox2.Image = proc;
            }
            else
            {
                MessageBox.Show("Herhangi bir resim açmadınız");
            }
        }

        private void lumaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox2.Image = null;
            if (imageBox.Image != null)
            {
                int width = imageSource.Width;
                int height = imageSource.Height;
                proc = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color getColor = imageSource.GetPixel(x, y);
                        double luma = (getColor.R * 0.3) + (getColor.G * 0.59) + (getColor.B * 0.11);
                        int lumaInt = Convert.ToInt32(luma);
                        Color grey = Color.FromArgb(lumaInt, lumaInt, lumaInt);
                        proc.SetPixel(x, y, grey);
                    }
                }
                imageBox2.Image = proc;
            }
            else
            {
                MessageBox.Show("Herhangi bir resim açmadınız");
            }
        }

        private void açıklıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox2.Image = null;
            if (imageBox.Image != null)
            {
                int width = imageSource.Width;
                int height = imageSource.Height;
                proc = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color getColor = imageSource.GetPixel(x, y);
                        int[] rgbArray = { getColor.R, getColor.G, getColor.B };
                        double desaturation = (rgbArray.Max()+ rgbArray.Min())/2;
                        int desaturationInt = Convert.ToInt32(desaturation);
                        Color grey = Color.FromArgb(desaturationInt, desaturationInt, desaturationInt);
                        proc.SetPixel(x, y, grey);
                    }
                }
                imageBox2.Image = proc;
            }
            else
            {
                MessageBox.Show("Herhangi bir resim açmadınız");
            }
        }

        private void kanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox2.Image = null;
            if (imageBox.Image != null)
            {
                int width = imageSource.Width;
                int height = imageSource.Height;
                proc = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color getColor = imageSource.GetPixel(x, y);
                        double extractChannel = getColor.G;
                        int extractChannelInt = Convert.ToInt32(extractChannel);
                        Color grey = Color.FromArgb(extractChannelInt, extractChannelInt, extractChannelInt);
                        proc.SetPixel(x, y, grey);
                    }
                }
                imageBox2.Image = proc;
            }
            else
            {
                MessageBox.Show("Herhangi bir resim açmadınız");
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG|*.png";
            DialogResult result = saveFileDialog1.ShowDialog();
            ImageFormat format = ImageFormat.Png;

            if (result == DialogResult.OK)
            {
                proc.Save(saveFileDialog1.FileName, format);
            }
        }

        private void bT709ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox2.Image = null;
            if (imageBox.Image != null)
            {
                int width = imageSource.Width;
                int height = imageSource.Height;
                proc = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color getColor = imageSource.GetPixel(x, y);
                        double bt709 = (getColor.R * 0.2125) + (getColor.G * 0.7154) + (getColor.B * 0.072);
                        int bt709Int = Convert.ToInt32(bt709);
                        Color grey = Color.FromArgb(bt709Int, bt709Int, bt709Int);
                        proc.SetPixel(x, y, grey);
                    }
                }
                imageBox2.Image = proc;
            }
            else
            {
                MessageBox.Show("Herhangi bir resim açmadınız");
            }
            
        }
    }
}
