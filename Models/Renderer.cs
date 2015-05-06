namespace KingSurvival.Models
{
    using System;
    using System.Linq;
    using Contracts;

    public class Renderer
    {
        /// <summary>
        /// Prints the board on the console.
        /// </summary>
        /// <param name="board">current game board</param>
        public void Render(Board board)
        {
            string rowNumbers = "0 1 2 3 4 5 6 7";
            string underscore = string.Format("{0}", new string('_', 17));
            string fieldBeginning = string.Format("UL{2}{0}{2}UR\n{2} {1}", rowNumbers, underscore, new string(' ', 2));
            string fieldEnd = string.Format("DL{1}{0}{1}DR\n{1}", rowNumbers, new string(' ', 2));

            Console.WriteLine(fieldBeginning);
            for (int row = 0; row <= GameConstants.BoardWidth; row++)
            {
                string rowBeginning = string.Format("{0} | ", row);
                string rowEnd = string.Format("| {0}", row);

                Console.Write(rowBeginning);
                for (int column = 0; column <= GameConstants.BoardWidth; column++)
                {
                    IFigure figure = board.Figures.FirstOrDefault(x => x.Key.X == column && x.Key.Y == row).Value;
                    if (figure != null)
                    {
                        Console.Write(figure.Symbol.ToString() + ' ');
                    }
                    else
                    {
                        char symbol = (row + column) % 2 == 0 ? '+' : '-';
                        Console.Write(symbol.ToString() + ' ');
                    }
                }

                Console.Write(rowEnd + "\n");
            }

            Console.WriteLine(string.Format("{0}{1}{2}{1}{0}", new string(' ', 2), '|', underscore) + "\n" + fieldEnd);
        }
    }
}
