using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dino_Cheat
{
    public class ImageProcessing
    {
        public static ChromeWrapper wrapper = new ChromeWrapper("chrome://dino");
        public static  System.Drawing.Point DinoPos = new System.Drawing.Point(60, 425);
        public static float DinoCircleRadius = 4;

        public static void Invert(Bitmap image)
        {
            var col = image.GetPixel(100, 200);
            Graphics graphics = Graphics.FromImage(image);
            graphics.FillEllipse(new SolidBrush(Color.Yellow), 100, 200, DinoCircleRadius, DinoCircleRadius);
            if(col.R>50&&col.G>50&&col.B>50)
            {
                Invert filter = new Invert();
                filter.ApplyInPlace(image);
            }
            

        }
        public static void getDinoCordinates(Bitmap image)
        {
            var prevColor = Color.FromArgb(0, 0, 0);
            Graphics graphics = Graphics.FromImage(image);

            for (int i=250;i<430;i++)
            {
                var col=image.GetPixel(60, i);

                graphics.FillEllipse(new SolidBrush(Color.Green), DinoPos.X, i, DinoCircleRadius, DinoCircleRadius);
                if (col==Color.Black)
                {
                    DinoPos=new System.Drawing.Point(60, i);
                    return;
                }
            }
        }

        public static void Draw(Bitmap image)
        {
            Graphics graphics = Graphics.FromImage(image);
            graphics.FillEllipse(new SolidBrush(Color.Green),DinoPos.X,DinoPos.Y,DinoCircleRadius,DinoCircleRadius);
        }
        public static void ObstruclesClose(Bitmap image)
        {


            for(int i=100;i<=200;i++)
            {
                var col = image.GetPixel(i, 460);

                Graphics graphics = Graphics.FromImage(image);
                graphics.FillEllipse(new SolidBrush(Color.Red), i, 430, DinoCircleRadius, DinoCircleRadius);

                if (col.R > 50 && col.G > 50 && col.B > 50)
                {
                    wrapper.SendKey(' ');
                    break;
                }
            }
 
           
 
        }
        public static void ObstruclesDuckable(Bitmap image)
        {


            Graphics graphics = Graphics.FromImage(image);

            for (int i = 100; i <= 160; i++)
            {
                var col = image.GetPixel(i, 395);

                graphics.FillEllipse(new SolidBrush(Color.DodgerBlue), i, 395, DinoCircleRadius, DinoCircleRadius);

                if (col.R > 50 && col.G > 50 && col.B > 50)
                {
                    wrapper.SendArrowDown();
                    break;
                }
            }


        }

    }
}
