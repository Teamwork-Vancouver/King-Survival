namespace KingSurvival
{
    using System;
    using Models;

    internal class KingSurvival
    {
        private readonly int blackCell = '-';
        private readonly int[] deltaColona = {+1, +1, -1, -1};
        private readonly int[] deltaRed = {-1, +1, +1, -1}; //UR, DR, DL, UL
        private readonly int[,] dyska;
        private readonly int[] pawnColumns = {0, 2, 4, 6};
        private readonly int[] pawnRows = {0, 0, 0, 0};
        //s + belejim belite poleta
        //s - belejim chernite poleta
        private readonly int whiteCell = '+';
        private int kingColumn = 3;
        private int kingRow = 7;

        public KingSurvival()
        {
            dyska = new int[8, 8];
            DaiMiDyskata();
        }

        public void DaiMiDyskata()
        {
            for (var row = 0; row < dyska.GetLength(0); row++)
            {
                for (var colum = 0; colum < dyska.GetLength(1); colum++)
                {
                    if ((row + colum)%2 == 0)
                    {
                        dyska[row, colum] = whiteCell;
                    }

                    else
                    {
                        dyska[row, colum] = blackCell;
                    }
                }
            }
            dyska[pawnRows[0], pawnColumns[0]] = 'A';

            dyska[pawnRows[1], pawnColumns[1]] = 'B';

            dyska[pawnRows[2], pawnColumns[2]] = 'C';

            dyska[pawnRows[3], pawnColumns[3]] = 'D';

            dyska[kingRow, kingColumn] = 'K';
        }

        public bool MoveKingIfPossible(string command)
        {
            if (command.Length != 3)
            {
                return false;
            }
            var commandMalka = command.ToLower();
            var indexOfChange = -1;
            switch (commandMalka)
            {
                case "kur":
                {
                    indexOfChange = 0;
                }
                    break;
                case "kdr":
                {
                    indexOfChange = 1;
                }
                    break;
                case "kdl":
                {
                    indexOfChange = 2;
                }
                    break;
                case "kul":
                {
                    indexOfChange = 3;
                }
                    break;
                default:
                    return false;
            }
            var kingNewRow = kingRow + deltaRed[indexOfChange];
            var kingNewColum = kingColumn + deltaColona[indexOfChange];
            if (proverka2(kingNewRow, kingNewColum))
            {
                dyska[kingRow, kingColumn] = dyska[kingNewRow, kingNewColum];
                dyska[kingNewRow, kingNewColum] = 'K';
                kingRow = kingNewRow;


                kingColumn = kingNewColum;
                return true;
            }
            return false;
        }

        public bool MovePawnIfPossible(string command)
        {
            if (command.Length != 3)
            {
                return false;
            }
            var commandToLower = command.ToLower();
            var indexOfChange = -1;
            switch (commandToLower)
            {
                case "adr":
                case "bdr":
                case "cdr":
                case "ddr":
                {
                    indexOfChange = 1;
                }
                    break;
                case "adl":
                case "bdl":
                case "cdl":
                case "ddl":
                {
                    indexOfChange = 2;
                }
                    break;
                default:
                    return false;
            }
            var pawnIndex = -1;
            switch (command[0])
            {
                case 'a':
                case 'A':
                {
                    pawnIndex = 0;
                }
                    break;
                case 'b':
                case 'B':
                {
                    pawnIndex = 1;
                }
                    break;
                case 'c':
                case 'C':
                {
                    pawnIndex = 2;
                }
                    break;
                case 'd':
                case 'D':
                {
                    pawnIndex = 3;
                }
                    break;
            }

            var pawnNewRow = pawnRows[pawnIndex] + deltaRed[indexOfChange];
            var pawnNewColum = pawnColumns[pawnIndex] + deltaColona[indexOfChange];
            if (proverka2(pawnNewRow, pawnNewColum))
            {
                dyska[pawnRows[pawnIndex], pawnColumns[pawnIndex]] = dyska[pawnNewRow, pawnNewColum];
                dyska[pawnNewRow, pawnNewColum] = command.ToUpper()[0];
                pawnRows[pawnIndex] = pawnNewRow;
                pawnColumns[pawnIndex] = pawnNewColum;
                return true;
            }
            return false;
        }

        public bool KingWon()
        {
            if (kingRow == 0) //check if king is on the first row
            {
                return true;
            }
            for (var i = 0; i < dyska.GetLength(0); i += 2) // check if all powns are on the last row
            {
                if (dyska[dyska.GetLength(1) - 1, i] == whiteCell || dyska[dyska.GetLength(1) - 1, i] == blackCell)
                {
                    return false;
                }
            }
            return true;
        }

        private bool proverka(int row, int colum)
        {
            if (row < 0 || row > dyska.GetLength(0) - 1 || colum < 0 || colum > dyska.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }

        private bool proverka2(int row, int colum)
        {
            if (proverka(row, colum))
            {
                if (dyska[row, colum] == whiteCell || dyska[row, colum] == blackCell)
                {
                    return true;
                }
            }
            return false;
        }

        public bool KingLost()
        {
            if (!proverka2(kingRow + 1, kingColumn + 1) && !proverka2(kingRow + 1, kingColumn - 1) &&
                !proverka2(kingRow - 1, kingColumn + 1) && !proverka2(kingRow - 1, kingColumn - 1))
            {
                return true;
            }
            return false;
        }

        public void PrintBoard()
        {
            for (var row = 0; row < dyska.GetLength(0); row++)
            {
                for (var colum = 0; colum < dyska.GetLength(1); colum++)
                {
                    var cell = dyska[row, colum];
                    var toPrint = (char) cell;
                    Console.Write(toPrint + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Main()
        {
            var board = new Board(GameConstants.BoardWidth, GameConstants.BoardHeight);
            var game = new Game(board);
            game.Run();

            //var game = new KingSurvival();
            //var hodoveNaCarq = 0;
            //var isKingsTurn = true;
            //while (true) //dokato igrata ne svyrshi - vyrti cikyla
            //{
            //    if (game.KingWon())
            //    {
            //        Console.WriteLine("King won in {0} turns", hodoveNaCarq);
            //        break;
            //    }
            //    if (game.KingLost())
            //    {
            //        Console.WriteLine("King lost in {0} turns", hodoveNaCarq);
            //        break;
            //    }
            //    Console.WriteLine();
            //    game.PrintBoard();
            //    if (isKingsTurn)
            //    {
            //        var kingMoved = false;
            //        while (!kingMoved)
            //        {
            //            Console.Write("King's turn: ");
            //            var command = Console.ReadLine();
            //            kingMoved = game.MoveKingIfPossible(command);
            //            if (!kingMoved)
            //            {
            //                Console.WriteLine("Illegal move!");
            //            }
            //        }
            //        isKingsTurn = false;
            //        hodoveNaCarq++;
            //    }
            //    else
            //    {
            //        var pawnMoved = false;
            //        while (!pawnMoved)
            //        {
            //            Console.Write("Pawns' turn: ");
            //            var command = Console.ReadLine();
            //            pawnMoved = game.MovePawnIfPossible(command);
            //            if (!pawnMoved)
            //            {
            //                Console.WriteLine("Illegal move!");
            //            }
            //        }
            //        isKingsTurn = true;
            //    }
            //}
        }
    }
}