namespace KingSurvival.Commands
{
    using Contracts;

    public abstract class MoveCommand
    {
        protected MoveCommand(string commandText, IMovable commandObject)
        {
            this.CommandText = commandText;
            this.CommandObject = commandObject;
        }

        protected string CommandText { get; set; }

        protected IMovable CommandObject { get; set; }

        protected bool ValidateCommandLength()
        {
            if (this.CommandText.Length != GameConstants.MaxCommandWordLenght)
            {
                return false;
            }

            return true;
        }

        public abstract void ProcessCommand();

        protected abstract bool ValidateCommandText();
    }
}
