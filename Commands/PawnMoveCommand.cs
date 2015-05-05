namespace KingSurvival.Commands
{
    using System.Text.RegularExpressions;
    using Models;

    public class PawnMoveCommand : MoveCommand
    {
        public PawnMoveCommand(string commandText, Figure pawn)
            : base(commandText, pawn)
        {
        }

        public override void ProcessCommand()
        {
            if (ValidateCommandLength() && ValidateCommandText())
            {
                int newColumnnIndex = GetIndexOfChange();
                
            }
        }

        private int GetIndexOfChange()
        {
            string command = this.CommandText.ToLower().Substring(1);
            int indexOfChange = -1;
            switch (command)
            {
                case "dr":
                {
                    indexOfChange = 1;
                }
                    break;
                case "dl":
                {
                    indexOfChange = 2;
                }
                    break;
            }

            return indexOfChange;
        }

        protected override bool ValidateCommandText()
        {
            var regex = new Regex(@"(A|a|B|b|C|c|D|d)(U|u|D|d)(L|l|R|r)");
            if (regex.IsMatch(this.CommandText))
            {
                return true;
            }

            return false;
        }
    }
}
