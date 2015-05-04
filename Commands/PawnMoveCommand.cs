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

        protected override void ProcessCommand()
        {

        }

        protected override bool ValidateCommandText()
        {
            var regex = new Regex(@"(A|B|C|D)(U|D)(L|R)");
            if (regex.IsMatch(this.CommandText))
            {
                return true;
            }

            return false;
        }
    }
}
