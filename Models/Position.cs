namespace KingSurvival.Models
{
    using System;

    public class Position
    {
        private int x;
        private int y;
        private int maxX;
        private int maxY;

        public Position(int x, int y, int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0 || value > this.maxX)
                {
                    throw new Exception();
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0 || value > this.maxY)
                {
                    throw new Exception();
                }

                this.y = value;
            }
        }
    }
}
