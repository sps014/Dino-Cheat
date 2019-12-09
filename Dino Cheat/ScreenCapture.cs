using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dino_Cheat
{
    public static class ScreenCapture
    {
        static Bitmap captureImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb);
        static Rectangle captRect = Screen.AllScreens[0].Bounds;

        static Graphics captureGrapg;
        public static Bitmap CaptureScreen(string pathToSave="cap.jpg")
        {
            captureGrapg = Graphics.FromImage(captureImage);
            captureGrapg.CopyFromScreen(captRect.Left, captRect.Top, 0, 0, captRect.Size);
            return captureImage;
        }
    }
}
