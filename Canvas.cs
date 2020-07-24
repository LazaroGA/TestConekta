using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConekta
{
    internal class Canvas
    {
        internal const int MAX_CANVAS_SIZE = 250;

        public Canvas()
        {
            IsInitialized = false;
        }

        internal char[,] matrix { get; set; }
        internal int mSize { get; set; }
        internal int nSize { get; set; }
        internal bool IsInitialized { get; set; }


        internal void Initialize(int m, int n)
        {

            mSize = m;
            nSize = n;

            matrix = new char[mSize + 1, nSize + 1];

            for (int x = 1; x <= mSize; x++)
            {
                for (int y = 1; y <= nSize; y++)
                {
                    DrawPixel(new Pixel(x, y, 'O'));
                }
            }

            IsInitialized = true;
        }

        internal void DrawPixel(Pixel pixel)
        {
            //if (!IsInitialized)
            //{
            //    Console.WriteLine("Canvas is not initialized!");
            //}
            matrix[pixel.x, pixel.y] = pixel.Color;
        }

        internal void Print()
        {
            if (!IsInitialized)
            {
                Console.WriteLine("Canvas is not initialized!");
            }


            for (int j = 1; j <= nSize; j++)
            {
                for (int i = 1; i <= mSize; i++)
                {

                    Console.Write(matrix[i, j]);

                }
                Console.Write("\r\n");
            }
        }

        internal void VerticalLine(int x, int y1, int y2, char color)
        {
            if (!IsInitialized)
            {
                Console.WriteLine("Canvas is not initialized!");
            }
            for (int n = 1; n <= nSize; n++)
            {
                for (int m = 1; m <= mSize; m++)
                {
                    if (m == x && n >= y1 && n <= y2)
                    {
                        DrawPixel(new Pixel(m, n, color));
                    }
                }
            }
        }

        internal void HorizontalLine(int x1, int x2, int y, char color)
        {
            if (!IsInitialized)
            {
                Console.WriteLine("Canvas is not initialized!");
            }
            for (int n = 1; n <= nSize; n++)
            {
                for (int m = 1; m <= mSize; m++)
                {
                    if (n == y && m >= x1 && m <= x2)
                    {
                        DrawPixel(new Pixel(m, n, color));
                    }
                }
            }
        }

        internal void FillRegion(int x, int y, char color)
        {

            if (!IsInitialized)
            {
                Console.WriteLine("Canvas is not initialized!");
            }
            var region = new List<Pixel>();
            var firstRegionPixel = new Pixel(x, y, matrix[x, y]);
            Pixel aRegionPixel;

            int rxi = x;
            int ryi = y;


            while (rxi >= 0 && ryi >= 0 && rxi <= mSize && ryi <= nSize)
            {
                if (firstRegionPixel.Color == matrix[rxi, ryi] && pixelIsAdjacent(region, firstRegionPixel))
                {
                    region.Add(firstRegionPixel);
                }
            }

            for (int n = 1; n <= nSize; n++)
            {
                for (int m = 1; m <= mSize; m++)
                {

                }
            }
        }

        private bool pixelIsAdjacent(List<Pixel> regionFound, Pixel pixel)
        {

            return regionFound.Any(r => r.Color.Equals(pixel.Color) && ((Math.Abs(Math.Abs(pixel.x) - Math.Abs(r.x)) <= 1) || Math.Abs(Math.Abs(pixel.y) - Math.Abs(r.y)) <= 1));
        }

    }
}
