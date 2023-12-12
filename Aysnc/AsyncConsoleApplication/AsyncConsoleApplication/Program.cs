using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncConsoleApplication
{
    class  Program
    {
        static DateTime startTime, endTime;
        static StringBuilder sb;
        

        static unsafe void Main(string[] args)
        {
            long count = 200000000;
            short[] shorts = new short[count];
            //100 Million ints
            Console.WriteLine("\nCreate " + count + " Million shorts");
            if (LogStart())
            {
                
                for (long i = 0; i < count; i++)
                {
                    shorts[i] = 1;
                }
            }
            LogEnd();

            //100 Million ints parrallel
            Console.WriteLine("\nCreate " + count + " Million shorts Parallel");
            short[] shortsP = new short[count];
            if (LogStart())
            {
                
                Parallel.For(0, count, i =>
                    {
                        shortsP[i] = 1;
                    });
            }
            LogEnd();

            //Regular Loop
            Console.WriteLine("\n" + count + " Million ints ++");
            if (LogStart())
            {
                for (long i = 0; i < count; i++)
                {
                    shorts[i]++;
                }
            }
            LogEnd();

            //Parallel
            Console.WriteLine("\n" + count + " Million ints ++ Parallel.For");
            if (LogStart())
            {
                Parallel.For(0, count, i =>
                    {
                        shortsP[i]++;
                    });
            }
            LogEnd();

            //4 x Regular Loop
            Console.WriteLine("\n" + count + " Million ints sin(count) 4 times");
            if (LogStart())
            {
                for (int times = 0; times < 4; times++)
                {
                    for (long i = 0; i < count; i++)
                    {
                        shorts[i] = (short)Math.Sin(count);
                    }
                }
            }
            LogEnd();

            //4 x Parallel
            Console.WriteLine("\n" + count + " Million ints sin(count) Parallel.For 4 times");
            if (LogStart())
            {
                Parallel.For(0, 4, times =>
                    {
                        Parallel.For(0, count, i =>
                        {
                            shortsP[i] = (short)Math.Sin(count);
                        });
                    });
            }
            LogEnd();

            //Images
            var img = Bitmap.FromFile("imageBig.jpg");
            var imgSmall = Bitmap.FromFile("imageSmall.jpg");

            //get byte array
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                imgSmall.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            sb = new StringBuilder();

            //Regular Loop
            Console.WriteLine("\nImage write bytes");
            if (LogStart())
            {
                foreach (byte b in arr)
                {
                    Console.Write("\t" + b.ToString());
                }
            }
            LogEnd();

            //Relgular loop string builder
            Console.WriteLine("\nImage write bytes string builder");
            if (LogStart())
            {
                foreach (byte b in arr)
                {
                    sb.Append("\t" + b.ToString());
                }
                Console.Write(sb.ToString());
            }
            LogEnd();

            

            //Invert
            
            
            //Invert IMage
            Bitmap bmpSmall = new Bitmap(imgSmall);
            Console.WriteLine("Invert \nImage For loop");
            if (LogStart())
            {
                for (int i = 0; i < bmpSmall.Height * bmpSmall.Width; ++i)
                {
                    var row = i / bmpSmall.Width;
                    var col = i % bmpSmall.Height;
                    if (row % 2 != 0) col = bmpSmall.Width - col - 1;
                    var pixel = bmpSmall.GetPixel(col, row);
                    //Invert
                    bmpSmall.SetPixel(col, row, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
                bmpSmall.Save("outInvertNoLock.jpg", ImageFormat.Jpeg);
            }
            LogEnd();

            //invert with lockbits much faster
            //Invert with Lockbits and ptr
            Console.WriteLine("Invert \nImage For loop LockBits");
            Bitmap bmpSmallP = new Bitmap(imgSmall);
            if (LogStart())
            {

                var data = bmpSmallP.LockBits(new Rectangle(0, 0, bmpSmallP.Width, bmpSmallP.Height),
                                           ImageLockMode.ReadWrite,
                                           bmpSmallP.PixelFormat);

                var pt = (byte*)data.Scan0;
                var bpp = data.Stride / bmpSmallP.Width;

                for (var y = 0; y < data.Height; y++)
                {
                    // This is why real scan-width is important to have!
                    var rowS = pt + (y * data.Stride);

                    for (var x = 0; x < data.Width; x++)
                    {
                        var pixel = rowS + x * bpp;

                        for (var bit = 0; bit < bpp; bit++)
                        {
                            var pixelComponent = pixel[bit];
                            pixelComponent = (byte)(255 - pixelComponent);
                            pixel[bit] = pixelComponent;
                        }
                    }
                }

                bmpSmallP.UnlockBits(data);
                bmpSmallP.Save("outInvertLock.jpg", ImageFormat.Jpeg);
            }
            LogEnd();

            Bitmap bmp;     //Large image may already be a bitmap thanks .net
            if (img is Bitmap)
            {
                bmp = (Bitmap)img;
            }
            else
            {
                bmp = new Bitmap(img);
            }
            //Invert with Lockbits and ptr
            Console.WriteLine("Invert \nImage For loop LockBits");
            if (LogStart())
            {
                
                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                                           ImageLockMode.ReadWrite,
                                           bmp.PixelFormat);

                var pt = (byte*)data.Scan0;
                var bpp = data.Stride / bmp.Width;

                for (var y = 0; y < data.Height; y++)
                {
                    // This is why real scan-width is important to have!
                    var rowS = pt + (y * data.Stride);

                    for (var x = 0; x < data.Width; x++)
                    {
                        var pixel = rowS + x * bpp;

                        for (var bit = 0; bit < bpp; bit++)
                        {
                            var pixelComponent = pixel[bit];
                            pixelComponent = (byte)(255 - pixelComponent);
                            pixel[bit] = pixelComponent;
                        }
                    }
                }

                bmp.UnlockBits(data);
                bmp.Save("outInvertFor.jpg", ImageFormat.Jpeg);
            }
            LogEnd();

            Console.WriteLine("\nInvert Image Lockbits Parallel For loop");
            //Parallel Invert
            Bitmap bitmap;     //Large image may already be a bitmap thanks .net
            if (img is Bitmap)
            {
                bitmap = (Bitmap)img;
            }
            else
            {
                bitmap = new Bitmap(img);
            }
            
            if (LogStart())
            {
                //Bitmap source = bmp;
                
                var data = bitmap.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                                           ImageLockMode.ReadWrite,
                                           bitmap.PixelFormat);

                var pt = (byte*)data.Scan0;
                var bpp = data.Stride / bitmap.Width;

                Parallel.For(0, data.Height, y =>
                {
                    // This is why real scan-width is important to have!
                    var rowP = pt + (y * data.Stride);

                    for (int x = 0; x < data.Width; x++)
                    {
                        var pixelP = rowP + x * bpp;

                        for (var bit = 0; bit < bpp; bit++)
                        {
                            var pixelComponent = pixelP[bit];
                            pixelComponent = (byte)(255 - pixelComponent);
                            pixelP[bit] = pixelComponent;
                        }
                    }
                });

                bitmap.UnlockBits(data);
                bitmap.Save("outInvertPFor.jpg", ImageFormat.Jpeg);
            }
            LogEnd();

            Console.ReadKey();


        }

        private static bool LogStart()
        {
            Console.WriteLine("Press any key to continue. Press S to skip...");
            ConsoleKeyInfo ck = Console.ReadKey(true);
            
            if (ck.Key == ConsoleKey.S)
            {
                startTime = DateTime.MaxValue;
                return false;
            }
            startTime = System.DateTime.Now;
            return true;
        }

        private static void LogEnd()
        {
            endTime = System.DateTime.Now;
            if (startTime != DateTime.MaxValue)
            {
                Console.WriteLine(string.Format("\nStart: {0}\tEnd: {1}\tElapsed: {2} seconds",
                    startTime.ToLongTimeString(),
                    endTime.ToLongTimeString(),
                    endTime.Subtract(startTime).TotalSeconds));
            }
            else
            {
                Console.WriteLine("\nSkipped");
            }
            
        }
    }
}
