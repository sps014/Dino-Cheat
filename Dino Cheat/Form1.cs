using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dino_Cheat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap image;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            image=ScreenCapture.CaptureScreen();
            ImageProcessing.Invert(image);
            ImageProcessing.ObstruclesClose(image);
            ImageProcessing.ObstruclesDuckable(image);
           
            pictureBox2.Image=image;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();

        }
    }

}
