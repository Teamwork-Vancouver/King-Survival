namespace KingSurvival.Models
{
    using System;
    using Exceptions;

    /// <summary>
    /// Class holding X axis coordinates and Y axis coordinates of a Figure.
    /// </summary>
    public class Position
    {
        private int x;
        private int y;
        private int maxX;
        private int maxY;

        /// <summary>
        /// Constructor for the Position class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <param name="maxX">The maximal X axis coordinate.</param>
        /// <param name="maxY">The maximal Y axis coordinate.</param>
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
                    throw new IndexOutOfRangeException(ExceptionMessages.OutOfBounds);
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
                    throw new IndexOutOfRangeException(ExceptionMessages.OutOfBounds);
                }

                this.y = value;
            }
        }
    }
}
