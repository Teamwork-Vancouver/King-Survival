namespace KingSurvival
{
    public static class GameConstants
    {
        public const int BoardWidth = 7;
        public const int BoardHeight = 7;

        public const int KingStartPositionX = 3;
        public const int KingStartPositionY = 7;

        public const int PawnsStartPositionY = 0;
        public const int PawnAStartPositionX = 0;
        public const int PawnBStartPositionX = 2;
        public const int PawnCStartPositionX = 4;
        public const int PawnDStartPositionX = 6;

        public const int MaxCommandWordLength = 3;

        public const int MovesPerTurn = 2;

        public const string KingVictory = "King wins in {0} turns.";
        public const string KingLoss = "King lost in {0} turns.";

        public static readonly char[] PawnSymbols = { 'A', 'B', 'C', 'D' };
        public static readonly int[,] PossibleFigureMoves = { { -1, -1 }, { 1, -1 }, { 1, 1 }, { -1, 1 } };
    }
}
