namespace KingSurvival.Contracts
{
    public interface ICommand
    {
        bool Validate();

        void Process();
    }
}
