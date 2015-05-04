namespace KingSurvival.Commands
{
    using System.Text.RegularExpressions;
    using Models;

    public class KingMoveCommand : MoveCommand
    {
        public KingMoveCommand(string commandText, Figure king)
            : base(commandText, king)
        {
        }

        protected override void ProcessCommand()
        {

        }

        protected override bool ValidateCommandText()
        {
            var regex = new Regex(@"K(U|D)(L|R)");
            if (regex.IsMatch(this.CommandText))
            {
                return true;
            }

            return false;
        }
    }
}
