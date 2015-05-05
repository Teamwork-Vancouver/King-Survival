using KingSurvival.Contracts;

namespace KingSurvival.Commands
{
    using System.Text.RegularExpressions;
    using Models;

    public class KingMoveCommand : MoveCommand
    {
        public KingMoveCommand(string commandText, IMovable king)
            : base(commandText, king)
        {
        }

        public override void ProcessCommand()
        {
            
            if (base.ValidateCommandLength() && this.ValidateCommandText())
            {
                this.CommandObject.PositionY += GameConstants.DeltaRow[GetIndexOfChange()];
                this.CommandObject.PositionX += GameConstants.DeltaColumn[GetIndexOfChange()];
                //Check if new possition is in the board
            }
           
        }

        private int GetIndexOfChange()
        {
            string command = this.CommandText.ToLower(); 
            int indexOfChange = 0;
            switch (command)
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
            }

            return indexOfChange;
        }

        protected override bool ValidateCommandText()
        {
            var regex = new Regex(@"(K|k)(U|u|D|d)(L|l|R|r)");
            if (regex.IsMatch(this.CommandText))
            {
                return true;
            }

            return false;
        }
    }
}
