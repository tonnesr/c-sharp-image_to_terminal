using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TerminalImage
{
    class Program
    {
        readonly string path = "E:\\images\\image.png"; //Change this string to image path.
        readonly Bitmap img;

        static Program program;

        int colorA = 140;
        int colorB = 140;
        int imgSizeDif = 0;

        Program()
        {
            Console.SetBufferSize(1920, 1080);
            Console.SetWindowSize(240, 63);
            Console.CursorVisible = false;

            img = loadImage(path);

            imgSizeDif = getSizeDif(img.Height);

            render(img);
        }

        int getSizeDif(int height)
        {
            int sizeDif = 3;

            if (height >= 300)
            {
                sizeDif = sizeDif + 1;
            }
            if (height >= 600)
            {
                sizeDif = sizeDif + 2;
            }
            if (height >= 900)
            {
                sizeDif = sizeDif + 3;
            }
            else if (height >= 1200)
            {
                sizeDif = sizeDif + 4;
            }
            else if (height >= 1500)
            {
                sizeDif = sizeDif + 5;
            }
            else if (height >= 1800)
            {
                sizeDif = sizeDif + 6;
            }
            else if (height >= 2100)
            {
                sizeDif = sizeDif + 7;
            }

            return sizeDif;
        }

        void render(Bitmap image)
        {
            Color pixel;
            ConsoleColor newColor;

            char cha = ' ';
            int counter = 0;

            for (int h = 0; h < image.Height; h++)
            {
                if (h % imgSizeDif == 0)
                {
                    for (int w = 0; w < image.Width; w++) // fix new line for width.
                    {
                        if (w % imgSizeDif == 0)
                        {
                            pixel = image.GetPixel(w, h);

                            if (pixel.R < colorB && pixel.G < colorB && pixel.B < colorB) //Black
                            {
                                cha = 'B';
                                newColor = ConsoleColor.Black;
                            }
                            else if (pixel.R > colorA && pixel.G > colorA && pixel.B > colorA) //White
                            {
                                cha = 'W';
                                newColor = ConsoleColor.Gray;
                            }
                            else if (pixel.R > colorA && pixel.G < colorB && pixel.B < colorB) //Red
                            {
                                cha = 'R';
                                newColor = ConsoleColor.Red;
                            }
                            else if (pixel.R < colorB && pixel.G > colorA && pixel.B < colorB) //Green
                            {
                                cha = 'G';
                                newColor = ConsoleColor.Green;
                            }
                            else if (pixel.R < colorB && pixel.G < colorB && pixel.B > colorA) //Blue
                            {
                                cha = 'B';
                                newColor = ConsoleColor.DarkBlue;
                            }
                            else if (pixel.R > colorA && pixel.G > colorA && pixel.B < colorB) //Yellow
                            {
                                cha = 'Y';
                                newColor = ConsoleColor.DarkGreen;
                            }
                            else if (pixel.R < colorB && pixel.G > colorA && pixel.B > colorA) //Turquoise
                            {
                                cha = 'T';
                                newColor = ConsoleColor.Blue;
                            }
                            else if (pixel.R > colorA && pixel.G < colorB && pixel.B > colorA) //Purple
                            {
                                cha = 'P';
                                newColor = ConsoleColor.Magenta;
                            }
                            else
                            {
                                cha = ' '; //@
                                newColor = ConsoleColor.Gray;
                            }

                            Console.ForegroundColor = newColor;
                            //Console.Write(" "); //used to maintain width dimention
                            Console.Write(cha);
                        }
                    }

                    //Bugged -> too large picture is larger than the buffer size of the console.
                    Console.SetCursorPosition(0, counter);
                    counter++;
                }
            }
        }

        Bitmap loadImage(string path)
        {
            try
            {
                return new Bitmap(path);
            }
            catch (Exception e)
            {
                Console.Error.Write(e);
                Console.ReadKey();
                throw new Exception();
            }
        }

        static void Main(string[] args)
        {
            program = new Program();

            Console.ReadKey();
        }
    }
}
