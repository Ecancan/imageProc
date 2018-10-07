using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcAhmetCAN
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Bitmap imageSource;
        private void Form2_Load(object sender, EventArgs e)
        {

        }
       
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult getImage = openFileDialog1.ShowDialog();
            if (getImage == DialogResult.OK){
                imageSource = new Bitmap(openFileDialog1.FileName);
                imageBox.Image = imageSource;
            }
        }

        private void getColor_Click(object sender, EventArgs e)
        {
            if (imageBox.Image != null){
                int xCoor = int.Parse(x.Text);
                int yCoor = int.Parse(y.Text);
                Color getImageColor = imageSource.GetPixel(xCoor, yCoor);
                getColor.BackColor = getImageColor;
            }else{
                MessageBox.Show("Herhangi bir resim açmadınız");
            }
            
        }

        private void renkAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageBox.Image != null){
                int xCoor = int.Parse(x.Text);
                int yCoor = int.Parse(y.Text);
                Color getImageColor = imageSource.GetPixel(xCoor, yCoor);
                getColor.BackColor = getImageColor;
            }else{
                MessageBox.Show("Herhangi bir resim açmadınız");
            }
        }
    }
}
