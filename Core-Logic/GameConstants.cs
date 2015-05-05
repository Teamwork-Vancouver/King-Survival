namespace KingSurvival
{
    public static class GameConstants
    {
        public const int BoardWidth = 8;
        public const int BoardHeight = 8;

        public const int KingStartPositionX = 3;
        public const int KingStartPositionY = 7;

        public const int PawnsStartPositionY = 0;
        public const int PawnAStartPositionX = 0;
        public const int PawnBStartPositionX = 2;
        public const int PawnCStartPositionX = 4;
        public const int PawnDStartPositionX = 6;

        public const int MaxCommandWordLenght = 3;

        public static readonly int[] DeltaRow = { -1, +1, +1, -1 };
        public static readonly int[] DeltaColumn = { +1, +1, -1, -1 };
    }
}
