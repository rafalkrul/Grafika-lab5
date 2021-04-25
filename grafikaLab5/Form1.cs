using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace grafikaLab5
{


    public partial class Form1 : Form
    {
        
        Image guy1;
        Image aurora; 
        Bitmap bitmanpguy;
        Bitmap bitmapAurora;
        
        int guyWidth, guyHight, auroraWidth, auroraHeight;
     
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guy1 = pictureBox1.Image;
            aurora = pictureBox3.Image;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            aurora = resizeImage(aurora, new Size(pictureBox3.Size.Width, pictureBox3.Size.Height));
            guy1 = resizeImage(guy1, new Size(pictureBox1.Size.Width, pictureBox1.Size.Height));
            bitmanpguy = new Bitmap(guy1);
            bitmapAurora = new Bitmap(aurora);
            guyWidth = bitmanpguy.Width;
            guyHight = bitmanpguy.Height;
            auroraWidth = bitmapAurora.Width;
            auroraHeight = bitmapAurora.Height;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color p = bitmanpguy.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox2.Image = bitmanpguy;
        }
        
        public int checkIfInRGB(int value)
        {
            if (value >= 255) return 254;
            if (value <= 0) return 1;
            else return value;
        }

        private void blend1_Click(object sender, EventArgs e)
        {
           
            for(int y=0; y < guyHight; y++)
            {
                for(int x=0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = checkIfInRGB(guyPixel.A + auroraPixel.A) ;
                    int r = checkIfInRGB(guyPixel.R + auroraPixel.R);
                    int g = checkIfInRGB(guyPixel.G + auroraPixel.G);
                    int b = checkIfInRGB(guyPixel.B + auroraPixel.B);
                   

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    
                }
            }
            pictureBox2.Image = bitmanpguy;
        }
      

        private void blend2_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = checkIfInRGB(guyPixel.A + auroraPixel.A - 255);
                    int r = checkIfInRGB(guyPixel.R + auroraPixel.R - 255);
                    int g = checkIfInRGB(guyPixel.G + auroraPixel.G - 255);
                    int b = checkIfInRGB(guyPixel.B + auroraPixel.B - 255);

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = dostosujJasnosc(bitmanpguy, trackBar1.Value);
        }

        private void blend3_Click(object sender, EventArgs e)
        {
           for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = guyPixel.A;
                    int r = checkIfInRGB(Math.Abs(guyPixel.R - auroraPixel.R));
                    int g = checkIfInRGB(Math.Abs(guyPixel.G - auroraPixel.G)) ;
                    int b = checkIfInRGB(Math.Abs(guyPixel.B - auroraPixel.B));

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
            
        }

        private void blend4_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = 255;
                    int r = checkIfInRGB(guyPixel.R * auroraPixel.R);
                    int g = checkIfInRGB(guyPixel.G * auroraPixel.G);
                    int b = checkIfInRGB(guyPixel.B * auroraPixel.B);

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void blend5_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color  guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    double a = checkIfInRGB(255- checkIfInRGB((255- guyPixel.A))* checkIfInRGB(255-auroraPixel.B));
                    double r = checkIfInRGB(255- checkIfInRGB((255 -  guyPixel.R)) * checkIfInRGB(255 - auroraPixel.R));
                    double g = checkIfInRGB(255 - checkIfInRGB((255 -  guyPixel.G)) * checkIfInRGB(255 - auroraPixel.G));
                    double b = checkIfInRGB(255 - checkIfInRGB((255 -  guyPixel.B) )* checkIfInRGB(255 - auroraPixel.B));
                    bitmanpguy.SetPixel(x, y, Color.FromArgb((int)a, (int)r, (int)g, (int)b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void blend6_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = 255;
                    int r =  checkIfInRGB(255 - checkIfInRGB(Math.Abs(255 - guyPixel.R - auroraPixel.R)));
                    int g =  checkIfInRGB(255 - checkIfInRGB(Math.Abs(255 - guyPixel.G - auroraPixel.G)));
                    int b =  checkIfInRGB(255 - checkIfInRGB(Math.Abs(255 - guyPixel.B - auroraPixel.B)));

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void blend7_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a=255, r, g, b;                 

                    if (guyPixel.R < auroraPixel.R)
                        r = auroraPixel.R;
                    else
                        r = auroraPixel.R;

                    if (guyPixel.G < auroraPixel.G)
                        g = guyPixel.G;
                    else
                        g = auroraPixel.G;

                    if (guyPixel.B < auroraPixel.B)
                        b = guyPixel.B;
                    else
                        b = auroraPixel.B;


                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void blend8_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a, r, g, b;
                    if (guyPixel.A > auroraPixel.A)
                        a = guyPixel.A;
                    else
                        a = auroraPixel.A;

                    if (guyPixel.R > auroraPixel.R)
                        r = auroraPixel.R;
                    else
                        r = auroraPixel.R;

                    if (guyPixel.G > auroraPixel.G)
                        g = guyPixel.G;
                    else
                        g = auroraPixel.G;

                    if (guyPixel.B > auroraPixel.B)
                        b = guyPixel.B;
                    else
                        b = auroraPixel.B;


                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void blend9_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = 255;
                    int r = checkIfInRGB(guyPixel.R + auroraPixel.R - checkIfInRGB(510 * guyPixel.R * auroraPixel.R));
                    int g = checkIfInRGB(guyPixel.G + auroraPixel.G - checkIfInRGB(510 * guyPixel.G * auroraPixel.G));
                    int b = checkIfInRGB(guyPixel.B + auroraPixel.B - checkIfInRGB(510 * guyPixel.B * auroraPixel.B));

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            pictureBox2.Image = bitmanpguy;
            }
        }

        private void blend10_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a=255, r, g, b;
                   
                    if (guyPixel.R < 255 * 0.5)
                        r = checkIfInRGB(2 * guyPixel.R * auroraPixel.R);
                    else
                        r = checkIfInRGB(1 - 2 * (1 - guyPixel.R) * (1 - auroraPixel.R));

                    if (guyPixel.G < 255 * 0.5)
                        g = checkIfInRGB(2 * guyPixel.G * auroraPixel.G);
                    else
                        g = checkIfInRGB(1 - 2 * (1 - guyPixel.G) * (1 - auroraPixel.G));

                    if (guyPixel.B < 255 * 0.5)
                        b = checkIfInRGB(2 * guyPixel.B * auroraPixel.B);
                    else
                        b = checkIfInRGB(1 - 2 * (1 - guyPixel.B) * (1 - auroraPixel.B));


                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void blend11_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a=255, r, g, b;
                   
                    if (auroraPixel.R < 255 * 0.5)
                        r = checkIfInRGB(510 * guyPixel.R * auroraPixel.R);
                    else
                        r = checkIfInRGB(255 - 510 * (255 - guyPixel.R) * (255- auroraPixel.R));

                    if (auroraPixel.G < 255 * 0.5)
                        g = checkIfInRGB(510 * guyPixel.G * auroraPixel.G);
                    else
                        g = checkIfInRGB(255 - 510 * (255 - guyPixel.G) * (255- auroraPixel.G));

                    if (auroraPixel.B < 255 * 0.5)
                        b = checkIfInRGB(510 * guyPixel.B * auroraPixel.B);
                    else
                        b = checkIfInRGB(255 - 510 * (255 - guyPixel.B) * (510 - auroraPixel.B));


                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bitmanpguy = new Bitmap(guy1);
            pictureBox2.Image = bitmanpguy;

        }

        private void blend12_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    double a=255, r, g, b;
                 
                    if (auroraPixel.R /255 <  0.5)
                        r = checkIfInRGB(((int)(2 * guyPixel.R/255 * auroraPixel.R/255 + Math.Pow(guyPixel.R/255, 2) * (1 - 2 * auroraPixel.R/255))) * 255);
                    else
                        r = checkIfInRGB(((int)(Math.Sqrt(guyPixel.R/255) * (2 * auroraPixel.R/255 - 1) + (2 * guyPixel.R/255) * (1 - auroraPixel.R/255))) * 255);

                    if (auroraPixel.G /255< 0.5)
                        g = checkIfInRGB(((int)(2 * guyPixel.G/255 * auroraPixel.G/255 + Math.Pow(guyPixel.G/255, 2) * (1 - 2 * auroraPixel.G/255))) * 255);
                    else
                        g = checkIfInRGB(((int)(Math.Sqrt(guyPixel.G/255) * (2 * auroraPixel.G/255 - 1) + (2 * guyPixel.G/255) * (1 - auroraPixel.G/255))) * 255);

                    if (auroraPixel.B/255 <  0.5)
                        b = checkIfInRGB(((int)(2 * guyPixel.B/255 * auroraPixel.B/255 + Math.Pow(guyPixel.B/255, 2) * (1 - 2 * auroraPixel.B/255))) * 255);
                    else
                        b = checkIfInRGB(((int)(Math.Sqrt(guyPixel.B/255) * (2 * auroraPixel.B/255 - 1) + (2 * guyPixel.B/255) * (1 - auroraPixel.B/255))) * 255);


                    bitmanpguy.SetPixel(x, y, Color.FromArgb((int)a, (int)r, (int)g, (int)b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void blend13_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                  
                    int a = checkIfInRGB(guyPixel.A / checkIfInRGB((255-auroraPixel.A)));
                    int r = checkIfInRGB(guyPixel.R / checkIfInRGB((255 - auroraPixel.R)));
                    int g = checkIfInRGB(guyPixel.G / checkIfInRGB((255 - auroraPixel.G)));
                    int b = checkIfInRGB(guyPixel.B / checkIfInRGB((255 - auroraPixel.B)));

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void blend15_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);

                    int a = checkIfInRGB((int)(Math.Pow(guyPixel.A, 2) / checkIfInRGB(255 - auroraPixel.A)));
                    int r = checkIfInRGB((int)(Math.Pow(guyPixel.R, 2) / checkIfInRGB(255 - auroraPixel.R)));
                    int g = checkIfInRGB((int)(Math.Pow(guyPixel.G, 2) / checkIfInRGB(255 - auroraPixel.G)));
                    int b = checkIfInRGB((int)(Math.Pow(guyPixel.B, 2) / checkIfInRGB(255 - auroraPixel.B)));

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void bledn16_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = checkIfInRGB((trackBar2.Value * ((auroraPixel.A + 64) - guyPixel.A)) / 256 + guyPixel.A - (trackBar2.Value / 4));
                    int r = checkIfInRGB((trackBar2.Value * ((auroraPixel.R + 64) - guyPixel.R)) / 256 + guyPixel.R - (trackBar2.Value / 4));
                    int g = checkIfInRGB((trackBar2.Value * ((auroraPixel.G + 64) - guyPixel.G)) / 256 + guyPixel.G - (trackBar2.Value / 4));
                    int b = checkIfInRGB((trackBar2.Value * ((auroraPixel.B + 64) - guyPixel.B)) / 256 + guyPixel.B - (trackBar2.Value / 4));


                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void blend14_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < guyHight; y++)
            {
                for (int x = 0; x < guyWidth; x++)
                {
                    Color guyPixel = bitmanpguy.GetPixel(x, y);
                    Color auroraPixel = bitmapAurora.GetPixel(x, y);
                    int a = checkIfInRGB(255 - (255 - guyPixel.A) / checkIfInRGB(auroraPixel.A));
                    int r = checkIfInRGB(255 - (255 - guyPixel.R) / checkIfInRGB(auroraPixel.R));
                    int g = checkIfInRGB(255 - (255 - guyPixel.G) / checkIfInRGB(auroraPixel.G));
                    int b = checkIfInRGB(255 - (255 - guyPixel.B) / checkIfInRGB(auroraPixel.B));

                    bitmanpguy.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bitmanpguy;
        }

        public static Bitmap dostosujJasnosc(Bitmap Image, int Value)
        {
            Bitmap tempBitmap = Image;
            float finalValue = (float)Value / 255.0f;
            Bitmap newBitmap = new Bitmap(tempBitmap.Width, tempBitmap.Height);
            Graphics newGraphics = Graphics.FromImage(newBitmap);
            float[][] floatColorMatrix =
            {
                new float[] {1,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,1,0},
                new float[] {finalValue,finalValue,finalValue,1,1}
            };
            ColorMatrix newcolorMatrix = new ColorMatrix(floatColorMatrix);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(newcolorMatrix);
            newGraphics.DrawImage(tempBitmap, new Rectangle(0, 0, tempBitmap.Width, tempBitmap.Height), 0, 0,
                tempBitmap.Width, tempBitmap.Height, GraphicsUnit.Pixel, attributes);
            attributes.Dispose();
            newGraphics.Dispose();

            return newBitmap;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = dostosujJasnosc(bitmanpguy, trackBar1.Value);
        }

     
    }
}
