namespace TestConekta
{
    internal class Pixel
    {
        public Pixel(int x, int y, char color)
        {
            this.x = x;
            this.y = y;
            Color = color;
        }

        public int x { get; set; }
        public int y { get; set; }
        public char Color { get; set; }
    }
}
